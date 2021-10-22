using System.Collections.Generic;
using FiscusApi.Helpers;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiscusApi.Controllers
{
    [AuthorizationRequired]
    [Route("api/[controller]")]
    public class DocumentStatusController : ControllerBase
    {
        private readonly IDocumentStatusRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentStatusController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public DocumentStatusController(IDocumentStatusRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<DocumentStatus> Get()
        {
            return _dataAccessProvider.GetDocumentStatusRecords();
        }

        [HttpGet("{id}")]
        public DocumentStatus Details(int id)
        {
            return _dataAccessProvider.GetDocumentStatusSingleRecord(id);
        }
    }
}
