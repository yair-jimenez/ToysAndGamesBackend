using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Product : BaseModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        //public int AgeRestriction { get; set; }
        public string UrlImage { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
        public bool IsAvaible { get; set; }
        public int InStock { get; set; }
        public Company Company { get; set; }
        public IFormFile Image { get; set; }
        public int SizeId { get; set; }
        public ICollection<SizeShoes> SizeShoes { get; set; }
        

    }
}
