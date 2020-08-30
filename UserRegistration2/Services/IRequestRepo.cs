using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services
{
   public interface IRequestRepo
    {
       
       
       List<Request> GetRequests();

        void CreateRequest(Request request);

      
    }
}
