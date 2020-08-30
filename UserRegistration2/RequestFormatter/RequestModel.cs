using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;

namespace UserRegistration2.RequestFormatter
{
    public class RequestModel
    {
        private readonly SRMContext _context;

        public RequestModel(SRMContext context)
        {
            _context = context;
        }
        public string RequestId { get; set; }
        public string Title { get; set; }

        public string RequestDepartment { get; set; }
        public string RequestCategory { get; set; }
        public string RequestSubCategory { get; set; }
        public string RequestStatus { get; set; }
        public int RequestDepartmentId { get; set; }
        public int RequestCategoryId { get; set; }
        public int RequestSubCategoryId { get; set; }
        public int RequestStatusId { get; set; }
        public string RequestSummary { get; set; }

        public string RequestType { get; set; }
        public int RequestTypeId { get; set; }

        public int CreatedEmpId { get; set; }
        public int AssignedEmpId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public string Comment { get; set; }

        public void CopyData(Request request)
        {
          


            this.RequestId = request.Id.ToString();
            this.Title = request.Title;
            this.RequestStatus = _context.Status.FirstOrDefault(n => n.Id == request.StatusId).Status1;
            this.RequestType = _context.RequestTypes.FirstOrDefault(n => n.Id == request.RequestTypeId).RequestType1;
            this.RequestDepartment = _context.Department.FirstOrDefault(n => n.Id == request.DepartmentId).Name;
            this.RequestCategory = _context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Name;
            this.RequestSubCategory = _context.Category.FirstOrDefault(n => n.Id == request.SubCategoryId).Name;
            this.RequestStatusId = _context.Status.FirstOrDefault(n => n.Id == request.StatusId).Id;
            this.RequestTypeId = _context.RequestTypes.FirstOrDefault(n => n.Id == request.RequestTypeId).Id;
            this.RequestDepartmentId = _context.Department.FirstOrDefault(n => n.Id == request.DepartmentId).Id;
            this.RequestCategoryId = _context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Id;
            this.RequestSubCategoryId = _context.Category.FirstOrDefault(n => n.Id == request.SubCategoryId).Id;
            this.RequestSummary = request.Summary;
            this.Title = request.Title;
            this.CreatedOn = request.CreatedOn;
            this.LastModifiedOn = request.LastModifiedOn;
            this.CreatedEmpId = _context.Employees.FirstOrDefault(n => n.Id == request.CreatedEmpId).Id;
           this.AssignedEmpId = request.AssignedEmpId;
            this.LastModifiedBy = request.LastModifiedBy;
            

        }

       





    }

}

