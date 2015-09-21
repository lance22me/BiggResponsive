(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('FirstOrDefaultCtrl', FirstOrDefaultController);

    FirstOrDefaultController.$inject = ['PersonService', '$scope'];

    function FirstOrDefaultController(PersonService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Get the First Instance of a Collection";
        var allPeople = []; // will retain orignal values, internal only.
        vm.people = [];
        vm.getFirstById = getFirstById;
        vm.getFirstByProfileImage = getFirstByProfileImage  ;
        vm.getFirstByLastName = getFirstByLastName;

        activate(); // set this thing off

        function activate() {
            return getPeople();
        }

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {
                allPeople = data.data;
                $scope.$emit('loading-complete');
            });
        }

        function getFirstById(data)
        {
            // TODO _.isNumber(value) to see if 'data' is numeric.  Set Alert messge if not.
            // _.find on Collections, _.first on simple arrays

            vm.people = _.find(allPeople, { 'personId': data });
 
            return vm.result;
        }

        function getFirstByProfileImage(data) {
           
            vm.people = _.find(allPeople, function (allp) { return _.endsWith(allp.profileImage, data); });

        }

        function getFirstByLastName(data) {
            // TODO _.isNumber(value) to see if 'data' is numeric.  Set Alert messge if not.
            vm.people = _.find(allPeople, { 'lastName': data });

            return vm.result;
        }

    }
})();