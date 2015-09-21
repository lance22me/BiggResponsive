(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.services')
        .service('CardService', CardService);

    CardService.$inject = ['$http'];

    function CardService($http) {

        this.getCards = function (cardId) {

            return $http({ method: 'GET', url: '/api/Card', params: { cardId: cardId } }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                });
        }

        this.getDeck = function () {

            return $http({ method: 'GET', url: '/api/Card' }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                });
        }
    }
})();