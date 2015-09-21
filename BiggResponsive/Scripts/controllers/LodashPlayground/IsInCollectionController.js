(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('IsInCollectionCtrl', IsInCollectionController);

    IsInCollectionController.$inject = ['PersonService', '$scope'];

    function IsInCollectionController(PersonService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = 'Do These Things Exist In The Colletion?';
        vm.people = []; // load people, but we will not display people.


        // our three click-event questions
        vm.isInState = isInState;
        vm.hasPhoneNumber = hasPhoneNumber;

        vm.closeAlert = closeAlert;
        $scope.alerts = [];

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

        // Candidates for the boolean search:
        // _.every(collection, [predicate=_.identity], [thisArg])   <-- best for multi-criteria
        // _.includes(collection, target, [fromIndex=0]) ,          <-- full text, like for things that start with or end with
        // _.some(collection, [predicate=_.identity], [thisArg])

        // Three methods below can be consolidate to one. See SinglePropertyController.js for passing up JSON and lodashing it's values.

        function isInState(data)
        {
            var msgType = 'danger';
            var msgText = '';
            var hasMinnesota = _.some(vm.people, { 'state': data });

            if (hasMinnesota)
            {
                msgType = 'success';
                msgText = 'Yes, the collection of people has people from ' + data;
            }
            else
            {
                msgText = 'No, the collection of people does not contain anyone from ' + data;
            }

            $scope.alerts.push({ type: msgType, msg: msgText });
        }

        function hasPhoneNumber(data)
        {
            var msgType = 'danger';
            var msgText = '';
            var hasNumber = _.some(vm.people, { 'phone': data }); // or do _.includes to do partial search like area code

            if (hasNumber)
            {
                msgType = 'success';
                msgText = 'Yes, there is somebody with the phone number of ' + data;
            }
            else {
                msgText = 'No, ' + data + ' is not a phone number in our records.';
            }

            $scope.alerts.push({ type: msgType, msg: msgText });
        }

        function closeAlert(index) {
            //ui.bootstrap watches $scope object
            $scope.alerts.splice(index, 1);
        }

    }
})();