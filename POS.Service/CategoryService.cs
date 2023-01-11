using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POS.Repository;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoryEntity> GetCategories()
        {
            return _context.categoryEntities.ToList();
        }

        public CategoryEntity Add(CategoryEntity category)
        {
            try
            {
                _context.categoryEntities.Add(category);
                _context.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
