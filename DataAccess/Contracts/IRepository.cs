using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRepository<T>
    {
        void Init(MainDBContext dbContext, Type type);
        bool AddOrUpdate(T model);
        bool Delete(object Id);
        List<T> Get();


    }
}
