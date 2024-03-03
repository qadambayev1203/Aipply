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
        public IEnumerable<Appeal> AllAppeal(int pageNum, int status_id);
        public Appeal GetAppealById(int id);
        public bool CreateAppeal(Appeal appeal);
        //public bool UpdateAppeal(int id, Appeal appeal);
        public bool StatusReadedAppeal(int id, int status_id);
        public int AppealCount(int status_id);
    }
}
