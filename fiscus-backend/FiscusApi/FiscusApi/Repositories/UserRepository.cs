using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext _context;

        public UserRepository(SqlContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public User GetUser(int id)
        {
            return _context.User.FirstOrDefault(t => t.UserId == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.User.FirstOrDefault(t => t.Username == username);
        }

        public void AddUser(User user)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.User.FirstOrDefault(x => x.UserId == user.UserId);
                if (entity != null)
                    throw new Exception($"Entity with id: '{user.UserId}' already exists.");

                entity = _context.User.FirstOrDefault(x => x.Username == user.Username);
                if (entity != null)
                    throw new Exception($"Entity with username: '{user.Username}' already exists.");

                _context.User.Add(user);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateUser(User user)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.User.Update(user);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteUser(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.User.FirstOrDefault(u => u.UserId == id);

                if (entity != null) 
                    _context.User.Remove(entity);

                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public IEnumerable<User> GetUsersByGroupId(int groupId)
        {
            return _context.User.Where(u => u.GroupId == groupId).ToList();
        }
    }
}