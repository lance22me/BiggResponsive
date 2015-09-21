(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('FormWithNestedObjectsCtrl', FormWithNestedObjectsController);

    FormWithNestedObjectsController.$inject = [
        'ContactService',
        '$modal',
        '$scope'
    ];

    function FormWithNestedObjectsController(ContactService, $modal, $scope) {
        var vm = this;
        vm.header2 = "Form with Nested Objects";

        vm.contacts = [];       // brought down from the service on page load.
        vm.contactObj = {
            phoneNumbers: [  { phone: '', phoneNumberTypeId: 1, phoneNumberType: 'Home' },
                             { phone: '', phoneNumberTypeId: 2, phoneNumberType: 'Mobile' },
                             { phone: '', phoneNumberTypeId: 3, phoneNumberType: 'Work' }]
        };

        vm.sendContactMessage = sendContactMessage;

        vm.closeAlert = closeAlert;
        vm.resetContactForm = resetContactForm;

        //ui.bootstrap watches $scope object
        $scope.alerts = [];

        activate();

        function activate() { get();}


        function get() {

            $scope.$emit('loading-started');
            $scope.alerts.length = 0;

            ContactService.get().then(function (response) {

                if (response.status === 200 /* Response status OK */) {
                    vm.contacts = response.data;

                } else {
                    $scope.alerts.push({ type: 'danger', msg: 'Ops! We were unable to get the contacts' });
                }

                $scope.$emit('loading-complete');
            },
            function (error) {
                $scope.alerts.push({ type: 'danger', msg: 'Ops! There was an error in the call chain.' });

                $scope.$emit('loading-complete');
            });
        }

        function sendContactMessage() {

            $scope.$emit('loading-started');
            $scope.alerts.length = 0;

            ContactService.sendMessage(vm.contactObj).then(function (response) {

                if (response.status === 200 /* Response status OK */) {
                    $scope.alerts.push({ type: 'success', msg: 'Message successfully sent!' });

                    var foo = response.data;
                    // don't want to 'push' or it will go to the bottom

                    vm.contacts.push(response.data); 
                    vm.contacts.reverse(); // TODO - Gotta come up with a better way

                    vm.resetContactForm();
                } else {
                    $scope.alerts.push({ type: 'danger', msg: 'Ops! We were unable to send your message!' });
                }

                $scope.$emit('loading-complete');
            },
            function (error) {
                $scope.alerts.push({ type: 'danger', msg: 'Ops! We were unable to send your message!' });

                $scope.$emit('loading-complete');
            });
        }

        function resetContactForm() {
            vm.contactObj = {};
            $scope.form.$setPristine();
        }

        function closeAlert(index) {
            //ui.bootstrap watches $scope object
            $scope.alerts.splice(index, 1);
        }

    }
})();
