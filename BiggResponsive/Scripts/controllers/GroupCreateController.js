(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('GroupCreateCtrl', GroupCreateController);

    GroupCreateController.$inject = ['GroupService', '$scope', '$location'];

    function GroupCreateController(GroupService, $scope, $location) {
        var vm = this;

        // declarations
        vm.header2 = "Add & Manage Groups !!";
        vm.groups = []; // getting back from server
        vm.groupObj = {}; // pushing up from form
        vm.addNewGroup = addNewGroup;
        vm.addMembers = addMembers;
        vm.resetGroupForm = resetGroupForm;
        //ui.bootstrap watches $scope object
        vm.closeAlert = closeAlert;
        $scope.alerts = [];

        activate(); // set this thing off

        function activate() {
            return getGroups();
        }

        function getGroups() {
            $scope.$emit('loading-started');

            return GroupService.getAll().then(function (data) {
                vm.groups = data.data;
                $scope.$emit('loading-complete');
            });
        }

        function addNewGroup() {

            $scope.$emit('loading-started'); // also see 'on' or 'broadcast' http://stackoverflow.com/questions/14502006/scope-emit-and-on-in-angularjs
            $scope.alerts.length = 0;

            GroupService.addGroup(vm.groupObj).then(function (response) {

                if (response.status === 200 /* Response status OK */) {

                    vm.groups = response.data;
                    $scope.alerts.push({ type: 'success', msg: 'Message successfully sent!' });
                    vm.resetGroupForm();
                } else {
                    $scope.alerts.push({ type: 'danger', msg: 'Ops! We were unable to add that group!' });
                }
                
                $scope.$emit('loading-complete');
            },
            function (error) {
                $scope.alerts.push({ type: 'danger', msg: 'Ops! We were unable to add that group!' });
                $scope.$emit('loading-complete');
            });
        }

        // link called Add Members ... actual add is GroupManageController
        function addMembers(group) {

            vm.groupObj = group;

            GroupService.setActiveGroup(vm.groupObj);
            $location.path('/GroupManager'); 
    
        }

        // form cleanup / post-response stuff ... Prolly should make these directives

        function resetGroupForm() {
            vm.groupObj = {};
            $scope.form.$setPristine();
        }

        function closeAlert(index) {
            //ui.bootstrap watches $scope object
            $scope.alerts.splice(index, 1);
        }

    }
})();