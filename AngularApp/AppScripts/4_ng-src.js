
// ng src directive


var myApp = angular.module("MyModule", [])
            .controller("myController", function ($scope) {

                var countryModel = {

                    name: "India",
                    capital: "New Delhi",
                    flag: "/Content/Images/218px-Flag_of_India.png"
                };


                $scope.country = countryModel;



            });