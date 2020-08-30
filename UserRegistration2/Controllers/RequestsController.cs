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
       
        private readonly IRequestRepo _repository;
        private readonly object requestItems;
        private readonly IRequestService _service;
        
        public RequestsController(IRequestRepo repository,  IRequestService service)
        {
            _repository = repository;
            _service = service;
     
        }

   
        
        
        [HttpGet]
        public ActionResult GetRequests()
        {
            var allRequest = _repository.GetRequests();
            List<RequestModel> objList = new List<RequestModel>();


            foreach (var request in allRequest)
            {

                RequestModel obj = new RequestModel();
                obj.CopyData(request);

                objList.Add(obj);

            }
            return Ok(objList);
        }

      


        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Request> CreateRequest(Request createRequest)
        {
            SRMContext context = new SRMContext();
            _repository.CreateRequest(createRequest);
            context.SaveChanges();
            return createRequest;
        }

      


    }
}

