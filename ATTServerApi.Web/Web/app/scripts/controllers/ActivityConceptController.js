(function() {
    var mainModule = angular.module("att.main");

    var ActivityConceptController = function($scope, $location, items, item, filterRules, ProgressWidget, $controller) {
        $controller('BaseEntityController', {
            $scope: $scope,
            $location: $location,
            items: items,
            item: item,
            ProgressWidget: ProgressWidget,
            rootPath: '/activity_concepts'
        });

        $scope.filterRules = filterRules;

        if(item != null && item.rules) {
            var completeList = $scope.filterRules;

            for(var i=0; i<item.rules.length; i++)
            {
                var rule = item.rules[i];
                var j = 0;
                var found = false;

                while(j < completeList.length && !found) {
                    var currentRule = completeList[j];

                    if(currentRule.id === rule.id)
                        found = currentRule.selected = true;
                    j++;
                }
            }
        }

        $scope.save = function() {
            ProgressWidget.show();
            var currentItem =  $scope.item;
            currentItem.rules = [];
            var checkboxes = $("input[type=checkbox]");

            for(var i=0; i<checkboxes.length; i++) {
                if(checkboxes[i].checked) {
                    currentItem.rules.push(filterRules[i]);
                }
            }

            currentItem.$save(function(item) {
                $location.path('/activity_concepts');
            });
        };

    };

    mainModule.controller("ActivityConceptController", [
        '$scope',
        '$location',
        'items',
        'item',
        'filterRules',
        'ProgressWidget',
        '$controller',
        ActivityConceptController
    ]);
})();