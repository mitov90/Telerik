'use strict';

app.directive('ciyDirective', function () {
    return {
        scope: {
            cities: '=cities'
        },
        templateUrl: '../../views/directives/cities.html'
    };
});