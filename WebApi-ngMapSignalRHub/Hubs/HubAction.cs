using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_ngMapSignalRHub.Hubs
{
    public class HubActions
    {
        private static Microsoft.AspNet.SignalR.IHubContext GetDeviceHub()
        {
            return Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<LocationTrackHub>();
        }

        public static void SendLocationUpdate(string DeviceId, double latitude, double longitude)
        {

            GetDeviceHub().Clients.Group(DeviceId).getDeviceLocation(latitude, longitude);
        }
    }
}