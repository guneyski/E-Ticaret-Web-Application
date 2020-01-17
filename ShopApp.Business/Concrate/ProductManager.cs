using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrate.EfCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.Business.Concrate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

       

        //EfCoreProductDal _productDal = new EfCoreProductDal();
        public bool Create(Product entity)
        {
            if(Validate(entity))
            {
                _productDal.Create(entity);
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
            //throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
            //throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
            //throw new NotImplementedException();
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productDal.GetByIdWithCategories(id);
            //throw new NotImplementedException();
        }

        public int GetCountByCategory(string category)
        {
            return _productDal.GetCountByCategory(category);
            //throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
            //throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productDal.GetProductsByCategory(category,page,pageSize);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
            //throw new NotImplementedException();
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productDal.Update(entity, categoryIds);
            //throw new NotImplementedException();
        }

        public string ErrorMessage { get ; set ; }

        public bool Validate(Product entity)
        {

            var isValid = true;

            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz";
                isValid = false;
            }

            return isValid;

            //throw new NotImplementedException();
        }
    }
}
