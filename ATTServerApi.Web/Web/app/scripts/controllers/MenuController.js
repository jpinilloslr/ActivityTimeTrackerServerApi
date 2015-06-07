(function() {
    var mainModule = angular.module("att.main");

    var MenuController = function($scope, $location) {
        var entries = [{
            text: "Home",
            customClass: "glyphicon glyphicon-home",
            url: "#/",
            active: ""
        }, {
            text: "Dashboard",
            customClass: "glyphicon glyphicon-dashboard",
            url: "#/dashboard",
            active: ""
        }, {
            text: "Activity concepts",
            customClass: "glyphicon glyphicon-record",
            url: "#/activity_concepts",
            active: ""
        }, {
            text: "Filters",
            customClass: "glyphicon glyphicon-filter",
            url: "#/filter_rules",
            active: ""
        }];
        
        
        $scope.getEntries = function() {
            for (var i = 0; i < entries.length; i++) {
                if ("#" + $location.url() == entries[i].url)
                    entries[i].active = "active";
                else
                    entries[i].active = "";
            }
            return entries;
        };
    };

    mainModule.controller("MenuController", [
        '$scope',
        '$location',        
        MenuController
    ]);
})();