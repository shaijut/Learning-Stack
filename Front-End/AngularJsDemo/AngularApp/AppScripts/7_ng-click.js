

var myApp = angular.module("MyModule", [])
            .controller("MyController", function ($scope) {

                var technologiesModel = [

                    { name: "C#", likes: 0, dislikes: 0 },
                    { name: "ASP.NET", likes: 0, dislikes: 0 },
                    { name: "SQL", likes: 0, dislikes: 0 },
                    { name: "Java", likes: 0, dislikes: 0 },
                    { name: "Angular JS", likes: 0, dislikes: 0 }
                ];

                $scope.technologies = technologiesModel;

                // likes function

                $scope.incrementLikes = function (technolgy) {

                    technolgy.likes++;
                };

                // dislikes function

                $scope.incrementDislikes = function (technology) {

                    technology.dislikes++;
                };


            });