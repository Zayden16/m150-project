using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class CostRepository : ICostRepository
    {
        private readonly SqlContext _context;

        public CostRepository(SqlContext context)
        {
            _context = context;
        }

        public IEnumerable<Cost> GetCosts()
        {
            return _context.Cost.ToList();
        }

        public Cost GetCost(int id)
        {
            return _context.Cost.FirstOrDefault(x => x.CostId == id);
        }
        
        public IEnumerable<Cost> GetCostsByGroupId(int groupId)
        {
            return _context.Cost.Where(x => x.GroupId == groupId).ToList();
        }

        public void AddCost(Cost cost)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Cost.FirstOrDefault(x => x.CostId == cost.CostId);

                if (entity != null)
                    throw new Exception($"Entity with id: '{cost.CostId}' already exists.");

                _context.Cost.Add(cost);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateCost(Cost cost)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Cost.Update(cost);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteCost(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Cost.FirstOrDefault(t => t.CostId == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Cost.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}