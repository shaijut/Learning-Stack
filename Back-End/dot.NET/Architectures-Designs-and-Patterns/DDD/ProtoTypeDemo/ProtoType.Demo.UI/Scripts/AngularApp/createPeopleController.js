var peopleApp = angular.module("peopleAppModule");

peopleApp.controller("createPeopleController", function ($scope, $http, $window, $timeout, $route) {


    // form validation


    $scope.hasError = function (field, validation) {



        if (validation) {
            return ($scope.form[field].$dirty && $scope.form[field].$error[validation]) || ($scope.submitted && $scope.form[field].$error[validation]);
        }
        return ($scope.form[field].$dirty && $scope.form[field].$invalid) || ($scope.submitted && $scope.form[field].$invalid);
    };


    $scope.successAlertDisplayed = false;
    $scope.errorAlertDisplayed = false;

    var successCallBack = function (response, status) {

        //$window.alert("ok");

        //debugger;

        //$window.alert(response.data.FirstName);

        $scope.successAlertDisplayed = true;
        $scope.startFade = true;
        $timeout(function () {
            $scope.successAlertDisplayed = false;
        }, 2000)
       

    };

    var errorCallBack = function (response, status) {

        $window.alert("Error");

        //$window.alert(response.Message);


        $scope.errorAlertDisplayed = true;
        $scope.startFade = true;
        $timeout(function () {
            $scope.errorAlertDisplayed = false;
        }, 2000)
    }


    $scope.AddPeople = function (form) {

        // trigger validation

        $scope.submitted = true;


        if (form.$valid) {
            //$window.alert("form valid");

            var post = $http({
                method: "POST",
                url: "http://localhost:57603/Peoples/CreatePeople",
                dataType: "json",
                data: $scope.formData,
                headers: { "Content-Type": "application/json" }
            }).then(successCallBack, errorCallBack);

            $timeout(function () {
                $scope.reloadPeoplesFromMongo();
            }, 2000)

           
        }

        else {
            //$window.alert("form not valid");
        }



    

    }



    // listing people in same view 


    $http.get("http://localhost:49987/api/People/")
                       .then(function (response) {

                           $scope.peoples = response.data;

                       })


    //  reload just the current route

    $scope.reloadPeoplesFromMongo = function () {

        //$route.reload();

        //alert("reload");

        $http.get("http://localhost:49987/api/People/")
                    .then(function (response) {

                        $scope.peoples = response.data;

                    })
    }


});
