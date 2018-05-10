var peopleApp = angular.module("peopleAppModule");

peopleApp.controller("listPeopleController", function ($scope, $http, $route, $log) {


    $http.get("http://localhost:49987/api/People/")
                       .then(function (response) {

                           $scope.peoples = response.data;

                       })


    //  reload just the current route

    $scope.reloadPeoplesFromMongo = function () {

        $route.reload();
    }


})