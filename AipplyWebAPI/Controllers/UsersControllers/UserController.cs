using AutoMapper;
using Contracts.UserAuthorizationRepository;
using Entities.DTO.UserAuthorizatsionDTOS;
using Entities.Model.AuthorizationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AippyWebAPI.Controllers.UsersControllers
{
    [Authorize(Roles = "admin")]
    [Route("api/userauthorization")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static string TokenCheck;
        private static int UserId;
        private readonly IRepositoryManager repositoryManager;
        private readonly IOptions<AppSettings> appSettings;
        private readonly IMapper mapper;
        private readonly JwtSecurityTokenHandler securityTokenHandler;

        public UserController(IRepositoryManager repositoryManager, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            this.repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            this.appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            securityTokenHandler = new JwtSecurityTokenHandler();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserAuthInfoDTO>> LoginAsync([FromBody] UserCredentials credentials, CancellationToken cancelationToken)
        {
            UserAuthInfoDTO authInfo = new UserAuthInfoDTO();
            if (credentials == null)
            {
                return BadRequest("No data");
            }
            credentials.Password = PasswordManager.EncryptPassword((credentials.Login + credentials.Password).ToString());
            var user = await repositoryManager.User.LoginAsync(credentials.Login, credentials.Password, false, cancelationToken);
            if (user != null)
            {
                try
                {
                    var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
                    var tokenDescriptoir = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                            new Claim(ClaimTypes.NameIdentifier, user.login.ToString()),
                                                       new Claim(ClaimTypes.Role, user.user_type_.type.ToString()),
                            }
                           ),
                        Expires = DateTime.UtcNow.AddDays(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    };
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptoir);
                    authInfo.Token = securityTokenHandler.WriteToken(securityToken);
                    authInfo.UserDetails = mapper.Map<UserDTO>(user);

                    authInfo.UserDetails.UserType = user.user_type_.type.ToString();
                }
                catch { }
            }
            if (string.IsNullOrEmpty(authInfo?.Token))
            {
                return Unauthorized("Error login or password");
            }
            TokenCheck = authInfo.Token;
            UserId = authInfo.UserDetails.Id;
            return Ok(authInfo);
        }

        [Authorize(Roles = "admin")]
        [AllowAnonymous]
        [HttpGet("verification/{token}")]
        public IActionResult TokenCheckMethod(string token)
        {
            try
            {
                if (token == TokenCheck)
                {
                    TokenVerify verify = new TokenVerify()
                    {
                        user_id = UserId,
                        verification = true
                    };

                    return Ok(verify);
                }
                return StatusCode(404);
            }
            catch
            {
                return StatusCode(404);
            }
        }





    }
}
