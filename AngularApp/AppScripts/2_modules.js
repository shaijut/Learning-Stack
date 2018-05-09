
// create module

var myApp = angular.module("myModule", []);

// Register controller with module

myApp.controller("myController", function ($scope) {

    $scope.helloMessage = "Hello using module";

})