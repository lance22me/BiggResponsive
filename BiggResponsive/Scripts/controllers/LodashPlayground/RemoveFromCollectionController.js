(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('RemoveFromCollectionCtrl', RemoveFromCollectionController);

    RemoveFromCollectionController.$inject = ['CardService', '$scope'];

    function RemoveFromCollectionController(CardService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Remove Stuff From The Collection!";
        vm.deck = [];

        vm.removeOnMatch = removeOnMatch;

        activate(); // set this thing off

        function activate() {
            return getCards();
        }

        function getCards() {
            $scope.$emit('loading-started'); // $emit is hard-wired on scope ... can't avoid that.

            return CardService.getDeck().then(function (data) {
                vm.deck = data.data;
                $scope.$emit('loading-complete');
            });
        }

        function removeOnMatch(data) {

            vm.deck = _.reject(vm.deck, data);
        }

     }
})();