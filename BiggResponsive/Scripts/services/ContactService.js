(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.services')
        .service('ContactService', ContactService);

    ContactService.$inject = ['$http'];

    function ContactService($http) {

        this.sendMessage = function (messageObj) {

            // NOTE: the DELAY is set in the WebApi

            return $http.post('/api/Contact', messageObj).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    return false;
                });
        }

        this.get = function (messageObj) {

            // NOTE: the DELAY is set in the WebApi

            return $http.get('/api/Contact').
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    alert('fail');
                    return false;
                });
        }
    }
})();