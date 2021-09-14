using DataAccess.Contracts;
using Models;
using System;
using Microsoft.EntityFrameworkCore;
using DataAccess.DBContext;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Repositories;

namespace DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel, new()
    {
        private MainDBContext dbContext;
        private Type type;
        public void Init(MainDBContext dbContext, Type type)
        {
            this.dbContext = dbContext;
            this.type = type;
        }
        public bool AddOrUpdate(T model)
        {
            bool rowAffected = true;
            bool isUpdateTran = (model.Id > 0);
            bool executeTran = true;

            try
            {
                
                if (type == typeof(Product))
                {
                    Product p = model as Product;
                    
                    ProductBR.HandleCompany(dbContext.Companies.AsNoTracking().ToArray(), ref p);
                    
                }
                if (!isUpdateTran)
                {
                    dbContext.Add(model);
                    dbContext.Entry(model).State = EntityState.Added;


                }
                else
                {
                    bool exist = false;
                    if (type == typeof(Product))
                    {
                        Product pr = dbContext.Products.AsNoTracking().Where(p => p.Id == model.Id).FirstOrDefault();
                        exist = pr != null;
                        executeTran = exist;
                        if (exist)
                        {
                            pr = model as Product;
                            dbContext.Entry(pr).State = EntityState.Modified;
                        }

                    }
                    if (type == typeof(Company))
                    {

                    }

                }
                rowAffected = executeTran;
                if (executeTran)
                    dbContext.SaveChanges();
            }
            catch (Exception err)
            {
                rowAffected = false;
            }
            return rowAffected;
        }

        public bool Delete(int Id)
        {
            bool transactionSuccesfully = true;
            try
            {
                if (type == typeof(Product))
                {
                    Product pr = dbContext.Products.Where(p => p.Id == Id).FirstOrDefault();
                    if (pr != null)
                    {
                        dbContext.Remove(pr);
                        dbContext.Entry(pr).State = EntityState.Deleted;
                    }

                }
                if (type == typeof(Company))
                {
                    
                }
                dbContext.SaveChanges();
            }
            catch (Exception err)
            {
                transactionSuccesfully = false;
            }
            return transactionSuccesfully;
        }

        public List<T> Get()
        {

            try
            {
                if (type == typeof(Product))
                {
                    return dbContext.Products.Include(p => p.Company).ToList() as List<T>;
                }
                if (type == typeof(Company))
                {
                    return dbContext.Companies.ToList() as List<T>;
                }
            }
            catch (Exception err)
            {

            }
            return null;
        }


    }
}
