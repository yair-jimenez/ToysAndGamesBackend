using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company:BaseModel
    {
        public string Name { get; set; }
        public string Addres { get; set; }
        
        public Product Product { get; set; }
    }
}
