using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using UserRegistration2.Services;
using System.Data.SqlClient;
using ServiceRequestManagement.RequestFormatter;
using UserRegistration2.RequestFormatter;
using UserRegistration2.Services.Implementations;


namespace UserRegistration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly SRMContext _context;
        private readonly IRequestRepo _repository;
      
        
        public RequestsController(IRequestRepo repository, SRMContext context)
        {
            _repository = repository;
            _context = context;
        }

   
        //GET : api/ Requests
        [HttpGet]
        public ActionResult GetRequests()
        {
            var allRequest = _repository.GetRequests();
            List<RequestModel> objList = new List<RequestModel>();


            foreach (var request in allRequest)
            {

                RequestModel obj = new RequestModel(_context);
                obj.CopyData(request);

                objList.Add(obj);

            }
            return Ok(objList);
        }

      


        // POST: api/Requests
       
        [HttpPost]
        public ActionResult<Request> CreateRequest(Request createRequest)
        {
          
            _repository.CreateRequest(createRequest);
            _repository.SaveChanges();
           
            return createRequest;
        }

      


    }
}

