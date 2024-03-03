using Contracts.AllRepository.AppealsRepository;
using Entities;
using Entities.Model.AppealsModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.AppealsSqlRepository
{
    public class AppealSqlRepository : IAppealRepository
    {
        private readonly RepositoryContext _context;
        public AppealSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IEnumerable<Appeal> AllAppeal(int queryNum, int pageNum, int status_id)
        {
            try
            {
                var appeals = new List<Appeal>();
                if (queryNum != 0 && status_id != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    appeals = _context.appeals_20ai24ppy.Where(z => z.status_id == status_id).OrderBy(x => x.id).Include(x => x.status_).Take(queryNum).ToList();
                }
                else if (queryNum == 0 && pageNum != 0 && status_id != 0)
                {
                    appeals = _context.appeals_20ai24ppy.Where(z => z.status_id == status_id).OrderBy(x => x.id).Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10)
                        .ToList();
                }
                else if (queryNum != 0 && status_id == 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    appeals = _context.appeals_20ai24ppy.OrderBy(x => x.id).Include(x => x.status_).Take(queryNum).ToList();
                }
                else if (queryNum == 0 && pageNum != 0 && status_id == 0)
                {
                    appeals = _context.appeals_20ai24ppy.OrderBy(x => x.id).Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10)
                        .ToList();
                }
                else if (queryNum == 0 && pageNum == 0 && status_id != 0)
                {
                    appeals = _context.appeals_20ai24ppy.Where(z => z.status_id == status_id).OrderBy(x => x.id).Include(x => x.status_).ToList();
                }
                else
                {
                    appeals = _context.appeals_20ai24ppy.OrderBy(x => x.id).Include(x => x.status_).ToList();
                }


                return appeals;
            }
            catch
            {
                List<Appeal> appealNull = new List<Appeal>();
                return appealNull;
            }
        }

        public bool CreateAppeal(Appeal appeal)
        {
            try
            {
                if (appeal == null)
                {
                    return false;
                }
                appeal.status_id = 1;
                appeal.create_at = DateTime.UtcNow;
                _context.appeals_20ai24ppy.Add(appeal);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StatusReadedAppeal(int id, int status_id)
        {
            try
            {
                var appeal = GetAppealById(id);
                if (appeal == null)
                {
                    return false;
                }
                var status = _context.statuses_20ai24ppy.FirstOrDefault(x => x.id.Equals(status_id));
                if (status == null)
                {
                    return false;
                }
                appeal.status_id = status.id;
                _context.appeals_20ai24ppy.Update(appeal);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Appeal GetAppealById(int id)
        {
            try
            {
                var appeal = _context.appeals_20ai24ppy.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return appeal;
            }
            catch
            {
                return null;
            }
        }
        public int AppealCount(int status_id)
        {
            try
            {
                int count = 0;
                if (status_id == 0)
                {
                    count = _context.appeals_20ai24ppy.Count();
                    return (int)count;
                }
                else if (status_id >= 1 && status_id <= 4)
                {
                    count = _context.appeals_20ai24ppy.Where(x => x.status_id == status_id).Count();
                    return (int)count;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }


        }

        //public bool UpdateAppeal(int id, Appeal appeal)
        //{

        //    try
        //    {
        //        var dep = GetAppealById(id);
        //        if (dep == null)
        //        {
        //            return false;
        //        }
        //        appeal.id = dep.id;
        //        _context.appeals_20ai24ppy.Update(appeal);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
