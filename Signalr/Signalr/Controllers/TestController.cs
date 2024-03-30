using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Signalr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHubContext<TestHub> _hubContext;

        public TestController(IHubContext<TestHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("MoveNext")]
        public async Task<int> Move(int x, int y)
        {
            y = x + 2;
            object d = y;

            // Use _hubContext to access TestHub instance
            await _hubContext.Clients.All.SendAsync("TicketUpdated", d);

            return 0; // Return a value here if necessary
        }

		//[HttpGet("ConnectionId")]
		//public async Task<IActionResult> GetConnectionId()
		//{
		//	// Generate or retrieve the connection ID
		//	string connectionId = await GenerateConnectionId(); // Implement this method to generate or retrieve the connection ID

		//	// Start SignalR connection here (if needed)
		//	// ...

		//	// Return the connection ID to the client
		//	return Ok(new { ConnectionId = connectionId });
		//}

		//// Implement the method to generate or retrieve the connection ID
		//private Task<string> GenerateConnectionId()
		//{
		//	// Implement your logic here to generate or retrieve the connection ID
		//	// For example, you can generate a unique ID using Guid.NewGuid() method
		//	string connectionId = Guid.NewGuid().ToString();

		//	return Task.FromResult(connectionId);
		//}
	}
}
