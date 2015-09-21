(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('GridGoodiesCtrl', GridGoodiesController);

    GridGoodiesController.$inject = ['PersonService', '$modal', '$scope'];

    function GridGoodiesController(PersonService, $modal, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Grid with Sorting, Paging, Edit and Delete";
        var allPeople = [];  // private
        vm.personCount = 0;

        $scope.pageChanged = pageChanged;
        $scope.currentPage = 1; // might be that current page is the collection being returned to the view
        $scope.numPerPage = 12;

        vm.openEditPersonModal = openEditPersonModal;
        vm.openDeletePersonModal = openDeletePersonModal;
        vm.$modalInstance = null;

        activate(); // set this thing off

        function activate() {
            return getEveryone();
        }

        function getEveryone() {
            $scope.$emit('loading-started'); // $emit is hard-wired on scope ... can't avoid that.

            return PersonService.getPeople().then(function (data) {
                allPeople = data.data; // then we never tamper with this collection
                vm.personCount = allPeople.length;

                vm.people = _.take(allPeople, $scope.numPerPage);
                $scope.$emit('loading-complete');
            });
        }

        function pageChanged() {

            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            vm.people = allPeople.slice(begin, end);
        }


        // TODO - MODAL for person needs to be in it's own directive so this stuff
        //        doesn't have to be repeated.

        function openEditPersonModal(person) {
            vm.$modalInstance = $modal.open({
                controller: 'PersonModalCtrl',
                controllerAs: 'modalCtrl',
                templateUrl: '/Modals/AddEditPerson',
                resolve: {
                    person: function () { return person; },
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
    }
})();