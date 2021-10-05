using DataAccess.Contracts;
using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SizeBR : ITransactionBR
    {
        protected MainDBContext dbContext;
        public SizeBR(MainDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Update(object originalObject)
        {
            Size model = originalObject as Size;
            Size reference = dbContext.Sizes.Where(p => p.Id == model.Id).FirstOrDefault();
            bool exist = reference != null;
            if (exist)
            {
                reference = model as Size;
                dbContext.Entry(reference).State = EntityState.Modified;
            }
            return exist;

        }

        public void ValidateDependecies(object originialObject)
        {

        }
        public bool DeleteModel(object modelId)
        {
            int Id = int.Parse(modelId.ToString());
            try
            {
                Size pr = dbContext.Sizes.Where(p => p.Id == Id).FirstOrDefault();
                if (pr != null)
                {
                    dbContext.Remove(pr);
                    dbContext.Entry(pr).State = EntityState.Deleted;
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
