(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.directives')
        .directive('numericOnlyTextbox', numericOnlyTextbox);

    numericOnlyTextbox.$inject = ['$document'];

    function numericOnlyTextbox($document) {

        var directive = {
            link: link, 
            restrict: 'E',
            template: '<input type="numeric" class="form-control" name="numericOnly" maxlength="16" >'
        }

        return directive;

        function link(scope, element, attrs) {

            // e.which - https://css-tricks.com/snippets/javascript/javascript-keycodes/
            // --------------------------------------

            // backspace: 8 
            // delete: 46
            // left/right arrow: 37,39
            // shift: 16
            // tab: 9
            // ----------------
            // numbers : 48-57
            // a-z: 68-90

            // Regex might be the easier way to check complex keyboard events
            // such as special characters which require two concurrent keyboard presses.

            // Lodash has ..
            // _.isNan(arg), _.isNumber, _.isDate

            element.on('keydown', function (event) {
                // Prevent default dragging of selected content

                if (!( (event.which > 47 && event.which < 58) || event.which === 8 || event.which === 9 || event.which === 46 || event.which === 37 || event.which === 39))
                { 
                    event.preventDefault();
                }

            });
            
        }
    }
})();