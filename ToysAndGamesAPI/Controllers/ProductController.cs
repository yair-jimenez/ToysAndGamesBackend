using DataAccess.Contracts;
using DataAccess.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.IO;


namespace ToysAndGamesAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<Product> repository;
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment hostingEnv;
        public ProductController(ILogger<ProductController> logger, MainDBContext dbContext, IRepository<Product> repository, IWebHostEnvironment hostingEnv)
        {
            this.repository = repository;
            repository.Init(dbContext, typeof(Product));
            _logger = logger;
            this.hostingEnv = hostingEnv;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return repository.Get();
        }
        private void RemoveQuotes(ref Product product)
        {
            product.Name = product.Name?.Replace("\"", "");
            product.Description = product.Description?.Replace("\"", "");
            product.Company.Name = product.Company.Name?.Replace("\"", "");
            product.Company.Addres = product.Company.Addres?.Replace("\"", "");
        }
        private void RemoveImage(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception err)
            {

            }

        }
        [HttpPost]
        public ActionResult Post([FromForm] Product product)
        {
            product.LastModification = DateTime.Now;
            if (product.Image != null)
            {
                string path = SaveImage(product);
                if (path.Length > 0)
                    product.UrlImage = path;
                else
                    return BadRequest();
            }
            else
            {
                if (!string.IsNullOrEmpty(product.UrlImage))
                {
                    RemoveImage(product.UrlImage);
                    product.UrlImage = "";
                }
            }
            RemoveQuotes(ref product);
            bool transactionSuccesfullyExecuted = repository.AddOrUpdate(product);
            if (transactionSuccesfullyExecuted)
                return Ok();
            else
                return NotFound();
        }
        private string SaveImage(Product product)
        {
            try
            {
                string root = hostingEnv.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "." + product.Image.ContentType.Split("/")[1];
                string pathContainer = "ImagesContainer";
                string filePath = Path.Combine(root, pathContainer, fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    product.Image.CopyTo(fileSteam);
                }
                return Path.Combine(pathContainer, fileName);
            }
            catch (Exception err)
            {
                return "";
            }

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
