using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : ControllerBase
    {

        // GET /status
        [HttpGet("status")]
        public StatusResponse GetTheStatus()
        {
            return new StatusResponse
            {
                Message = "we did it",
                LastChecked = DateTime.Now
            };
        }

        // GET /customers/{customerid}
        // GET /customers/(anything that is an int)
        [HttpGet("customers/{customerId:int}")]
        public ActionResult GetInfoAboutCustomer(int customerId)
        {
            return Ok($"Getting info about customer: {customerId}");
        }

        [HttpGet("blogs/{year:int}/{month:int:min(1):max(12)}/{day:int}")]
        public ActionResult GetBlogPosts(int year, int month, int day)
        {
            return Ok($"Getting blogs for {month} - {day} - {year}");
        }

        // GET /employees
        [HttpGet("employees")]
        public ActionResult GetEmployees([FromQuery] string department = "All")
        {
            var response = new GetEmployeeReponse
            {
                Data = new List<string> { "Joe", "Sue", "Mary" },
                Department = department
            };
            return Ok(response);
        }

        [HttpGet("whoami")]
        public ActionResult GetWhoAmI([FromHeader(Name = "User-Agent")]string userAgent)
        {
            return Ok($"I have no idea, but you are running {userAgent}");
        }
    }

    public class GetEmployeeReponse
    {
        public List<string> Data { get; set; }
        public string Department { get; set; }
    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
