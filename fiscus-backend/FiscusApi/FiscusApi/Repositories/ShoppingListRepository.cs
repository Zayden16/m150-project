using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly SqlContext _context;

        public ShoppingListRepository(SqlContext context)
        {
            _context = context;
        }

        public List<ShoppingList> GetShoppingLists()
        {
            return _context.ShoppingList.ToList();
        }

        public ShoppingList GetShoppingList(int id)
        {
            return _context.ShoppingList.FirstOrDefault(t => t.ShoppingListId == id);
        }

        public ShoppingList GetShoppingListByGroupId(int groupId)
        {
            return _context.ShoppingList.FirstOrDefault(t => t.GroupId == groupId);
        }

        public void AddShoppingList(ShoppingList item)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.ShoppingList.FirstOrDefault(x => x.ShoppingListId == item.ShoppingListId);

                if (entity != null)
                    throw new Exception($"Entity with id: '{item.ShoppingListId}' already exists.");

                _context.ShoppingList.Add(item);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateShoppingList(ShoppingList item)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.ShoppingList.Update(item);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteShoppingList(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.ShoppingList.FirstOrDefault(t => t.ShoppingListId == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.ShoppingList.Remove(entity);
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