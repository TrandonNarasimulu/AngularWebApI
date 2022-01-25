using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public ActionResult<string> IsAlive()
        {
            return "Service is alive!";
        }
    }
}
