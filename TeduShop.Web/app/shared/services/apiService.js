(function(app) {
    app.service("apiService", apiService);

    apiService.$inject = ["$http"];

    function apiService() {
        return {
            get: get
        };

        function get(url, params, succsess, failure) {
            $http.get(url, params).then(function(result) {
                    succsess(result);
                },
                function(error) {
                    failure(error);
                });
        }
    };
})(angular.module("tedushop.common"));