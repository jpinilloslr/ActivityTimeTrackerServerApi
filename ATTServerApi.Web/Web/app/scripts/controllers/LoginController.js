(function() {
    var mainModule = angular.module("att.main");

    var LoginController = function ($scope, $resource, UserIdentity, $location) {

        var onSuccess = function(data) {
            UserIdentity.setIdentity(data);
            $location.path("Web/index.html#/dashboard");
            window.location.href = ".";
        };
        
        var onError = function (error) {
            console.log("success: " + error);
        };
        
        $scope.login = {
            username: "joaquin",
            password: "knock123",
        };

        $scope.doLogin = function() {
            var res = $resource('../api/user/:id', { id: '@id' });
            res.save($scope.login, onSuccess, onError);
        };
    };

    mainModule.controller("LoginController", LoginController);
})();