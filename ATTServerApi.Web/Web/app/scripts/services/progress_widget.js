(function() {
    var services = angular.module('att.services');

    var ProgressWidget = function () {
        return {
            show: function() {
                $("#overlay").fadeIn();
            },
            hide: function() {
                $("#overlay").fadeOut();
            }
        }
    };

    services.factory('ProgressWidget', ProgressWidget);
})();