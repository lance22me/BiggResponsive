(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('FilterWhileUTypeCtrl', FilterWhileUType);

    FilterWhileUType.$inject = ['PersonService', '$scope'];

    function FilterWhileUType(PersonService, $scope) {

        var vm = this;

        vm.header2 = "Filter A List By Typing In Text Box";
        var allPeople = []; // will retain orignal values, internal only.
        vm.people = [];

        vm.searchString = '';
        vm.getFilteredList = getFilteredList; // method called to 

        vm.closeAlert = closeAlert;
        $scope.alerts = [];

        activate();

        function activate() {
            return getPeople();
        }

        function getFilteredList() {

            vm.people = _.filter(allPeople, function (pers)
            {
                return _.startsWith(pers.lastName.toLowerCase(), vm.searchString.toLowerCase());
            });
        }

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {
                allPeople = data.data;
                vm.people = allPeople;

                $scope.$emit('loading-complete');
            });
        }

        function closeAlert(index) {
            $scope.alerts.splice(index, 1);
        }

    }
})();