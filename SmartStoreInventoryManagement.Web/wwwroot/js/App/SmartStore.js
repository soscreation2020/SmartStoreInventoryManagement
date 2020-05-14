///// <reference path="../SmartStoreApp.js" />
(function () {
    var SmartstoreApp = angular.module("smartstoreApp", ['ui.router', 'angularFileUpload', 'angularUtils.directives.dirPagination'])

    SmartstoreApp.config(function (paginationTemplateProvider) {
        paginationTemplateProvider.setPath('/js/dirPagination.tpl.html');
    });


    SmartstoreApp.constant('pageSize', 10);

    SmartstoreApp.directive('convertToNumber', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {

                ngModel.$parsers.push(function (val) {
                    return parseInt(val, 10);
                });

                ngModel.$formatters.push(function (val) {
                    return '' + val;
                });
            }
        };
    });

    Array.prototype.remove = function (from, to) {
        var rest = this.slice((to || from) + 1 || this.length);
        this.length = from < 0 ? this.length + from : from;
        return this.push.apply(this, rest);
    }

    window.SmartstoreApp = SmartstoreApp;

})();