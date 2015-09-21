(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.services')
        .service('PersonService', PersonService);

    PersonService.$inject = ['$http'];

    function PersonService($http) {


        this.getPeople = function () {

            return $http({ method: 'GET', url: '/api/People/' }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    alert('ERROR!');
                });
        }

        this.getByTag = function (tag) {

            var foo = 'stop here';

            return $http({ method: 'GET', url: '/api/People', params: { selectedTag: tag } }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    alert('ERROR!');
                });
        }
    }
})();