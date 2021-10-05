using DataAccess.Contracts;
using DataAccess.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;

namespace ToysAndGamesAPI.Controllers
{
    public class SizesProductsController : Controller
    {
        private IRepository<SizeShoes> repository;
        private readonly ILogger<SizeController> _logger;
        private readonly IWebHostEnvironment hostingEnv;
        public SizesProductsController(ILogger<SizeController> logger, MainDBContext dbContext, IRepository<SizeShoes> repository, IWebHostEnvironment hostingEnv)
        {
            this.repository = repository;
            repository.Init(dbContext, typeof(Size));
            _logger = logger;
            this.hostingEnv = hostingEnv;
        }
        [HttpGet]
        public ActionResult<List<SizeShoes>> Get()
        {
            return repository.Get();
        }
        [HttpPost]
        public ActionResult<List<SizeShoes>> Post([FromForm] SizeShoes sizeShoes)
        {
            bool transactionSuccesfullyExecuted = repository.AddOrUpdate(sizeShoes);
            if (transactionSuccesfullyExecuted)
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete]
        public ActionResult Delete([FromForm] SizeShoes modelId)
        {
            bool transactionSuccesfullyExecuted = repository.Delete(modelId);
            if (transactionSuccesfullyExecuted)
                return Ok();
            else
                return NotFound();
        }
    }
}
