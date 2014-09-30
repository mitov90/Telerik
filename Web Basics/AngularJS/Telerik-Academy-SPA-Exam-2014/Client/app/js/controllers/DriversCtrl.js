'use strict';

app.controller('DriverCtrl', ['$scope', 'driversResource', 'notifier', 'identity', function($scope, driversResource, notifier,identity ) {
    $scope.isAuthenticated=identity.isAuthenticated();

    driversResource.byPage(1).$promise.then(function (data) {
        $scope.drivers = data;
    }, function (error) {
        notifier.error("Error getting drivers " + error.statusText);
    });


    $scope.searchUsername = function (page,search) {
        driversResource.byPageAndUsername(page,search).$promise.then(function (data) {
            $scope.drivers = data;
        }, function (error) {
            notifier.error("Error getting drivers " + error.statusText);
        })
    }
    }]);