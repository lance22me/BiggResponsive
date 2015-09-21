(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('LocalStorageCtrl', LocalStorageController);

    LocalStorageController.$inject = ['CardService', 'localStorage', '$scope']; 

    function LocalStorageController(CardService, localStorage, $scope) {
        var vm = this;

        vm.header2 = "Pick a Few Cards - Add Them To HTML5 localStorage";

        vm.deck = [];           // pool of original cards
        vm.storageDeck = [];    // a few cards placed into localStorage
        vm.toggleCardStorage = toggleCardStorage;       // add/remove card from localStorage
        vm.isInCollection = isInCollection;

        var localMemoryKey = 'storedCards';

        activate(); // set this thing off

        function activate() {
            getCards();
            vm.storageDeck = localStorage.getObject(localMemoryKey); // if nothing, returns as empty JSON, not an array or a collection
        }

        function getCards() {
            $scope.$emit('loading-started'); // $emit is hard-wired on scope ... can't avoid that.

            return CardService.getDeck().then(function (data) {
                vm.deck = _.filter(data.data, { suit: 'Diamonds' });
                $scope.$emit('loading-complete');
            });
        }

        function toggleCardStorage(card)
        {
            if (!isInCollection(card))
            {
                addCardToStoredCardCollection(card);
            }
        }

        function addCardToStoredCardCollection(card)
        {
            var currentCollection = [];

            if (vm.storageDeck.length > 0)
            {
                currentCollection = localStorage.getObject(localMemoryKey); 
            }

            currentCollection.push(card);

            localStorage.setObject(localMemoryKey, currentCollection);
            vm.storageDeck = localStorage.getObject(localMemoryKey);
        }

        function removeCardToStoredCardCollection(card)
        {

        }

        function isInCollection(card)
        {
            return _.some(vm.storageDeck, { 'cardId': card.cardId });
        }

    }
})();