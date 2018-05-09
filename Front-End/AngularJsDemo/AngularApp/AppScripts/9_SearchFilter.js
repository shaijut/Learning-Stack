
var myApp = angular.module("MyModule", [])
            .controller("MyController", function ($scope) {

                var employeesModel = 
                     [
                { name: "Ben", gender: "Male", salary: 55000, city: "London" },
                { name: "Sara", gender: "Female", salary: 68000, city: "Chennai" },
                { name: "Mark", gender: "Male", salary: 57000, city: "London" },
                { name: "Pam", gender: "Female", salary: 53000, city: "Chennai" },
                { name: "Todd", gender: "Male", salary: 60000, city: "London" },
                     ];

                $scope.employees = employeesModel;

            });