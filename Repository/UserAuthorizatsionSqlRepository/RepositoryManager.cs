using Contracts.UserAuthorizationRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserAuthorizatsionSqlRepository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext repositoryContext;
        private IUserRepositoryy userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
        public IUserRepositoryy User
        {

            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(repositoryContext);
                }
                return userRepository;
            }
        }

        public Task SaveAsync() => repositoryContext.SaveChangesAsync();
    }
}
