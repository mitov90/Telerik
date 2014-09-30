'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']);

var routeUserChecks = {
    authenticated: {
        authenticate: function(auth) {
            return auth.isAuthenticated();
        }
    }
};

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'views/partials/home.html',
            controller: 'HomeCtrl'
        })
        .when('/drivers/:id', {
            templateUrl: '../views/partials/driver-details.html',
            controller: 'DriverInfoCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/drivers/', {
            templateUrl: 'views/partials/drivers.html',
            controller: 'DriverCtrl'
        })
        .when('/trips/create', {
            templateUrl: 'views/partials/create-trip.html',
            controller: 'TripsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/trips/:id', {
            templateUrl: 'views/partials/trip-details.html',
            controller: 'TripDetailsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/trips', {
            templateUrl: 'views/partials/trips.html',
            controller: 'TripsCtrl'
        })
        .when('/unauthorized', {
            templateUrl: 'views/partials/home.html'
        })
        .when('/register', {
            templateUrl: 'views/partials/register.html',
            controller: 'SignUpCtrl'
        })
        .otherwise({ redirectTo: '/' });
}])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');

app.run(function ($rootScope, $location ) {
    $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/#/unauthorized');
        }
    })
});