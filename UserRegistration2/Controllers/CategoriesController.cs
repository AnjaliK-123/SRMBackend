using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Services;
//using SRMAPI.Dtos;
using UserRegistration2.Models;

namespace UserRegistration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _repository;
        private readonly object categoryItems;
       

        public CategoriesController(ICategoryRepo repository)
        {
            _repository = repository;
          
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            var categoryItems = _repository.GetCategory();
            return Ok(categoryItems);
        }

       
        }
    }
