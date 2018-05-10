var peopleApp = angular.module("peopleAppModule");

peopleApp.controller("searchPeopleController", function ($scope, $http, $route, $log, $routeParams, $location) {


    $scope.searchUsingElastic = function () {
        if ($scope.searchQuery)
            $location.url("/people-search/" + $scope.searchQuery)
        else
            $location.url("/people-search")
    }




    if ($routeParams.searchQuery) {
        $http({
            url: "http://localhost:49987/api/People/",
            method: "get",
            params: { query: $routeParams.searchQuery }
        }).then(function (response) {
            $scope.peoples = response.data;
        })
    }
    else {
        $http.get("http://localhost:49987/api/People/")
                    .then(function (response) {
                        $scope.peoples = response.data;
                    })

    }

})