(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.directives')
        .directive('phoneNumberTextbox', phoneNumberTextbox);

    phoneNumberTextbox.$inject = [];

    function phoneNumberTextbox() {

        var directive = {
            link: link,
            restrict: 'E',
            template: '<input type="text" class="form-control phoneOnlyTextbox" name="phoneNumber" placeholder="(999) 999-9999" maxlength="14" >'
        }

        return directive;

        // GOTCHA    The parens ( ) can't be captured by e.which, since those characters are a combination of keys and not
        //           a single-key; e.which only sees one key.
        // SOLUTION  Use JQuery to get the string, and remove character(s) that we don't allow in this box.
        //           The ideal solution would only allow parens at index[0] and index[5]. Too much hassle IMHO.
        
        // APOLOGY   When you use Angular, you should avoid using JQuery as much as possible. That said, (1) the text-box mask occurs 
        //           outside of the watched model and therefore we avoid polluting it, (2) Angular isn't the one tool to rule them 
        //           all, (3) Angular itself loads JQuery if you con't have it in your project, as even THEY use JQuery.
        //           So ... best practice is to avoid using JQuery except when one can make a strong arguement for it.

        function link(scope, element, attrs) {

            $('.phoneOnlyTextbox').keyup(function (event) {

                var phoneNumber = $(this).val();
                var lastChar = phoneNumber.slice(-1);

                var regex = new RegExp('[a-zA-Z/\//!@#=$^&*_+?]')  /* no match for dash, parens, period, 0-9 */ 
                var isValidInput = regex.test(lastChar);

                if (isValidInput) {
                    var str = phoneNumber.substring(0, phoneNumber.length - 1);
                    $(this).val(str);
                }
              })


            //$scope.myMask = function (isPhone) {
            //    if (isPhone)
            //        return '/\([0-9]{3}\) [0-9]{3}-[0-9]{4}/'
            //    else
            //        return '(999) 999-9999'
            //}
        }
    }
})();