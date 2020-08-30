using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ServiceRequestManagment.Models;
using UserRegistration1.Models;

namespace UserRegistration2.Services.Implementations
{
    public class SqlRequestRepo : IRequestRepo
    {
    
        private readonly IEmailSender emailSender;
        private readonly SRMContext _context;


        public SqlRequestRepo(IEmailSender emailSender, SRMContext context)
        {
            this.emailSender = emailSender;
            _context = context;
        }

        public void CreateRequest(Request request)
        {
           
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
           _context.Request.Add(request);
           _context.SaveChanges();


            var email1 = _context.Employees.FirstOrDefault(e => e.Id == request.CreatedEmpId).EmailId;
           var AdminEmail = _context.Employees.FirstOrDefault(e => e.DepartmentId == request.DepartmentId && e.RoleId == (_context.Roles.FirstOrDefault(r => r.Role1.Equals("Admin")).Id)).EmailId;
            string sub = "Service Request";
            string content = "Request Created!" +
                            "\nRequest Id: " + request.Id +
                                "\nRequest Created by: " + _context.Employees.FirstOrDefault(e => e.Id == request.CreatedEmpId).FirstName +
                                "\nDepartment: " + _context.Department.FirstOrDefault(d => d.Id == request.DepartmentId).Name +
                                 "\nCategory: " + _context.Category.FirstOrDefault(c => c.Id == request.CategoryId).Name +
                                  "\nSubcategory: " + _context.Category.FirstOrDefault(s => s.Id == request.SubCategoryId).Name +
                                  "\nTitle :" + request.Title +
                                  "\nSummary :" + request.Summary;



            

            var message = new Message(new string[] { email1, AdminEmail }, sub, content);
            emailSender.SendEmail(message);
           
        }


        public bool SaveChanges()
        {

            return (_context.SaveChanges() >= 0);
        }


        public List<Request> GetRequests()
        {

        return _context.Request.ToList();

        }
       


      
       
    }
}

