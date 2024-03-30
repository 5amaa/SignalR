using Microsoft.AspNetCore.SignalR;

namespace Signalr
{
	public class TestHub: Hub
	{
		public  async Task Broadcast(string eventName, object data)
		{
			await Clients.All.SendAsync(eventName, data);
		}
		public async Task<string> GetConnectionId()
		{
			return Context.ConnectionId;
		}
	}
}
