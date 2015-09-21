(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.factories')
        .factory('localStorage', localStorage);

    localStorage.$inject = ['$window'];

    function localStorage($window) {

        function set(key, value) {
            $window.localStorage[key] = value;
        }

        function get(key, defaultValue) {
            return $window.localStorage[key] || defaultValue;
        }

        function setObject(key, value) {
            $window.localStorage[key] = JSON.stringify(value);
        }

        function getObject(key) {
            return JSON.parse($window.localStorage[key] || '{}');
        }

        function has(key) {
            return _.has($window.localStorage, key);
        }

        function remove(key) {
            delete $window.localStorage[key];
        }

        function removeAll() {
            $window.localStorage.clear();
        }

        function count() {
            return $window.localStorage.length;
        }

        return {
            set: set,
            get: get,
            setObject: setObject,
            getObject: getObject,
            has: has,
            remove: remove,
            removeAll: removeAll,
            count: count
        };
    }

})(window._);