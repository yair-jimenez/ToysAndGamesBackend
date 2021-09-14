using Microsoft.AspNetCore.Http;
using System;

namespace Models
{
    public class Product : BaseModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public string UrlImage { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public IFormFile Image { get; set; }
        

    }
}
