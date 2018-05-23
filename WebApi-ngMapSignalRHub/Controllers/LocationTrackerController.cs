using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebApi_ngMapSignalRHub.Hubs;

namespace WebApi_ngMapSignalRHub.Controllers
{
    public class LocationTrackerController : ApiController
    {
        [Route("api/LocationTracker/ChangeDeviceLocations")]
        [HttpGet]
        public void ChangeDeviceLocations()
        {
            LocationDetailList locLst = new LocationDetailList();
            var locList = locLst.LocationList;
            foreach (var item in locList)
            {
                HubActions.SendLocationUpdate(item.DeviceId, item.Latitude, item.Longitude);
                Thread.Sleep(5000);
            }
        }
    }
    // Class LocationDetails
    public class LocationDetails
    {
        public string DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    // The Below class is having property named 'LocationList' with get; set; accessors
    public class LocationDetailList
    {
        //  To get data from list
        public List<LocationDetails> LocationList
        {
            get { return locationList; }
        }

        //  Binding data to List i.e., set data to list
        List<LocationDetails> locationList = new List<LocationDetails>()
        {
           new LocationDetails() {
               DeviceId ="1001",
               Latitude =17.4246285829186,
               Longitude =78.3438836269752
           },
            new LocationDetails() {
               DeviceId ="1001",
               Latitude =17.52462858246374,
               Longitude =78.4438836285764
           },
             new LocationDetails() {
               DeviceId ="1001",
               Latitude =17.62462858285758,
               Longitude =78.5438836205945
           },
              new LocationDetails() {
               DeviceId ="1001",
               Latitude =17.72462858854758,
               Longitude =78.6438836636475
           },
               new LocationDetails() {
               DeviceId ="1001",
               Latitude =17.82462857656475,
               Longitude =78.7438836756667
           },
           new LocationDetails() {
               DeviceId ="1001",
               Latitude =18.4246285829186,
               Longitude =79.3438836269752
           },
           new LocationDetails() {
               DeviceId ="1002",
               Latitude =23.4440644,
               Longitude =79.0486879
           },
            new LocationDetails() {
               DeviceId ="1001",
               Latitude =19.4246285829186,
               Longitude =80.3438836269752
           },
              new LocationDetails() {
               DeviceId ="1002",
               Latitude =24.4440644,
               Longitude =80.0486879
           },

    };


    }
}

