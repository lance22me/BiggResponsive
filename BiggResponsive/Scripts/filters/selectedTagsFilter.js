(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.filters')
        .filter('selectedTags', selectedTags);


    // This filter is indepotent  

    // The filter doesn't change the collection, it just prevents DOM rendering based on the tags.
    // So .. for instnace ... if you have a PAGED LIST the number of items or the place of the items in the collection 
    // will not be altered, even though you expect the size of the list and the placement of the items to change when
    // you click a filter.
 

    function selectedTags() {
        return function (collection, tags) {
            if (tags.length == 0) {
                return collection;
            }

            return collection.filter(function (row) {
                for (var i in tags) {
                    if (row.tags.indexOf(tags[i]) > -1) {
                        return true;
                    }
                }
                return false;
            });
        };
    }
})();