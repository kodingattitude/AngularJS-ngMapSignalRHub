var locapp = angular.module('angulargooglemaplocationtrackApp', ['ngMap','SignalR']);
locapp.controller('locationtrackerCtrl', ['$scope', '$http', 'Hub', 'NgMap', function ($scope, $http, Hub, NgMap) {
    var serviceBasePath = 'http://localhost:58171';
    var maplocation = this;
    NgMap.getMap().then(function (map) {
        maplocation.map = map;
    });
    maplocation.googleMapsUrl = "https://maps.googleapis.com/maps/api/js?key=AIzaSyC7QgeORUjgqSFlvmr9kT2mh8beqqB4buw";

    
    maplocation.startPoint = "";
    maplocation.devicePoint = "";
    maplocation.positions = [];
    maplocation.data = []
    maplocation.center = "23.4440644, 79.0486879";
    maplocation.zoom = 4;

    var devId = "";
    maplocation.drawMap = function () {
        i = 1;
        maplocation.devicePoint = "";
        console.log(maplocation.deviceId);
        if (devId) {
            hub.removeDeviceFromGroup(devId);
        }
        hub.addDeviceToGroup(maplocation.deviceId);
        devId = maplocation.deviceId;
        $http.get(serviceBasePath + '/api/LocationTracker/ChangeDeviceLocations', {
            params: { deviceId: maplocation.deviceId }
        }).then(
            function (response) {

            }, function (error) {
                //console.log(error);
            });


    }

    var i = 1;

    //Hub setup
    var hub = new Hub('LocationTrackHub', {
        listeners: {
            'getDeviceLocation': function (lat, lng) {
                var position = "[" + lat + "," + lng + "]";
                maplocation.devicePoint = position;
                // maplocation.positions.push(position);
                if (i == 1) {
                    maplocation.zoom = 8;
                    maplocation.center = position;
                    i++;
                }
                $scope.$apply();
            }

        },
        rootPath: serviceBasePath + '/signalr',
        methods: ['addDeviceToGroup', 'removeDeviceFromGroup'],
        errorHandler: function (error) {
            console.error(error);
        }
    });

}]);