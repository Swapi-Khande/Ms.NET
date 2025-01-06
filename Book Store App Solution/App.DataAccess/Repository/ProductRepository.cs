using App.DataAccess.Data;
using App.DataAccess.Repository.IRepository;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product pd)
        {
            //_db.Products.Update(pd);
            var objFromDB = _db.Products.FirstOrDefault(u=> u.Id == pd.Id);
            if (objFromDB != null)
            {
                objFromDB.Title = pd.Title;
                objFromDB.ISBN = pd.ISBN;
                objFromDB.Price = pd.Price;
                objFromDB.Price50 = pd.Price50;
                objFromDB.Price100 = pd.Price100;
                objFromDB.Description = pd.Description;
                objFromDB.CategoryID = pd.CategoryID;
                objFromDB.Author = pd.Author;
                if (objFromDB.ImageUrl != null)
                {
                    objFromDB.ImageUrl = pd.ImageUrl;

                }
            }
        }
    }
}
