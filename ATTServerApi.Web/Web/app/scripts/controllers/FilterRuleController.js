(function() {
    var mainModule = angular.module("att.main");

    var FilterRuleController = function($scope, $location, items, item, ProgressWidget, $controller) {
        $controller('BaseEntityController', {
            $scope: $scope,
            $location: $location,
            items: items,
            item: item,
            ProgressWidget: ProgressWidget,
            rootPath: '/filter_rules'
        });


    };

    mainModule.controller("FilterRuleController", [
        '$scope',
        '$location',
        'items',
        'item',
        'ProgressWidget',
        '$controller',
        FilterRuleController
    ]);
})();