﻿using System;
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


        public void AddItemRecord(Item item)
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

        public void UpdateItemRecord(Item item)
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

        public void DeleteItemRecord(int id)
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

        public Item GetItemSingleRecord(int id)
        {
            return _context.Item.FirstOrDefault(t => t.ItemId == id);
        }

        public List<Item> GetItemRecords()
        {
            return _context.Item.ToList();
        }
    }
}