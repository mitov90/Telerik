'use strict';

app.controller('TripsCtrl', ['$scope', 'cities', 'tripResource', 'notifier', 'identity', '$location',
    function ($scope, cities, tripResource, notifier, identity,$location) {
        $scope.isAuthenticated=identity.isAuthenticated();
        $scope.me = false;

        $scope.filters = ['driver', 'date', 'number of seats' , 'from' ,'to'  ];
        $scope.orders = ['desc','asc']
        tripResource.public().$promise.then(function (data) {
            $scope.trips=data;
        }, function (error) {
            notifier.error("Cannot get trips " + error.statusText);
        });

        cities.public().$promise.then(function (data) {
            $scope.cities = data;
        }, function (error) {
            notifier.error("Cannot get cities " + error.statusText);
        });

        $scope.create = function (trip) {
            tripResource.create(trip).$promise.then(function () {
                notifier.success("You created a new trip");
                    $location.path('#/trips');
            },
                function (error) {
                    notifier.error('Cannot create a trip')
                })
        };

        $scope.filter = function (request) {
            tripResource.byPageAndOrder()
        };
        
        $scope.byCity = function (page, from,to) {
            tripResource.fromTownToTown(page,from,to).$promise.then(function (data) {
                $scope.trips=data;
            }, function (error) {
                notifier.error("Cannot filter that")
            })
        };
        $scope.onlyMe = function (page) {
            if ($scope.me == false) {
                tripResource.userTrips(page).$promise.then(function (data) {
                    $scope.trips = data;
                }, function () {
                    notifier.error("Cannot filter that");
                    $scope.me = true;
                })
            }
            else {
                $scope.me = false;
                tripResource.public().$promise.then(function (data) {
                    $scope.trips=data;
                });
            }
        }
        $scope.filter = function (page,request) {
            tripResource.byPageAndOrder(page,request.orderBy,request.orderType).$promise.then(function (data) {
                $scope.trips=data;
            });
        }

    }]);