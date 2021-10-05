using DataAccess.Contracts;
using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ProductBR :ITransactionBR
    {
        protected MainDBContext dbContext;
        public ProductBR(MainDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void ValidateDependecies(object originialObject)
        {
            Product p = originialObject as Product;
            bool addCompany = ProductBR.HandleCompany(dbContext.Companies.AsNoTracking().ToArray(), ref p);
            if (addCompany)
            {
                dbContext.Companies.Add(p.Company);
            }
        }
        public static bool HandleCompany(Company[] companies, ref Product payload)
        {
            Product payloadAux = payload;

            Company repeatedCompany = companies.Where(c => c.Name.Trim().ToUpper() == payloadAux.Company.Name.Trim().ToUpper()).FirstOrDefault();
            if (repeatedCompany != null)
            {
                payload.CompanyId = repeatedCompany.Id;
                payload.Company = null;
                return false;
            }
            return true;


        }

        public bool Update(object originalObject)
        {
            Product model = originalObject as Product;
            Product pr = dbContext.Products.AsNoTracking().Where(p => p.Id == model.Id).FirstOrDefault();
            bool exist = pr != null;

            if (exist)
            {
                pr = model as Product;
                dbContext.Entry(pr).State = EntityState.Modified;
            }
            return exist;
        }

        public bool DeleteModel(object modelId)
        {
            int Id = int.Parse(modelId.ToString());
            try
            {
                Product pr = dbContext.Products.Where(p => p.Id == Id).FirstOrDefault();
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
