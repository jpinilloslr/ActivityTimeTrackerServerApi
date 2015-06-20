(function () {
    var services = angular.module('att.services');    

    var HttpInterceptor = function ($q, Notifier, ProgressWidget) {
        return {
            'request': function (config) {
                return config;
            },

            'requestError': function (rejection) {
                return $q.reject(rejection);
            },

            'response': function (response) {
                return response;
            },

            'responseError': function (rejection) {
                ProgressWidget.hide();
                Notifier.error(rejection.statusText);
                return $q.reject(rejection);
            }
        };
    };

    services.factory('HttpInterceptor', HttpInterceptor);

    var config = function ($httpProvider) {
        $httpProvider.interceptors.push('HttpInterceptor');
    };

    services.config(config);

})();