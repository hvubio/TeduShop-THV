var myApp = angular.module("myModule", []);

myApp.controller("schoolController", schoolController);
//myApp.controller("studentController", studentController); 
//myApp.controller("teacherController", teacherController);
myApp.service("validatorService", validatorService);
myApp.directive("teduShopDirective", teduShopDirective);
//studentController.$inject = ["$scope"];
//teacherController.$inject = ["$scope"];
schoolController.$inject = ["$scope", "validatorService"];

//declare Controller
function schoolController($scope, validatorService) {
    //binlding event
    $scope.checkNumber = function() {
        $scope.message = validatorService.checkNumber($scope.num);
    }
     
}


// service
function validatorService($window) {
    return {
        checkNumber : checkNumber
    }
    function checkNumber(input) {
        if (input % 2 === 0) {
            return "this is even";
        } else {
            return "this is odd";
        }
    }
}

//Controller

//function studentController($scope) {
//    $scope.message = "This is student message from controller";
//}

//function teacherController($scope) {
//   $scope.message = "This is teacher messange from controller";
//}

//Directives
function teduShopDirective() {
    return {
        templateUrl: "/Scripts/spa/teduShopDirective.html"
    }
    
}