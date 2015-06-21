(function() {
    var mainModule = angular.module("att.main", ["ngRoute", 'att.services', 'att.directives']);
    var services = angular.module('att.services', ['ngResource', 'ngCookies']);
    var directives = angular.module('att.directives', []);
    
    services.value('AUTH_ENDPOINT', '../api/login');
    services.value('LOGOUT_ENDPOINT', '../api/logout');
    
    var config = function ($routeProvider) {

        $routeProvider
            .when("/", {
                templateUrl: 'app/views/main.html',
                controller: 'MainController',
                resolve: {
                    user: function(Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    }
                }
            })

         /**************************************************
         *             Activity Concepts Routes
         **************************************************/

            .when('/activity_concepts', {
                controller: 'ActivityConceptController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function() {
                        return null;
                    },
                    items: function(MultiActivityConceptLoader) {
                        return MultiActivityConceptLoader();
                    },
                    filterRules: function() {
                        return null;
                    }
                },
                templateUrl:'app/views/activityconcept/list.html'
            })
            .when('/activity_concepts/edit/:activityConceptId', {
                controller: 'ActivityConceptController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function(ActivityConceptLoader) {
                        return ActivityConceptLoader();
                    },
                    items: function() {
                        return null;
                    },
                    filterRules: function(MultiFilterRuleLoader) {
                        return MultiFilterRuleLoader();
                    }
                },
                templateUrl:'app/views/activityconcept/form.html'
            })
            .when('/activity_concepts/view/:activityConceptId', {
                controller: 'ActivityConceptController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function(ActivityConceptLoader) {
                        return ActivityConceptLoader();
                    },
                    items: function() {
                        return null;
                    },
                    filterRules: function() {
                        return null;
                    }
                },
                templateUrl:'app/views/activityconcept/view.html'
            })
            .when('/activity_concepts/new', {
                controller: 'ActivityConceptController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function(ActivityConcept) {
                        return new ActivityConcept({});
                    },
                    items: function() {
                        return null;
                    },
                    filterRules: function(MultiFilterRuleLoader) {
                        return MultiFilterRuleLoader();
                    }
                },
                templateUrl:'app/views/activityconcept/form.html'
            })

        /**************************************************
         *             Filter Rules Routes
         **************************************************/

            .when('/filter_rules', {
                controller: 'FilterRuleController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function() {
                        return null;
                    },
                    items: function(MultiFilterRuleLoader) {
                        return MultiFilterRuleLoader();
                    }
                },
                templateUrl:'app/views/filterrule/list.html'
            })
            .when('/filter_rules/edit/:filterRuleId', {
                controller: 'FilterRuleController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function(FilterRuleLoader) {
                        return FilterRuleLoader();
                    },
                    items: function() {
                        return null;
                    }
                },
                templateUrl:'app/views/filterrule/form.html'
            })
            .when('/filter_rules/view/:filterRuleId', {
                controller: 'FilterRuleController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function(FilterRuleLoader) {
                        return FilterRuleLoader();
                    },
                    items: function() {
                        return null;
                    }
                },
                templateUrl:'app/views/filterrule/view.html'
            })
            .when('/filter_rules/new', {
                controller: 'FilterRuleController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    item: function(FilterRule) {
                        return new FilterRule({});
                    },
                    items: function() {
                        return null;
                    }
                },
                templateUrl:'app/views/filterrule/form.html'
            })

         /**************************************************
         *             Dashboard Routes
         **************************************************/
            .when('/dashboard', {
                controller: 'DashboardController',
                resolve: {
                    user: function (Authenticator, $q) {
                        return Authenticator.identity() || $q.reject({ unAuthorized: true });
                    },
                    measures: function(MultiMeasureLoader) {
                        return MultiMeasureLoader();
                    }
                },
                templateUrl:'app/views/dashboard/list.html'
            })


            .otherwise({
                redirectTo:'/dashboard'
            });
    };

    mainModule.config(config);
})();