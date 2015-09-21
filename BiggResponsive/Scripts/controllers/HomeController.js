(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('HomeCtrl', HomeController);

    function HomeController() {
        var vm = this;
        vm.header2 = "Angular w Web API";
    }
})();