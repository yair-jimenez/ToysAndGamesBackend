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
    public class SizesProductsBR:ITransactionBR
    {
        protected MainDBContext dbContext;
        public SizesProductsBR(MainDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Update(object originalObject)
        {
            SizeShoes model = originalObject as SizeShoes;
            SizeShoes reference = dbContext.SizeProduct.Where(p => p.ProductId == model.ProductId && p.SizeId == model.SizeId).FirstOrDefault();
            bool exist = reference != null;
            if (exist)
            {
                reference = model as SizeShoes;
                dbContext.Entry(reference).State = EntityState.Modified;
            }
            return exist;

        }

        public void ValidateDependecies(object originialObject)
        {

        }
        public bool DeleteModel(object Id)
        {
            try
            {
                SizeShoes model = Id as SizeShoes;
                SizeShoes pr = dbContext.SizeProduct.Where(p => p.ProductId == model.ProductId && p.SizeId == model.SizeId).FirstOrDefault();
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
