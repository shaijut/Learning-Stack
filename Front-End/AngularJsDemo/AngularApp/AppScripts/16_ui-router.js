var app = angular
           .module("MyModule", ["ui.router"])
           .config(function ($stateProvider) {

               $stateProvider
                   .state("home", {
                       url: "/home",
                       templateUrl: "/AngularApp/Templates/home.html",
                       controller: "homeController",
                       controllerAs: "homeCtrl"
                   })
                   .state("courses", {
                       url: "/courses",
                       templateUrl: "/AngularApp/Templates/courses.html",
                       controller: "coursesController",
                       controllerAs: "coursesCtrl"
                   })

                   .state("products", {
                       url: "/products",
                       templateUrl: "/AngularApp/Templates/products.html",
                       controller: "productsController",
                       controllerAs: "productsCtrl",
                       resolve: {
                           productslist: function ($http, $location) {
                               return $http.get("http://localhost:53155/api/products/GetAllProducts")
                                       .then(function (response) {
                                           return response.data;
                                       })
                           }
                       }
                   })

                .state("/productsSearch/:name?", {
                    templateUrl: "/AngularApp/Templates/productsSearch.html",
                    controller: "productsSearchController",
                    controllerAs: "productsSearchCtrl"

                })
           })
 .controller("productsController", function (productslist, $state, $location) {
     var vm = this;

     vm.productSearch = function () {
         if (vm.name)
             $location.url("/productsSearch/" + vm.name)
         else
             $location.url("/productsSearch")
     }

     //  reload just the current route

     vm.reloadProducts = function () {
         $state.reload();
     }

 

     vm.products = productslist;
 })
 .controller("productsSearchController", function ($http, $routeParams) {
     var vm = this;

     if ($routeParams.name) {
         $http({
             url: "http://localhost:53155/api/products/GetAllProducts",
             method: "get",
             params: { name: $routeParams.name }
         }).then(function (response) {
             vm.products = response.data;
         })
     }
     else {
         $http.get("http://localhost:53155/api/products/GetAllProducts")
                     .then(function (response) {
                         vm.products = response.data;
                     })
     }
 })
          .controller("coursesController", function ($scope) {
              $scope.courses = ["C#", "VB.NET", "ASP.NET", "SQL Server"];
          })

