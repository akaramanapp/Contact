angular.module('contactapp', ["contactapp.controllers", "ngRoute"])
    .factory('$exceptionHandler', function () {

        return function (exception, couse) {
            exception.message += ' caused by ' + couse;
            alert(exception.message);
        }
    })
    .config(function ($routeProvider) {

        $routeProvider.when("/contacts", {
            templateUrl: "Modules/Contacts.html"
        });
        $routeProvider.when("/Create", {
            templateUrl: "Modules/Create.html"
        });
        $routeProvider.when("/Update/:ContactId", {
            templateUrl: "Modules/Update.html"
        });

        $routeProvider.when("/Login", {
            templateUrl: "Modules/Login.html"
        });

        $routeProvider.otherwise({
            templateUrl: "Modules/Contacts.html"
        });

        $routeProvider.when("/", {
            templateUrl: "Modules/Login.html"
        });
    })
 .directive('numberConverter', function () {
     return {
         priority: 1,
         restrict: 'A',
         require: 'ngModel',
         link: function (scope, element, attr, ngModel) {
             function toModel(value) {
                 return "" + value; // convert to string
             }

             function toView(value) {
                 return parseInt(value); // convert to number
             }

             ngModel.$formatters.push(toView);
             ngModel.$parsers.push(toModel);
         }
     };
 }).directive('ngConfirmClick', [
         function () {
             return {
                 link: function (scope, element, attr) {
                     var msg = attr.ngConfirmClick || "Are you sure?";
                     var clickAction = attr.confirmedClick;
                     element.bind('click', function (event) {
                         if (window.confirm(msg)) {
                             scope.$eval(clickAction)
                         } 
                     });
                 }
             };
         }]);