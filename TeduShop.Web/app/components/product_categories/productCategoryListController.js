(function(app) {
    app.controller("productCategoryListController", productCategoryListController);

    productCategoryListController.$inject = ["$scope", "apiService","notificationService"];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = "";

        $scope.getProductCategories = getProductCategories;
        $scope.search = search;

        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            };

            apiService.get("/api/productcategory/getall",
                config,
                function (result) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning("Không tìm thấy bản ghi nào");
                    } else {
                        notificationService.displaySuccess("Tìm thấy " + result.data.TotalCount + " bản ghi.");
                    }
                    $scope.productCategories = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPage;
                    $scope.totalCount = result.data.TotalCount;
                },
                function() {
                    console.log("Log product category failed");
                });
        }

        $scope.getProductCategories();
    }
})(angular.module("tedushop.productCategory"))