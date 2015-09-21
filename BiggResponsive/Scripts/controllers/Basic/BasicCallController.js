(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('BasicCallCtrl', BasicCallController);

    BasicCallController.$inject = ['PersonService', '$scope'];

    function BasicCallController(PersonService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Simple Data Call - See All The People!";
        vm.people = [];

        activate(); // set this thing off

        function activate() {
            return getPeople();
        }

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {
                vm.people = data.data;
                $scope.$emit('loading-complete');
            });
        }
    }
})();