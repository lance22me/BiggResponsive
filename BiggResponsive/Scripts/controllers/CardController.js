(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('CardCtrl', CardController);

    CardController.$inject = ['CardService', '$scope'];

    function CardController(CardService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Basic Filtering - Full Deck!";
        vm.deck = [];

        vm.filteredSuit = filteredSuit;
        vm.filteredTags = filteredTags;
        vm.tagsFilter = [];                     // used by the checkboxes, assignment/set is done on the DOM
        vm.toggleTagChecked = toggleTagChecked;

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

        function filteredSuit() {
            return _.mapValues(_.groupBy(vm.deck, 'suit'), function (r) { return r.length; });
        }

        function filteredTags() {
            // PERFECT example of why you dont have to pass args around (much) in Angular.
            // as mv.deck is updated, this also changes to keep up with model changes.
            // CALL to the method happens from the client when the iterator encounters the reference to vm.filteredTags

            return _.mapValues(_.groupBy(_.chain(vm.deck).pluck('tags').flatten().invoke('split', ',').flatten().invoke('trim').value()), function (r) { return r.length; });
        }

        function toggleTagChecked(value) {
            var index = vm.tagsFilter.indexOf(value);

            if (index > -1) {
                vm.tagsFilter.splice(index, 1);
            } else {
                vm.tagsFilter.push(value);
            }
        }
    }
})();
