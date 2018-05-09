
// Attach complex object to scope 

var myApp = angular
    .module("myModule", [])
.controller("myController", function ($scope) {

    var employeeDetail = {

        firstName: 'John',
        lastName: 'Tom',
        age: 28

    };

    $scope.employee = employeeDetail;


});