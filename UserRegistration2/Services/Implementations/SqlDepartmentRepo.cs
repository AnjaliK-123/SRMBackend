using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
    public class SqlDepartmentRepo : IDepartmentRepo

    {
        private readonly SRMContext _context;
        public SqlDepartmentRepo(SRMContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Department> GetDepartment()
        {
            return _context.Department.ToList();
        }

   
    }
}
