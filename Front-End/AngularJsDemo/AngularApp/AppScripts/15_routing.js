/// <reference path="C:\Users\shaiju.ts\Documents\Visual Studio 2015\Projects\AngularJsDemo\AngularJsDemo\Scripts/angular.min.js" />
/// <reference path="C:\Users\shaiju.ts\Documents\Visual Studio 2015\Projects\AngularJsDemo\AngularJsDemo\Scripts/angular-route.min.js" />


var app = angular
           .module("MyModule", ["ngRoute"])
           .config(function ($routeProvider, $locationProvider) {
               $routeProvider
                   .when("/home", {
                       templateUrl: "/AngularApp/Templates/home.html",
                       controller: "homeController"
                   })
                   .when("/courses", {
                       templateUrl: "/AngularApp/Templates/courses.html",
                       controller: "coursesController"
                   })
                   .when("/products", {
                       templateUrl: "/AngularApp/Templates/products.html",
                       controller: "productsController"
                   })
                   .when("/product-details/:id", { // route params
                      templateUrl: "/AngularApp/Templates/productDetails.html",
                      controller: "productDetailsController"
                      })
                   .otherwise({
                       redirectTo: "/home"
                   })

               $routeProvider.caseInsensitiveMatch = false;

               // to remove # from url

               $locationProvider.html5Mode(true);

           })
           .controller("homeController", function ($scope) {
               $scope.message = "Home Page";
           })
           .controller("coursesController", function ($scope) {
               $scope.courses = ["C#", "VB.NET", "ASP.NET", "SQL Server"];
           })
            .controller("productsController", function ($scope, $http, $route, $log) {


         
                //  reload just the current route

                $scope.reloadProducts = function () {

                    $route.reload();
                }

                $http.get("http://localhost:53155/api/products/GetAllProducts")
                                       .then(function (response) {

                                                     $scope.products = response.data;

                                                     $log.info(response);
                                       })
            })
             .controller("productDetailsController", function ($scope, $http, $routeParams) {
                 $http({
                     url: "http://localhost:53155/api/products/GetProduct/",
                     method: "get",
                     params: { id: $routeParams.id }
                 }).then(function (response) {

        

                     $scope.product = response.data;


                 })
             })