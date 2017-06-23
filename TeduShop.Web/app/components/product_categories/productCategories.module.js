(function() {
    angular.module("tedushop.productCategory", ["tedushop.common"]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("productCategories",
            {
                url: "/productCategories",
                templateUrl: "/app/components/product_categories/productCategoryListView.html",
                controller: "productCategoryListController"
            }).state("productCategory_add",
            {
                url: "/productCategory_add",
                templateUrl: "app/components/product_categories/productCategoryAddView.html",
                controller: "productCategoryAddController"
            });
    };
})();