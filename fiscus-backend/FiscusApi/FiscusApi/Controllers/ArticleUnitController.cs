using System.Collections.Generic;
using FiscusApi.Helpers;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiscusApi.Controllers
{
    [AuthorizationRequired]
    [Route("api/[controller]")]
    public class ArticleUnitController : ControllerBase
    {
        private readonly IArticleUnitRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleUnitController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public ArticleUnitController(IArticleUnitRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<ArticleUnit> Get()
        {
            return _dataAccessProvider.GetArticleUnitRecords();
        }

        [HttpGet("{id}")]
        public ArticleUnit Details(int id)
        {
            return _dataAccessProvider.GetArticleUnitSingleRecord(id);
        }
    }
}
