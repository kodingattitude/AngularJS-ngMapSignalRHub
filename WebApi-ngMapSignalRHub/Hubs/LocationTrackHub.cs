using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_ngMapSignalRHub.Hubs
{
    public class LocationTrackHub :Hub
    {
        public override Task OnConnected()
        {

            Clients.Caller.hello("Hello!");
            return base.OnConnected();
        }
        public void addDeviceToGroup(string deviceid)
        {
            Groups.Add(Context.ConnectionId, deviceid);
        }
        public void removeDeviceFromGroup(string deviceid)
        {
            Groups.Remove(Context.ConnectionId, deviceid);

        }
    }
}