namespace('biggstuff.constants').APP_NAME = 'biggstuff';

(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName, [
        /**
         * Angular modules
         */
        'ngRoute',
        /*
         * Bootstrap modules
         */
        'ui.bootstrap',
        /* dat grid 
        'ui.grid' <-- REMOVED ,*/
        /**
         * Our reusable app code modules
         */
        appName + '.controllers',
        appName + '.directives',
        appName + '.factories',
        appName + '.filters',
        appName + '.services'

    ]);
})();