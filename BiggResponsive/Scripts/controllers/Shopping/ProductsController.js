(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('ProductsCtrl', ProductsController);

    ProductsController.$inject = ['ProductService', 'cartFactory', '$scope', '$location'];

    function ProductsController(ProductService, cartFactory, $scope, $location) {
        var vm = this;

        // declarations
        vm.header2 = "Best Deals in Town!";
        vm.products = [];
        vm.setProductColor = setProductColor;

        vm.addToCart = addToCart;
        vm.viewCart = viewCart;

        activate(); // set this thing off

        function activate() {
            vm.cart = cartFactory;
            return getProducts();
        }

        function getProducts() {
            $scope.$emit('loading-started');

            return ProductService.getAll().then(function (data) {
                vm.products = data.data;
                $scope.$emit('loading-complete');
            });
        }

        function setProductColor(product, color) {
            product.selectedColor = color;
            product.productImage = "/Content/ImagesProducts/" + product.productType + "_" + color + ".jpg";
        }

        function addToCart(product) {
            addGrandTotal(product);
            vm.cart.grandTotal = addGrandTotal(product);
            vm.cart.items.push(product);
        }

        function viewCart() {
            $location.path('/Cart');
        }

        function addGrandTotal(product) {
            // in a real app, I'd never allow monetaries to be handled on the client
            return  vm.cart.grandTotal + (product.quantity * product.price);
        }

    }
})();