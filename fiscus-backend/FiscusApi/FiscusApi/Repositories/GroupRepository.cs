using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SqlContext _context;

        public GroupRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Group> GetGroups()
        {
            return _context.Group.ToList();
        }

        public Group GetGroup(int id)
        {
            return _context.Group.FirstOrDefault(t => t.GroupId == id);
        }

        public void AddGroup(Group group)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Group.FirstOrDefault(x => x.GroupId == group.GroupId);

                if (entity != null)
                    throw new Exception($"Entity with id: '{group.GroupId}' already exists.");

                _context.Group.Add(group);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateGroup(Group group)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Group.Update(group);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteGroup(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Group.FirstOrDefault(t => t.GroupId == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Group.Remove(entity);
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