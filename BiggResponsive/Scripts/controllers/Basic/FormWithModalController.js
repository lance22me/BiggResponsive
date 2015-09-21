(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('FormWithModalCtrl', FormWithModalController);

    FormWithModalController.$inject = [
        '$modal',
        '$scope'
    ];

    function FormWithModalController($modal,$scope) {
        var vm = this;
        vm.header2 = "Add a Person via Modal Popup Form";

        vm.people = [];
        vm.openAddPersonModal = openAddPersonModal;

        vm.$modalInstance = null;

        activate();

        function activate() { }

        function openAddPersonModal() {
            vm.$modalInstance = $modal.open({
                controller: 'PersonModalCtrl',
                controllerAs: 'modalCtrl',
                templateUrl: '/Modals/AddEditPerson',
                resolve: {
                    person: function () { return {} },
                    mode: function () { return 'add' }
                }
            });
        }


        $scope.$on('addPerson', function (event, person) { 
             
            if (!person) {
                alert('no person.  what happened?');
                return;
            }

            // we get the person back, add to the people array
            vm.people.push(person);
            vm.$modalInstance.dismiss('cancel');

            // If I persisted, I'd do this.
            //vm.PersonService.add(person).then(function (response) {
            //    vm.people.push(person);
            //},
            //function (error) {
            //})
            //.finally(function () {
            //    vm.$modalInstance.dismiss('cancel');
            //});
        });

    }
})();
