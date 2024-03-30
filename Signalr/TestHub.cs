using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Signalr
{
	public class TestHub : Hub
	{
		private readonly IHubContext<TestHub> _hubContext;

    public TestHub(IHubContext<TestHub> hubContext)
    {
        _hubContext = hubContext;
    }
		// Generic method to broadcast a message to all clients
		public async Task Broadcast(string eventName, object data)
		{
			// Send the message to all clients connected to the hub
			await Clients.All.SendAsync(eventName, data);
		}
	}
}
