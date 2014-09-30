'use strict';

app.controller('TripDetailsCtrl', ['$scope', 'tripResource', 'notifier', 'identity', '$routeParams', '$location',
    function ($scope, tripResource, notifier, identity, $routeParams, $location) {

        tripResource.byId($routeParams.id).$promise.then(function (data) {
            $scope.trip = data;
        }, function (error) {
            notifier.error("Not existing trip with that id " + error.statusText);
            $location.path('#/trips');
        });


        $scope.join = function () {
            if ($scope.trip.numberOfFreeSeats < 1) {
                notifier.error("No free seats on this trip");
                return;
            }

            tripResource.join($scope.trip.id).$promise.then(function () {
                    notifier.success("You have joined a trip");
                    $location.path('$/trips');
                },
                function (error) {
                    notifier.error("Cannot join to this trip" + error.statusText);
                })
        }
    }]);