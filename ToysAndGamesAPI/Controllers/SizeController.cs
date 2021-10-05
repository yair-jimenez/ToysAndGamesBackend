using DataAccess.Contracts;
using DataAccess.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;


namespace ToysAndGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private IRepository<Size> repository;
        private readonly ILogger<SizeController> _logger;
        private readonly IWebHostEnvironment hostingEnv;
        public SizeController(ILogger<SizeController> logger, MainDBContext dbContext, IRepository<Size> repository, IWebHostEnvironment hostingEnv)
        {
            this.repository = repository;
            repository.Init(dbContext, typeof(Size));
            _logger = logger;
            this.hostingEnv = hostingEnv;
        }
        [HttpGet]
        public ActionResult<List<Size>> Get()
        {
            return repository.Get();
        }
        [HttpPost]
        public ActionResult<List<Size>> Post([FromForm] Size size)
        {
            bool transactionSuccesfullyExecuted = repository.AddOrUpdate(size);
            if (transactionSuccesfullyExecuted)
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            bool transactionSuccesfullyExecuted = repository.Delete(id);
            if (transactionSuccesfullyExecuted)
                return Ok();
            else
                return NotFound();
        }
    }
}
