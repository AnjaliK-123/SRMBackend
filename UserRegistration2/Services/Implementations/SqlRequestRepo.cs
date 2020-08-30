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
      


        public SqlRequestRepo(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public void CreateRequest(Request request)
        {
            var context = new SRMContext();
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
           context.Request.Add(request);
           context.SaveChanges();


            var email1 = context.Employees.FirstOrDefault(e => e.Id == request.CreatedEmpId).EmailId;
           var AdminEmail = context.Employees.FirstOrDefault(e => e.DepartmentId == request.DepartmentId && e.RoleId == (context.Roles.FirstOrDefault(r => r.Role1.Equals("Admin")).Id)).EmailId;
            string sub = "Service Request";
            string content = "Request Created!" +
                            "\nRequest Id: " + request.Id +
                                "\nRequest Created by: " + context.Employees.FirstOrDefault(e => e.Id == request.CreatedEmpId).FirstName +
                                "\nDepartment: " + context.Department.FirstOrDefault(d => d.Id == request.DepartmentId).Name +
                                 "\nCategory: " + context.Category.FirstOrDefault(c => c.Id == request.CategoryId).Name +
                                  "\nSubcategory: " + context.Category.FirstOrDefault(s => s.Id == request.SubCategoryId).Name +
                                  "\nTitle :" + request.Title +
                                  "\nSummary :" + request.Summary;



            

            var message = new Message(new string[] { email1, AdminEmail }, sub, content);
            emailSender.SendEmail(message);
           
        }
       



       
        public List<Request> GetRequests()
        {

            var context = new SRMContext();
        return context.Request.ToList();
        }

      
       
    }
}

