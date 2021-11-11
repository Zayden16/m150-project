using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlContext _context;

        public CategoryRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Category.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Category.FirstOrDefault(t => t.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Category.FirstOrDefault(x => x.CategoryId == category.CategoryId);

                if (entity != null)
                    throw new Exception($"Entity with id: '{category.CategoryId}' already exists.");

                _context.Category.Add(category);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateCategory(Category category)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Category.Update(category);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteCategory(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Category.FirstOrDefault(t => t.CategoryId == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Category.Remove(entity);
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