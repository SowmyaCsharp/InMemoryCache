using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;
        public SampleDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        /*public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new List<EmployeeModel>();
            output.Add(new() { FirstName = "Sowmya", LastName = "Dhanasekaran" });
            output.Add(new() { FirstName = "Iyappan", LastName = "Dhana" });
            output.Add(new() { FirstName = "Shiva", LastName = "Krishna" });
            Thread.Sleep(3000);
            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new List<EmployeeModel>();
            output.Add(new() { FirstName = "Sowmya", LastName = "Dhanasekaran" });
            output.Add(new() { FirstName = "Iyappan", LastName = "Dhana" });
            output.Add(new() { FirstName = "Shiva", LastName = "Krishna" });
            await Task.Delay(3000);
            return output;
        }*/
        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {
            List<EmployeeModel> output;
            output = _memoryCache.Get<List<EmployeeModel>>("employees");
            if(output is null)
            {
                output = new List<EmployeeModel>();
                output.Add(new() { FirstName = "Sowmya", LastName = "Dhanasekaran" });
                output.Add(new() { FirstName = "Iyappan", LastName = "Dhana" });
                output.Add(new() { FirstName = "Shiva", LastName = "Krishna" });
                await Task.Delay(3000);
            }
            _memoryCache.Set("employees",output,TimeSpan.FromSeconds(60));
            return output;
        }
    }
}
