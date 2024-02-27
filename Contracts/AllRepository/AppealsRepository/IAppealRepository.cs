using Entities.Model.AppealsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.AppealsRepository
{
    public interface IAppealRepository
    {
        public IEnumerable<Appeal> AllAppeal(int queryNum, int pageNum);
        public Appeal GetAppealById(int id);
        public bool CreateAppeal(Appeal appeal);
        //public bool UpdateAppeal(int id, Appeal appeal);
        public bool StatusReadedAppeal(int id);
    }
}
