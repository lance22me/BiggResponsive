(function () {
    'use strict';

    var appName = biggstuff.constants.APP_NAME;

    angular.module(appName + '.controllers')
        .controller('PaginationCtrl', PaginationController);

    PaginationController.$inject = ['PersonService', '$scope'];

    function PaginationController(PersonService, $scope) {
        var vm = this;

        vm.header2 = "Pagination With Tag Search";

        var allPeople = [];         
        vm.exposedTags = [];        // get once, don't change
        vm.people = [];

        vm.selectedTag = '';        // pre-selects the '' EVERYONE in dropdown select
        vm.narrowSearch = narrowSearch;

        // forced to use $scope as bootstrap-angular hooks are hard-wired to it.
        $scope.pageChanged = pageChanged;
        $scope.currentPage = 1;     // might be that current page is the collection being returned to the view
        $scope.numPerPage = 12;

        vm.$modalInstance = null;
 
        activate();                 // set this thing off

        function activate() {
            return getPeople();
        }

        function getPeople() {
            $scope.$emit('loading-started');

            return PersonService.getPeople().then(function (data) {
                allPeople = data.data;              
                vm.personCount = allPeople.length;  // all people not in scope so have to explicitly update
                vm.people = _.take(allPeople, $scope.numPerPage);
                getExposedTags();
                $scope.$emit('loading-complete');
            });
        }

        function getByTag(tag) {
            $scope.$emit('loading-started');

            return PersonService.getByTag(tag).then(function (data) {
                allPeople = data.data;              
                vm.personCount = allPeople.length;  
                vm.people = _.take(allPeople, $scope.numPerPage);
                $scope.currentPage = 1;
                $scope.$emit('loading-complete');
            });
        }

        function getExposedTags() {

            var tagsJson = []; 
            vm.exposedTags = _.mapValues(_.groupBy(_.chain(allPeople).pluck('tags').flatten().invoke('split', ',').flatten().invoke('trim').value()), function (r, key) {

                tagsJson.push({
                    'tagName': key,
                    'tagCount': r.length
                });

            });

            tagsJson = _.reject(tagsJson, { 'tagName': '' });
            tagsJson = _.sortBy(tagsJson, 'tagName')

            vm.exposedTags = tagsJson;
        }

        function pageChanged() {
            // bootstrap UI has a strong reference to $scope.
            var begin = (($scope.currentPage - 1) * $scope.numPerPage);
            var end = begin + $scope.numPerPage;

            vm.people = allPeople.slice(begin, end);
        }

        function narrowSearch()
        {
            // stupid if statement, until I can figure out how to pass
            // a regext wildcard up the stcak ...
            if (vm.selectedTag === '') {
                getPeople();
            }
            else {
                getByTag(vm.selectedTag);
            }
        }
    }
})();