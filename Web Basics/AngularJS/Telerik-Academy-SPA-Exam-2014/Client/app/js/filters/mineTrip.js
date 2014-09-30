'use strict';

app.filter('mineTrip', function() {
    return function(trip,myId) {
        if (trip.driverId == myId){
            return trip;
        }
    }
});