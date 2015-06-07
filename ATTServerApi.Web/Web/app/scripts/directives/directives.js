(function() {
    var directives = angular.module('att.directives');

    var butterbar = function($rootScope, ProgressWidget) {
        return {
            link: function(scope, element, attrs) {
                
                ProgressWidget.hide();
                $rootScope.$on('$routeChangeStart', function() {                
                    ProgressWidget.show();
                });
                $rootScope.$on('$routeChangeSuccess', function() {
                    ProgressWidget.hide();
                });
            }
        };
    };

    var focus = function() {
        return {
            link: function(scope, element, attrs) {
                element[0].focus();
            }
        };
    };

    directives.directive('butterbar', ['$rootScope', 'ProgressWidget', butterbar]);
    directives.directive('focus', focus);
})();