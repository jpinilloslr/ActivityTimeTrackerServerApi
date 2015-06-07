
(function() {
    var services = angular.module('att.services');

    var FilterRule = function ($resource) {
        return $resource('../api/filterrule/:id', { id: '@id' });
    };

    var MultiFilterRuleLoader = function(FilterRule, $q) {
        return function() {
            var delay = $q.defer();
            FilterRule.query(function(filterRules) {
                delay.resolve(filterRules);
            }, function() {
                delay.reject('Unable to fetch filter rules');
            });
            return delay.promise;
        };
    };

    var FilterRuleLoader = function(FilterRule, $route, $q) {
        return function() {
            var delay = $q.defer();
            FilterRule.get({id: $route.current.params.filterRuleId}, function(filterRule) {
                delay.resolve(filterRule);
            }, function() {
                delay.reject('Unable to fetch filter rule ' + $route.current.params.filterRuleId);
            });
            return delay.promise;
        };
    }

    services.factory('FilterRule', ['$resource', FilterRule]);
    services.factory('MultiFilterRuleLoader', ['FilterRule', '$q', MultiFilterRuleLoader]);
    services.factory('FilterRuleLoader', ['FilterRule', '$route', '$q', FilterRuleLoader]);
})();