(function() {
    var mainModule = angular.module("att.main");

    var BaseEntityController = function($scope, $location, items, item, ProgressWidget, rootPath) {

        if(items !== null)
            $scope.items = items;

        if(item !== null)
            $scope.item = item;

        $scope.save = function() {
            ProgressWidget.show();
            $scope.item.$save(function(item) {
                $location.path(rootPath);
            });
        };

        $scope.edit = function (index) {            
            $location.path(rootPath + '/edit/' + index);            
        };

        $scope.remove = function(index, event) {
            if (confirm('Are you sure you want to delete this item?')) {
                ProgressWidget.show();
                $scope.items[index].$delete(function() {
                    $scope.items.splice(index, 1);
                    ProgressWidget.hide();
                });
            }
            event.stopPropagation();
        };

        $scope.orderBy = function(attribute) {
            $scope.items.sort(function(a, b) {
                var v1 = a[attribute];
                var v2 = b[attribute];
                var result =  0;

                if(v1.toLowerCase !== undefined)
                    v1 = v1.toLowerCase();

                if(v2.toLowerCase !== undefined)
                    v2 = v2.toLowerCase();

                if (v1 > v2) result = 1;
                if (v1 < v2) result = -1;
                return result;
            });
        };
    };

    mainModule.controller("BaseEntityController", [
        '$scope',
        '$location',
        'items',
        'item',
        'ProgressWidget',
        'rootPath',
        BaseEntityController
    ]);
})();