using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class ArticleUnitRepository : IArticleUnitRepository
    {
        private readonly SqlContext _context;

        public ArticleUnitRepository(SqlContext context)
        {
            _context = context;
        }

        public ArticleUnit GetArticleUnitSingleRecord(int id)
        {
            return _context.ArticleUnit.FirstOrDefault(t => t.ArticleUnit_Id == id);
        }

        public List<ArticleUnit> GetArticleUnitRecords()
        {
            return _context.ArticleUnit.ToList();
        }
    }
}