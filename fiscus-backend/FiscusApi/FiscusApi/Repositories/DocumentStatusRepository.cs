using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class DocumentStatusRepository : IDocumentStatusRepository
    {
        private readonly SqlContext _context;

        public DocumentStatusRepository(SqlContext context)
        {
            _context = context;
        }

        public DocumentStatus GetDocumentStatusSingleRecord(int id)
        {
            return _context.DocumentStatus.FirstOrDefault(t => t.DocumentStatus_Id == id);
        }

        public List<DocumentStatus> GetDocumentStatusRecords()
        {
            return _context.DocumentStatus.ToList();
        }
    }
}