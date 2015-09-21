(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('AllMeetingCriteriaCtrl', AllMeetingCriteriaController);

    AllMeetingCriteriaController.$inject = ['PersonService', '$scope'];

    function AllMeetingCriteriaController(PersonService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "All of the People Who ..";
        var allPeople = []; // will retain orignal values, internal only.
        vm.people = [];

        vm.getByMatch = getByMatch;
        vm.removeByMatch = removeByMatch;
        vm.getLastNameContains = getLastNameContains;

        activate();

        function activate() {
            return getPeople();
        }

        function getByMatch(data)
        {
            vm.people = _.filter(allPeople, data);
        }

        function removeByMatch(data)
        {
            vm.people = _.reject(allPeople, data);
        }

        function getLastNameContains(data) {

            // single property
            // var aaa = _.result(_.find(allPeople, function (pers) { return pers.lastName === 'Kitty'; }), 'firstName');
            //// returns first truthy, note that values are not mapped
            //var bbb = _.filter(_.find(allPeople, function (pers) { return pers.zip === '55123'; }));
            //// returns all rows, values mapped to keys
            //var ccc = _.filter(allPeople, function (pers) { return pers.city === 'Eagan'; });

            vm.people = _.filter(allPeople, function (pers) { return _.includes(pers.lastName, 'shi'); }); // case sensitive ?

        }

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {

                // Normally would do this in the service ...
                allPeople = data.data;

                $scope.$emit('loading-complete');
            });
        }


    }
})();