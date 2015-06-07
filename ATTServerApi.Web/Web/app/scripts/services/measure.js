(function() {
    var services = angular.module('att.services');

    var Measure = function ($resource) {
        return $resource('../api/measure/:id', { id: '@id' });
    };

    var MultiMeasureLoader = function(Measure, $q) {
        return function() {
            var delay = $q.defer();
            Measure.query(function(measures) {
                delay.resolve(measures);
            }, function() {
                delay.reject('Unable to fetch measures');
            });
            return delay.promise;
        };
    };

    services.factory('Measure', ['$resource', Measure]);
    services.factory('MultiMeasureLoader', ['Measure', '$q', MultiMeasureLoader]);
})();