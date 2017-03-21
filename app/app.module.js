(function () {
    'use strict';

    var app = angular.module('app', ["ngRoute"]);
    app.config(function ($routeProvider) {
        $routeProvider
        .when("/", {
            templateUrl: "main.htm",
            controller: "Main"
        })
        .when("/owner/:id", {
            templateUrl: "owner.htm",
            controller : "Owner"
        })
        .otherwise({
            templateUrl: "main.htm",
            controller : "Main"
        })
    });

    app.config(['$locationProvider', function ($locationProvider) {
        $locationProvider.hashPrefix('');
        $locationProvider.html5Mode(true);
    }]);

})();