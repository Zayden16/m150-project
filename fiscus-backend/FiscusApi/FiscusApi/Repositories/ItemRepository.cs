using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly SqlContext _context;

        public ItemRepository(SqlContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Item.ToList();
        }

        public IEnumerable<Item> GetItemsByShoppingListId(int shoppingListId)
        {
            return _context.Item.Where(x => x.ShoppingListId == shoppingListId);
        }

        public Item GetItem(int id)
        {
            return _context.Item.FirstOrDefault(t => t.ItemId == id);
        }

        public void AddItem(Item item)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Item.FirstOrDefault(x => x.ItemId == item.ItemId);

                if (entity != null)
                    throw new Exception($"Entity with id: '{item.ItemId}' already exists.");

                _context.Item.Add(item);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateItem(Item item)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Item.Update(item);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteItem(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Item.FirstOrDefault(t => t.ItemId == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Item.Remove(entity);
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