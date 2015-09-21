(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.services')
        .service('ProductService', ProductService);

    ProductService.$inject = ['$http'];

    function ProductService($http) {

        this.getAll = function () {

            return $http({ method: 'GET', url: '/api/Product' }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    alert('ERROR!');
                });
        }
    }
})();