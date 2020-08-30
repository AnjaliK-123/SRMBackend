using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using UserRegistration2.Services;

namespace UserRegistration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepo _repository;
        private readonly object departmentItems;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartment()
        {
            var departmentItems = _repository.GetDepartment();
            return Ok(departmentItems);
        }

       
     
    }
}
