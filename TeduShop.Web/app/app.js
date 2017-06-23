(function() {
    angular.module("tedushop", ["tedushop.common","tedushop.products","tedushop.productCategory"]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("home",
            {
                url: "/admin",
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise("/admin");
    }
})();