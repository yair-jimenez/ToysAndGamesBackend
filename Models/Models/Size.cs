using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Size:BaseModel
    {
        public decimal ShoeSize { get; set; }
        public ICollection<SizeShoes> SizeShoes { get; set; }
    }
}
