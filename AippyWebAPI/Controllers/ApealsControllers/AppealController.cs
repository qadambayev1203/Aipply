using AutoMapper;
using Contracts.AllRepository.AppealsRepository;
using Entities.DTO.AppealsDTOS;
using Entities.Model.AppealsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AippyWebAPI.Controllers.ApealsControllers
{
    [Route("api/appeal")]
    [ApiController]
    public class AppealController : ControllerBase
    {
        private readonly IAppealRepository _repository;
        private readonly IMapper _mapper;
        public AppealController(IAppealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Appeal CRUD

        [HttpPost("createappeal")]
        public IActionResult CreateAppeal(AppealCreatedDTO appeal1)
        {
            var appeal = _mapper.Map<Appeal>(appeal1);
            bool check = _repository.CreateAppeal(appeal);
            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }


        [Authorize(Roles = "admin")]

        [HttpGet("getallappeal")]
        public IActionResult GetAllAppeal(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Appeal> appeals1 = _repository.AllAppeal(queryNum, pageNum);
            var appeals = _mapper.Map<IEnumerable<AppealReadedDTO>>(appeals1);
            if (appeals == null) { return NotFound(); }

            return Ok(appeals);
        }





        [Authorize(Roles = "admin")]
        [HttpGet("getbyidappeal/{id}")]
        public IActionResult GetByIdAppeal(int id)
        {

            Appeal appeal1 = _repository.GetAppealById(id);
            var appeal = _mapper.Map<AppealReadedDTO>(appeal1);
            if (appeal == null) { return NotFound(); }

            return Ok(appeal);
        }




        [Authorize(Roles = "admin")]
        [HttpPut("statusreadedappeal/{id}")]
        public IActionResult StatusReadedAppeal(int id, int status_id)
        {
            bool check = _repository.StatusReadedAppeal(id, status_id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok();
        }



        //[HttpPut("updateappeal/{id}")]
        //public IActionResult UpdateAppeal(AppealUpdatedDTO appeal1, int id)
        //{
        //    return Ok();
        //}
    }
}
