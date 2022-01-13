using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MvcLayer.Data
{
    public class WebAPi
    {
        static List<Employee> employeelist;

           public static List<Employee> GetEmployee()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:44317/api/employee";
                Uri uri = new Uri(url);
                var response = client.GetAsync(uri);
                if (response.Result.IsSuccessStatusCode)
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    employeelist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(result.Result);
                }
            }
            return employeelist;
        }
      
        public static Employee GetEmployee(int id)
        {
            Employee  emp= null;
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:44317/api/employee/"+id;
                Uri uri = new Uri(url);
                var response = client.GetAsync(uri);
                if (response.Result.IsSuccessStatusCode)
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    emp = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(result.Result);
                }
            }
            return emp;
        }


        internal static bool CreateEmployee(Employee emp)
        {
            bool success = false;
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                string url = "https://localhost:44317/api/employee";
                Uri uri = new Uri(url);
                var response = client.PostAsync(uri,content);
                if (response.Result.IsSuccessStatusCode)
                {
                    success = true;
                }

            }
            return success;
        }

        public static bool EditEmployee(Employee em)
        {
            bool success = false;
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(em);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                string url = "https://localhost:44317/api/employee";
                Uri uri = new Uri(url);
                var response = client.PutAsync(uri, content);
                if (response.Result.IsSuccessStatusCode)
                {
                    success = true;
                }
            }
            return success;
        }

        public static bool Delete(int id)
        {
            bool success = false;
           
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:44317/api/employee/"+id;
                Uri uri = new Uri(url);
                var response = client.DeleteAsync(uri);
                if (response.Result.IsSuccessStatusCode)
                {
                    success = true;
                }
            }
            return success;
        }

        
    }
}