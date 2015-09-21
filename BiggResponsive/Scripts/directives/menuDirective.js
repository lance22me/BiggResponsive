(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.directives')
        .directive('biggMenu', biggMenu);

    function biggMenu() {
        var directive = {
            link: link,
            restrict: 'E',
            templateUrl: '/Content/Templates/header.html'
        }
        return directive;

        function link(scope, element, attrs) {
            // stubbed
        }
    }
})();