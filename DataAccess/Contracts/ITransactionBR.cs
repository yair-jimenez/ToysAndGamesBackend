using DataAccess.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ITransactionBR
    {
        
        public bool Update(object originalObject);
        public void ValidateDependecies(object originialObject);
        public bool DeleteModel(object Id);
    }
}
