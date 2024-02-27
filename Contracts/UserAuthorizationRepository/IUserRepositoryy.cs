using Entities.Model.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.UserAuthorizationRepository
{
    public interface IUserRepositoryy
    {
        Task<User> LoginAsync(string login, string password, bool tracking, CancellationToken cancellationToken = default);
    }
}
