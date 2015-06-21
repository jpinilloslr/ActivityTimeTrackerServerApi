(function() {
    var directives = angular.module('att.directives');

    var butterbar = function($rootScope, ProgressWidget, Notifier) {
        return {
            link: function(scope, element, attrs) {
                
                ProgressWidget.hide();
                $rootScope.$on('$routeChangeStart', function () {
                    Notifier.clear();
                    ProgressWidget.show();
                });
                $rootScope.$on('$routeChangeSuccess', function() {
                    ProgressWidget.hide();
                });
                $rootScope.$on('$routeChangeError', function (event, state, params, error) {
                    if (error && error.unAuthorized) {
                        location.href = "login.html";
                    }
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

    directives.directive('butterbar', ['$rootScope', 'ProgressWidget', 'Notifier', butterbar]);
    directives.directive('focus', focus);
})();