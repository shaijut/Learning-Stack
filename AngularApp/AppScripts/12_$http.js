

var myApp = angular.module("MyModule", [])
            .controller("MyController", function ($scope, $http, $log) {

                //$http.get("http://localhost:53155/api/products/GetAllProducts")
                //      .then(function (response) {

                //          $scope.products = response.data;

                //          $log.info(response);

                //      });

                var successCallBack = function (response) {
                    $scope.products = response.data;
                };

                var errorCallBack = function (reason) {
                    $scope.error = reason.data;
                }

                $scope.products = $http.get('http://localhost:53155/api/products/GetAllProducts')
                                        .then(successCallBack, errorCallBack);


            });