using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
    public class SqlCategoryRepo : ICategoryRepo
    {
        private readonly SRMContext _context;

        public SqlCategoryRepo(SRMContext context)
        {
            _context = context;
        }


        public IEnumerable<Category> GetCategory()
        {
            return _context.Category.ToList();
        }

       
       
    }
}
