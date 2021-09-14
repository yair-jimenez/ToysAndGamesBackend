using DataAccess.DBContext;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductBR
    {
        //Add Company?
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
    }
}
