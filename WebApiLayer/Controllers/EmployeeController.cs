using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiLayer.Models;

namespace WebApiLayer.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employeelist;
        Employee employee;
        public List<Employee> Get()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                employeelist = db.EmployeeTable.ToList();
            }
            return employeelist;
        }
        public Employee Get(int id)
        {
            using(EmployeeDbContext db = new EmployeeDbContext())
            {
                employee = db.EmployeeTable.FirstOrDefault(x => x.id.Equals(id));
            }
            return employee;
        }
        public HttpResponseMessage Post([FromBody]Employee data)
        {
            HttpResponseMessage response;

            try
            {
                using (EmployeeDbContext emp = new EmployeeDbContext())
                {
                    emp.EmployeeTable.Add(data);
                    emp.SaveChanges();

                }
                response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        public HttpResponseMessage Put([FromBody] Employee data)
        {
            try
            {
                using(EmployeeDbContext db = new EmployeeDbContext())
                {
                    var update = db.EmployeeTable.FirstOrDefault(x => x.id.Equals(data.id));
                    if (update!=null)
                    {    
                        update.name = data.name;
                        update.designation = data.designation;
                    }
                    db.SaveChanges();
                }
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
                return message;
            }
            catch
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return message;
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDbContext db = new EmployeeDbContext())
                {
                    var update = db.EmployeeTable.FirstOrDefault(x => x.id.Equals(id));
                    if (update != null)
                    {

                        db.EmployeeTable.Remove(update);
                        db.SaveChanges();
                    }
                }
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;            
            }
            catch
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

    }
}
