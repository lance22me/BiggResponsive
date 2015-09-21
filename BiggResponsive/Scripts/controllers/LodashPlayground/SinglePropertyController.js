(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('SinglePropertyCtrl', SinglePropertyController);

    SinglePropertyController.$inject = ['CardService', '$scope'];

    function SinglePropertyController(CardService, $scope) {
        var vm = this;

        // declarations
        vm.header2 = "Return Single Property on One or Many Rows";
        var allCards; // private field holding the deck

        vm.getSinglePropertyAll = getSinglePropertyAll;
        vm.getSingleDynamic = getSingleDynamic;
        vm.resultValue = '';

        activate(); 

        function activate() {
            return getCards();
        }

        // Display Name for Every Card
        function getSinglePropertyAll(data)
        {
            vm.resultValue = _.pluck(_.filter(allCards), data);
        }

        // Display Name for Every Card & 'Tags' for Ace of Hearts
        function getSingleDynamic(data)
        {
            var dynanicJson = buildSingleNodeJson(data);
            var lastField = _.valuesIn(data);  
            var returnField = lastField[1];                                     

            vm.resultValue = _.result(_.find(allCards, dynanicJson), returnField);
        }

        function getCards() {
            $scope.$emit('loading-started'); // $emit is hard-wired on scope ... can't avoid that.

            return CardService.getDeck().then(function (data) {
                allCards = data.data;
                $scope.$emit('loading-complete');
            });
        }

        // returns a JSON with single key and value
        function buildSingleNodeJson(data) {
            var jsonKey = _.findKey(data);
            var jsonValue = _.find(data, function (chr) { return chr });
            var newJson = {};
            var keyVariable = jsonKey;

            newJson[keyVariable] = jsonValue

            return newJson;
        }
    }
})();