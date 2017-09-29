var AppMVC = angular.module('AppMVC', ['ngRoute']);
AppMVC.config(function ($routeProvider) {

    $routeProvider
        .when("/SPAMain", {
            templateUrl: "/SPA/Main/Index"
        })
        .when("/EmployeeAdd", {
            templateUrl: "/Employee/AddNew"
        });
});

