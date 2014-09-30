app.factory('statsResource', ['$resource', 'baseServiceUrl',
    function($resource, baseServiceUrl) {

        var ServiceResource = $resource(
                baseServiceUrl + '/api/stats',
            null,
            {
                'public': {
                    method: 'GET',
                    isArray: false
                }
            }
        );
        return {
            public: function() {
                return ServiceResource.public();
            }
        };
    }]);