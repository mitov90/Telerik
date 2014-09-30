'use strict';

app.controller('DriverInfoCtrl', ['$scope', 'driversResource', 'tripResource', 'notifier', 'identity', '$routeParams',
    function ($scope, driversResource, tripResource, notifier, identity, $routeParams) {
        $scope.isAuthenticated = false;
        $scope.mine = false;
        $scope.other = false;
        $scope.myId = identity.getCurrentUser().id;
        console.log($scope.myId)
        getDriverTrips();

        function getDriverTrips() {
            driversResource.byId($routeParams.id).$promise.then(function (data) {
                $scope.driver = data;
                $scope.trips = data.trips;
            }, function (error) {
                notifier.error("No such driver " + error.statusText);
            });
        }


    }]);