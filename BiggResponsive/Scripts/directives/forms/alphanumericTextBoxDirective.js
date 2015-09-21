
(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.directives')
        .directive('alphanumericTextbox', alphanumericTextbox);

    alphanumericTextbox.$inject = [];

    function alphanumericTextbox() {

        var directive = {
            link: link,
            restrict: 'E',
            template: '<input type="text" class="form-control alphanumericOnlyTextbox" name="whatever" maxlength="14" >'
        }

        return directive;

        // GOTCHA    event.which cannot detect upper case letters, only keys in and of themselves.
        // SOLUTION  using JQuery again, for reasons cited in phoneNumberTextBoxDirective.js

        function link(scope, element, attrs) {

            $('.alphanumericOnlyTextbox').keyup(function () {

                var foo = $(this).val();
                var lastChar = foo.slice(-1);

                var alphaNum = new RegExp('[a-zA-Z0-9]') 
                var isValidInput = alphaNum.test(lastChar);

                if (!isValidInput) {
                    var str = foo.substring(0, foo.length - 1);
                    $(this).val(str);
                }
            })

        }
    }
})();
