(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('FormInputMasksCtrl', FormInputMasksController);

    FormInputMasksController.$inject = [
        'CardService',
        '$scope'
    ];

    // Make sure this is followed: https://docs.angularjs.org/api/ng/directive/input
    // http://stackoverflow.com/questions/28286588/regex-input-mask-for-angular
    // ng-pattern="/^\([2-9]\d{2}\)\d{3}-\d{4}(x\d{1,4})?$/"

    // ui-mask="(999) 999-9999">
    // ui-mask="/\([0-9]{3}\) [0-9]{3}-[0-9]{4}/">
    // ui-mask="{{ isRegex && '/\([0-9]{3}\) [0-9]{3}-[0-9]{4}/' || '(999) 999-9999' }}">
    // ui-mask="{{ myMask(isPhone) }}">

    // Don't try to use ng-change -- it will cause problems.
    // PLAN - Not going to display the list of names, but the textbox will only be able to accept LastName = whatever in list.

    // http://www.w3schools.com/tags/att_input_pattern.asp

    function FormInputMasksController(CardService, $scope) {
        var vm = this;
        vm.header2 = "Input Masks - Only Certain Characters Can Be Entered";

        vm.deck = [];

        activate();

        function activate() {
            //getCards();
        }

        function getCards() {
            $scope.$emit('loading-started'); // $emit is hard-wired on scope ... can't avoid that.

            return CardService.getDeck().then(function (data) {
                vm.deck = data.data;
                $scope.$emit('loading-complete');
            });
        }

    }
})();
