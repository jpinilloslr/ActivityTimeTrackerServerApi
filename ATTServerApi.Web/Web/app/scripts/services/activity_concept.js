
(function() {
    var services = angular.module('att.services');

    var ActivityConcept = function ($resource) {
        return $resource('../api/activityconcept/:id', { id: '@id' });
    };

    var MultiActivityConceptLoader = function(ActivityConcept, $q) {
        return function() {
            var delay = $q.defer();
            ActivityConcept.query(function(activityConcepts) {
                delay.resolve(activityConcepts);
            }, function() {
                delay.reject('Unable to fetch activity concepts');
            });
            return delay.promise;
        };
    };

    var ActivityConceptLoader = function(ActivityConcept, $route, $q) {
        return function() {
            var delay = $q.defer();
            ActivityConcept.get({id: $route.current.params.activityConceptId}, function(activityConcept) {
                delay.resolve(activityConcept);
            }, function() {
                delay.reject('Unable to fetch activity concept ' + $route.current.params.activityConceptId);
            });
            return delay.promise;
        };
    }

    services.factory('ActivityConcept', ['$resource', ActivityConcept]);
    services.factory('MultiActivityConceptLoader', ['ActivityConcept', '$q', MultiActivityConceptLoader]);
    services.factory('ActivityConceptLoader', ['ActivityConcept', '$route', '$q', ActivityConceptLoader]);
})();