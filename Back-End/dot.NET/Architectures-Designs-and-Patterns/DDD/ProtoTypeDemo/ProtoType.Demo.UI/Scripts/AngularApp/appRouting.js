var peopleApp = angular
           .module("peopleAppModule", ["ngRoute"])
           .config(function ($routeProvider, $locationProvider) {
               $routeProvider
                   .when("/create-people", {
                       templateUrl: "/AngularApp/Templates/createPeople.html",
                       controller: "createPeopleController"
                   })
                   .when("/people-list", {
                       templateUrl: "/AngularApp/Templates/peopleList.html",
                       controller: "listPeopleController"
                   })
                   .when("/people-search/:searchQuery?", { // route params
                       templateUrl: "/AngularApp/Templates/peopleSearch.html",
                       controller: "searchPeopleController"
                   })
                   .otherwise({
                       redirectTo: "/create-people"
                   })

               $routeProvider.caseInsensitiveMatch = false;

               // to remove # from url

               $locationProvider.html5Mode(true);

           });