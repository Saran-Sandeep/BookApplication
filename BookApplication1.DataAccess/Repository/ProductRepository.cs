using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookApplication1.DataAccess.Data;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;

namespace BookApplication1.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            //_db.Products.Update(product);
            Product? productFromDb = _db.Products.FirstOrDefault(prod => prod.Id == product.Id);
            if (productFromDb != null) 
            {
                productFromDb.Name = product.Name;
                productFromDb.Description = product.Description;
                productFromDb.Author = product.Author;
                productFromDb.Price = product.Price;
                productFromDb.Quantity = product.Quantity;
                productFromDb.PublishedDate = product.PublishedDate;
                productFromDb.EditionNum = product.EditionNum;
                productFromDb.Rating  = product.Rating;
                productFromDb.ISBN = product.ISBN;
                productFromDb.UpdatedAt = product.UpdatedAt;
                productFromDb.CategoryId = product.CategoryId;
                if (product.ImageURL != null)
                {
                    productFromDb.ImageURL = product.ImageURL;
                }
            }
                
        }
    }
}
