using gRPCSubscriber.SyncDataServices;
using Microsoft.AspNetCore.Mvc;

namespace gRPCSubscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly UserDataClient _userDataClient;

        public SubscriberController(UserDataClient userDataClient)
        {
            _userDataClient = userDataClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _userDataClient.GetUserList();
            return Ok( result);
        }
    }
}

