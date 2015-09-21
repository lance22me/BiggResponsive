(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName)
        .config(routes);

    routes.$inject = ['$routeProvider'];

    function routes($routeProvider) {
        $routeProvider

            .when('/', {
                templateUrl: '/Home/Home',
                controller: 'HomeCtrl',
                controllerAs: 'vm'
            })

            .when('/BasicCall', {
                templateUrl: '/Elementary/BasicGetData',
                controller: 'BasicCallCtrl',
                controllerAs: 'vm'
            })

            .when('/GridWithGoodies', {
                templateUrl: '/Elementary/GridWithGoodies',
                controller: 'GridGoodiesCtrl',
                controllerAs: 'vm'
            })

            .when('/BasicForm', {
                templateUrl: '/Elementary/BasicForm',
                controller: 'BasicFormCtrl',
                controllerAs: 'vm'
            })

            .when('/FormInputMasks', {
                templateUrl: '/Elementary/FormInputMasks',
                controller: 'FormInputMasksCtrl',
                controllerAs: 'vm'
            })

            .when('/FormWithEditDelete', {
                templateUrl: '/Elementary/FormWithEditDelete',
                controller: 'FormWithEditDeleteCtrl',
                controllerAs: 'vm'
            })

            .when('/FormWithNestedObjects', {
                templateUrl: '/Elementary/FormWithNestedObjects',
                controller: 'FormWithNestedObjectsCtrl',
                controllerAs: 'vm'
            })

            .when('/FormWithModal', {
                templateUrl: '/Elementary/FormWithModal',
                controller: 'FormWithModalCtrl',
                controllerAs: 'vm'
            })

            .when('/LocalStorage', {
                templateUrl: '/Elementary/LocalStorage',
                controller: 'LocalStorageCtrl',
                controllerAs: 'vm'
            })

            .when('/Pagination', {
                templateUrl: '/Elementary/Pagination',
                controller: 'PaginationCtrl',
                controllerAs: 'vm'
            })

            /* ----------------------------------------------------- Lodash Playground Stuff  */

            .when('/AllMeetingCriteria', {
                templateUrl: '/Lodash/AllMeetingCriteria',
                controller: 'AllMeetingCriteriaCtrl',
                controllerAs: 'vm'
            })

            .when('/IsInCollection', {
                templateUrl: '/Lodash/IsInCollection',
                controller: 'IsInCollectionCtrl',
                controllerAs: 'vm'
            })

            .when('/FilterWhileUType', {
                templateUrl: '/Lodash/FilterWhileUType',
                controller: 'FilterWhileUTypeCtrl',
                controllerAs: 'vm'
            })

            .when('/BasicFilter', {
                templateUrl: '/Elementary/BasicFiltering',
                controller: 'CardCtrl',
                controllerAs: 'vm'
            })

            .when('/FirstOrDefault', {
                templateUrl: '/Lodash/FirstOrDefault',
                controller: 'FirstOrDefaultCtrl',
                controllerAs: 'vm'
            })

            .when('/SingleProperty', {
                templateUrl: '/Lodash/SingleProperty',
                controller: 'SinglePropertyCtrl',
                controllerAs: 'vm'
            })

            .when('/RemoveFromCollection', {
                templateUrl: '/Lodash/RemoveFromCollection',
                controller: 'RemoveFromCollectionCtrl',
                controllerAs: 'vm'
            })

            /* ----------------------------------------------------- Groups / Shopping Card Stuff  */

            .when('/GroupCreate', {
                templateUrl: '/Elementary/GroupCreate',
                controller: 'GroupCreateCtrl',
                controllerAs: 'vm'
            })

            .when('/GroupManager', {
                templateUrl: '/Elementary/GroupManager',
                controller: 'GroupManagerCtrl',
                controllerAs: 'vm'
            })

            .when('/Products', {
                templateUrl: '/Shopping/Products',
                controller: 'ProductsCtrl',
                controllerAs: 'vm'
            })

            .when('/Cart', {
                templateUrl: '/Shopping/Cart',
                controller: 'ProductsCtrl',
                controllerAs: 'vm'
            })

            /* ----------------------------------------------------- Links                      */

            .when('/Links', {
                templateUrl: '/Home/Links'
            })


           .otherwise({ redirectTo: '/' });

    }
})();