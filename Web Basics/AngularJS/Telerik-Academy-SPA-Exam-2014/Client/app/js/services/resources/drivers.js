app.factory('driversResource',
    ['$resource', 'authorization', 'baseServiceUrl', 'identity',
        function ($resource, authorization, baseServiceUrl, identity) {

            var headers;
            if (identity.isAuthenticated()) {
                headers = authorization.getAuthorizationHeader();
            }

            var ServiceResource = $resource(
                    baseServiceUrl + '/api/drivers',
                null,
                {
                    'public': {
                        method: 'GET',
                        isArray: true
                    },
                    'byPage': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page'},
                        isArray: true
                    },
                    'byPageAndUsername': {
                        headers: headers,
                        method: 'GET',
                        params: {
                            page: '@page',
                            username: '@username' },
                        isArray: true
                    },
                    'byId': {
                        method: 'GET',
                        params: {id: '@id'},
                        isArray: false,
                        headers: headers,
                        url: baseServiceUrl + '/api/drivers/:id'
                    }
                });

            return {
                public: function () {
                    return ServiceResource.public();
                },
                byPage: function (page) {
                    return ServiceResource.byPage({page:page});
                },
                byPageAndUsername: function (page, username) {
                    return ServiceResource.byPageAndUsername({page: page, username:username});
                },
                byId: function (id) {
                    return ServiceResource.byId({id:id});
                }
            }
        }]);