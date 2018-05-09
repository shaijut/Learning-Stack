
var myApp = angular.module("MyModule", [])
            .controller("MyController", function ($scope) {

                // model 1

                $scope.userName = "Mat";


                // model 2

                $scope.employee =
                    {

                        firstName: "John",
                        lastName: "Tom",
                        age: "28"
                    };


            });