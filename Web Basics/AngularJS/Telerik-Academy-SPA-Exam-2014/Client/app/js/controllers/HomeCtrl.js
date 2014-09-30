'use strict';

app.controller('HomeCtrl', ['$scope', 'driversResource', 'tripResource', 'statsResource', 'notifier', function ($scope, driversResource,tripResource, statsResource, notifier) {
    $scope.isAuthenticated=false;

    // caching the data
    if (window.basicStats == undefined) {
        statsResource.public().$promise.then(function (data) {
            window.basicStats = data;
            $scope.stats = data;
        }, function (data) {
            notifier.error(data);
        })
    }
    else {
        $scope.stats = window.basicStats
    }

    driversResource.public().$promise.then(function (data) {
        $scope.drivers = data;
    }, function (error) {
        notifier.error("Error getting drivers " + error.statusText);
    });

    tripResource.public().$promise.then(function(data){
        $scope.trips = data;
    }, function (error) {
        notifier.error("Error getting trips " + error.statusText);
    });

}]);