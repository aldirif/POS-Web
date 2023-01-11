using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductEntity> Get()
        {
            return _context.productEntities.ToList();
        }

        public void Add(ProductEntity product)
        {
            _context.productEntities.Add(product);
            _context.SaveChanges();
        }

        public ProductEntity View(int? id)
        {
            var customer = _context.productEntities.Find(id);
            return customer;
        }

        public void Update(ProductEntity product)
        {
            _context.productEntities.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var customer = View(id);

            _context.productEntities.Remove(customer); 
            _context.SaveChanges();
        }


    }
}
