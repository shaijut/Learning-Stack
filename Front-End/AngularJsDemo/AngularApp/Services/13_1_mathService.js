var myApp = angular.module("MyModule");

myApp.factory("mathService", function () {

    var mathFactory = {};

    mathFactory.AddTwoNumbers = function (x, y) {

        return Number(x) + Number(y);
    };

    return mathFactory;


});