
var myApp = angular.module("MyModule", []);


myApp.controller("MyController", function ($scope, mathService) {

    $scope.additon = function () {


        $scope.additionResult = mathService.AddTwoNumbers($scope.inputX, $scope.inputY);

     
    };

    $scope.additionResult = "Empty";
});