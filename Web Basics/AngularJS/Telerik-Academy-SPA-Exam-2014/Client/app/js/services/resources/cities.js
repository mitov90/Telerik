app.factory('cities', ['$resource', 'baseServiceUrl', function ($resource, baseServiceUrl) {

            var ServiceResource = $resource(
                    baseServiceUrl + '/api/cities',
                null,
                {
                    'public': {
                        method: 'GET',
                        isArray: true
                    }
                });

            return {
                public: function () {
                    return ServiceResource.public();
                }
            }
        }]);