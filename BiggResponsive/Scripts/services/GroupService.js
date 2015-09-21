(function () {
    'use strict';

    // NOTE - Group management requires Session, so NOT using REST.

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.services')
        .service('GroupService', GroupService);

    GroupService.$inject = ['$http', '$rootScope'];

    function GroupService($http,$rootScope) {

        GroupService.activeGroup = []; // ??? same as this.activeGroup ?????

        this.getAll = function () {

            return $http({ method: 'GET', url: '/Elementary/GetAllGroups' }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    alert('group service failed on getAll. ');
                    return false;
                });
        }

        this.addGroup = function (groupObj) {

            return $http.post('/Elementary/AddGroup', groupObj).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    return false;
                });
        }

        this.setActiveGroup = function (groupObj) {
            GroupService.activeGroup = groupObj;
        }

        this.getActiveGroup = function () {
            return GroupService.activeGroup;
        }

        this.addPersonToGroup = function (personObj)
        {
            var group = GroupService.activeGroup;
            var groupPerson = { SelectedGroup: group, SelectedMember: personObj }

            return $http.post('/Elementary/AddPersonToGroup', groupPerson).
                success(function (data, status, headers, config) {
                    // don't need to return data.
                    return true;

                }).
                error(function (data, status, headers, config) {
                    return false;
                });
        }
    }
})();