(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('BasicFormCtrl', BasicFormController);

    BasicFormController.$inject = ['ContactService', '$scope'];

    function BasicFormController(ContactService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Very Basic Form - Very Basic Validation!";
        vm.contactObj = {};
        vm.sendContactMessage = sendContactMessage;
        vm.closeAlert = closeAlert;
        vm.resetContactForm = resetContactForm;

        //ui.bootstrap watches $scope object
        $scope.alerts = [];

        activate(); // set this thing off

        function activate() { /* nothing to activate for now */ }


        function sendContactMessage() {

            $scope.$emit('loading-started'); 
            $scope.alerts.length = 0;

            ContactService.sendMessage(vm.contactObj).then(function (response) {

                if (response.status === 200 /* Response status OK */) {
                    $scope.alerts.push({ type: 'success', msg: 'Message successfully sent!' });
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