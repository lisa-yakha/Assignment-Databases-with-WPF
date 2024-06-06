using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace NeigbourhoodManagementAPI.Controllers
{
    public class ComplaintManagementController : Controller
    {
        private readonly DataServices data;
        public ComplaintManagementController(DataServices myData)
        {
            this.data = myData;
        }

        [Route("/checker")]
        [HttpGet]
        public IActionResult Checker()
        {
            return Ok("API is running");
        }

        [Route("/NewComplaint")]
        [HttpPost]
        public async Task<IActionResult> InsertComplaintAsync([FromBody] Models.ComplaintForm complaint)
        {
            bool result = await data.InsertComplaintAsync(complaint);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Internal error"); ;
            }
        }


        [Route("/AllComplaints")]
        [HttpGet]
        public async Task<ActionResult> AllComplaints()
        {

            var complaints = await data.RetrieveAllComplaints();
            if (complaints == null)
                return BadRequest();
            return Ok(complaints);
        }

        [Route("/ByName")]
        [HttpGet]
        public async Task<ActionResult> ByName([FromQuery] string name)
        {

            var byName = await data.RetrieveComplaintsByNameAsync(name);
            if (byName == null)
                return BadRequest();
            return Ok(byName);
        }

        [Route("/ByDate")]
        [HttpGet]
        public async Task<ActionResult> ByDate([FromQuery] string date)
        {
            if (!DateTime.TryParse(date, out DateTime parsedDate))
                return BadRequest();

            var byDate = await data.RetrieveComplaintsByDateAsync(parsedDate);
            if (byDate == null)
                return BadRequest();
            return Ok(byDate);
        }
        [Route("/NewStatus")]
        [HttpGet]
        public async Task<ActionResult> NewStatus([FromQuery] string id, [FromQuery]int status )
        {

            var newStatus = await data.UpdateStatusAsync(id, status);
            if (newStatus == false)
                return BadRequest();
            return Ok("Complaint is updated");
        }
    }
}
