

var myApp = angular.module("MyModule", [])
                    .controller("MyController", function
                         ($scope, $location, $anchorScroll) {
                        $scope.scrollTo = function (scrollLocation) {
                            $location.hash(scrollLocation);
                            $anchorScroll.yOffset = 20;
                            $anchorScroll();
                        }
                    });