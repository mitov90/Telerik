app.factory('tripResource',
    ['$resource', 'authorization', 'baseServiceUrl', 'identity',
        function ($resource, authorization, baseServiceUrl, identity) {

            var headers;
            if (identity.isAuthenticated()) {
                headers = authorization.getAuthorizationHeader();
            }

            var ServiceResource = $resource(
                    baseServiceUrl + '/api/trips',
                null,
                {
                    'public': {
                        method: 'GET',
                        isArray: true
                    },
                    'create': {
                        method: 'POST',
                        headers: headers
                    },
                    'byId': {
                        method: 'GET',
                        params: { id: '@id' },
                        isArray: false,
                        url: baseServiceUrl + '/api/trips/:id',
                        headers: headers
                    },
                    'join': {
                        method: 'PUT',
                        headers: headers,
                        url: baseServiceUrl + '/api/trips/:id',
                        params: { id: '@id' }
                    },
                    'byPage': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page'},
                        isArray: true
                    },
                    'byPageAndOrder': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page',
                            orderBy: '@orderBy',
                            orderType: '@orderType'
                        },
                        isArray: true
                    },
                    'fromTownToTown': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page',
                            from: '@from',
                            to: '@to'
                        },
                        isArray: true
                    },
                    'finished': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page',
                            finished: '@finished'
                        },
                        isArray: true
                    },
                    'userTrips': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page',
                            onlyMine : '@onlyMine '
                        },
                        isArray: true
                    }
                });

            return {
                public: function () {
                    return ServiceResource.public();
                },
                create: function (trip) {
                    return ServiceResource.create(trip);
                },
                byId: function (id) {
                    return ServiceResource.byId({id: id});
                },
                byPage: function (page) {
                    return ServiceResource.byPage({page: page});
                },
                join: function (id) {
                    return ServiceResource.join({id: id});
                },
                byPageAndOrder: function (page, orderBy, orderType) {
                    return ServiceResource.byPageAndOrder({page: page, orderBy: orderBy, orderType: orderType});
                },
                fromTownToTown: function (page, from, to) {
                    return ServiceResource.fromTownToTown({page: page, from: from, to: to});
                },
                finished: function (page) {
                    return ServiceResource.finished({page: page, finished: true});
                },
                userTrips: function (page) {
                    return ServiceResource.finished({page: page, onlyMine: true});
                }
            }
        }]);