﻿using Contracts.AllRepository.AppealsRepository;
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

        public IEnumerable<Appeal> AllAppeal(int queryNum, int pageNum)
        {
            try
            {
                var appeals = new List<Appeal>();
                if (queryNum == 0 && pageNum != 0)
                {
                    appeals = _context.appeals_20ai24ppy.Include(x=>x.status_)                     
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    appeals = _context.appeals_20ai24ppy.Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    appeals = _context.appeals_20ai24ppy.Include(x => x.status_).Take(200).ToList();

                }
                return appeals;
            }
            catch
            {
                return null;
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

        public bool StatusReadedAppeal(int id)
        {
            try
            {
                var appeal = GetAppealById(id);
                if (appeal == null)
                {
                    return false;
                }
                appeal.status_id = 2;
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