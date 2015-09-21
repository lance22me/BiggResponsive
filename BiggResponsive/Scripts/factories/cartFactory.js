(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.factories')
        .factory('cartFactory', cartFactory);

    function cartFactory() {
        var cart = {
            items: [],
            tax: 6,
            grandTotal: 0
        }
        return cart;
    }

    function cartItem() {
        var item = {
            product: [],
            quantity: 3,
            selectedColor: "Orange"
        };
        return item;
    }
})();