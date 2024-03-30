using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace test
{
	[HubName("chat")]
	public class ChatHub : Hub
	{
		public void sendMessage(string name, string mess)
		{
			 Clients.All.newMessage(name, mess);
		}
	}
}