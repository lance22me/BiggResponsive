(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('GroupManagerCtrl', GroupManagerController);

    GroupManagerController.$inject = ['GroupService', 'PersonService', '$scope'];

    function GroupManagerController(GroupService, PersonService, $scope) {

        var vm = this;

        vm.header2 = "Add People To An Existing Group !!";
        vm.group = [];          // getting back from js service
        vm.personObj = {};      // pushed up from individual check boxes on the form
        vm.people = [];         // getting back from js service
        vm.showAddGroupButton = false;
        vm.toggleMembership = toggleMembership;
        vm.closeAlert = closeAlert;
        vm.isPersonInCurrentGroup = isPersonInCurrentGroup;

        $scope.alerts = [];     //ui.bootstrap watches $scope object

        activate();

        function activate() {
            showActiveGroup();
            getPeople();
        }

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {
                vm.people = data.data;
                $scope.$emit('loading-complete');
            });
        }

        function showActiveGroup() {
            vm.group = GroupService.getActiveGroup();
            vm.header2 = "Add People to " + vm.group.groupName;
        }

        function toggleMembership(person) {
            $scope.$emit('loading-started');

            return GroupService.addPersonToGroup(person).then(function (data) {
                // returning true / false
                $scope.$emit('loading-complete');
            });
        }

        function closeAlert(index) {
            //ui.bootstrap watches $scope object
            $scope.alerts.splice(index, 1);
        }

        function isPersonInCurrentGroup(person) {

            if (!vm.group || !vm.group.members) {
                return false;
            }

            var result = _.some(vm.group.members, { 'personId': person.personId });
            return result;

            // lodash saves you from writing a loop like the one below.

            //for (var i = 0; i < memberCount; i++) {
            //    if (vm.group.members[i].personId === person.personId) {
            //        result = true;
            //    }
            //}

        }

    }
})();