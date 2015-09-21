(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('FormWithEditDeleteCtrl', FormWithEditDeleteController);

    FormWithEditDeleteController.$inject = ['PersonService',
        '$modal',
        '$scope'
    ];

    function FormWithEditDeleteController(PersonService, $modal, $scope) {
        var vm = this;
        vm.header2 = "Edit And Delete Person";

        vm.people = [];
        vm.openEditPersonModal = openEditPersonModal;
        vm.openDeletePersonModal = openDeletePersonModal;

        vm.$modalInstance = null;

        activate();

        function activate() {
            return getPeople();
        }

        function openEditPersonModal(person) {
            vm.$modalInstance = $modal.open({
                controller: 'PersonModalCtrl',
                controllerAs: 'modalCtrl',
                templateUrl: '/Modals/AddEditPerson',
                resolve: {
                    person: function () { return person;},
                    mode: function () { return 'edit' }
                }
            });
        }

        function openDeletePersonModal(person) {
            vm.$modalInstance = $modal.open({
                controller: 'PersonModalCtrl',
                controllerAs: 'modalCtrl',
                templateUrl: '/Modals/DeletePerson',
                resolve: {
                    person: function () { return person; },
                    mode: function () { return 'delete' }
                }
            });
        }

        $scope.$on('editPerson', function (event, person) {

            var personToEdit = _.find(vm.people, function (s) {
                return s.personId === person.personId;
            });

            if (!personToEdit) {
                alert('[facepalm]  What happened?');
                return;
            }

            // would be using a .then .finally if invoking the service
            var index = vm.people.indexOf(personToEdit);
            vm.people[index] = person;

            vm.$modalInstance.dismiss('cancel');
        });

        $scope.$on('deletePerson', function (event, person) {

            // would be using a .then .finally if invoking the service
            vm.people = _.reject(vm.people, person);
            vm.$modalInstance.dismiss('cancel');
        });

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {
                vm.people = data.data;
                $scope.$emit('loading-complete');
            });
        }

    }
})();
