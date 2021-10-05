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
        protected MainDBContext dbContext;
        private Type type;
        private ITransactionBR transactionBR;
        public void Init(MainDBContext dbContext, Type type)
        {
            this.dbContext = dbContext;
            this.type = type;
        }
        private void PreValidate(T model)
        {
            if (type == typeof(Product))
            {
                Product p = model as Product;
                transactionBR = new ProductBR(dbContext);
                transactionBR.ValidateDependecies(p);
            }
        }
        private void Add(T model)
        {
            dbContext.Add(model);
            dbContext.Entry(model).State = EntityState.Added;
        }
        private bool Update(T model)
        {
            bool executeTran = false;
            if (type == typeof(Product))
            {
                transactionBR = new ProductBR(dbContext);
                executeTran = transactionBR.Update(model as Product);
            }
            if (type == typeof(Company))
            {
                transactionBR = new SizeBR(dbContext);
                executeTran = transactionBR.Update(model as Size);
            }
            if (type == typeof(SizeShoes))
            {
                transactionBR = new SizesProductsBR(dbContext);
                executeTran = transactionBR.Update(model as SizeShoes);
            }
            return executeTran;
        }
        public bool AddOrUpdate(T model)
        {
            bool rowAffected = true;
            bool isUpdateTran = (model.Id > 0);
            bool executeTran = true;
            try
            {
                PreValidate(model);
                if (!isUpdateTran)
                {
                    Add(model);
                }
                else
                {
                    executeTran = Update(model);
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

        public bool Delete(object Id)
        {
            bool transactionSuccesfully = true;
            try
            {
                if (type == typeof(Product))
                {
                    transactionBR = new ProductBR(dbContext);

                }
                if (type == typeof(Company))
                {
                    transactionBR = new SizeBR(dbContext);
                }
                if (type == typeof(SizeShoes))
                {
                    transactionBR = new SizesProductsBR(dbContext);
                }
                transactionBR.DeleteModel(Id);
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
                if (type == typeof(Size))
                {
                    return dbContext.Sizes.ToList() as List<T>;
                }
                if (type == typeof(SizeShoes))
                {
                    return dbContext.SizeProduct.ToList() as List<T>;
                }
            }
            catch (Exception err)
            {

            }
            return null;
        }


    }
}
