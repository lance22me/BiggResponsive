(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('PersonModalCtrl', PersonModalController);

    PersonModalController.$inject = [
        '$modalInstance',
        '$rootScope',
        'person',
        'mode'
    ];

    function PersonModalController($modalInstance,$rootScope,person, mode) {
        var vm = this;

        vm.header3 = (person.firstName === undefined) ? 'Add A Person' :'Edit a Person';
        vm.personObj = angular.copy(person) || {};      // copied so that if the original object is edited, then cancelled, MVVM will not see the changes.
        vm.mode = mode;
        vm.busy = false;
        vm.$modalInstance = $modalInstance;
        vm.dismissModal = dismissModal;

        vm.addPerson = addPerson;
        vm.editPerson = editPerson;
        vm.deletePerson = deletePerson;

        activate();

        function activate() {}

        function dismissModal() {
            $modalInstance.dismiss('cancel');
        }

        function addPerson() {
            vm.busy = true;
            $rootScope.$broadcast('addPerson', vm.personObj);
        }

        function editPerson() {
            vm.busy = true;
            $rootScope.$broadcast('editPerson', vm.personObj); 
        }

        function deletePerson() {
            vm.busy = true;
            $rootScope.$broadcast('deletePerson', vm.personObj);
        }
    }
})();