(function() {
    var mainModule = angular.module("att.main");

    var LoginController = function ($scope, $resource, Authenticator) {
        
        $scope.buttonText = "Login";
        $scope.identity = Authenticator.identity();

        $scope.login = function() {
            $scope.buttonText = "Logging in. . .";
            Authenticator.login($scope.credentials.username, $scope.credentials.password).then(onSuccess, onError).finally(function() {
                $scope.buttonText = "Login";
            });
        };
        
        $scope.logout = function () {
            Authenticator.logout().then(function () {
                window.location.href = "login.html";
            });
        };

        var onSuccess = function(data) {
            window.location.href = ".";
        };
        
        var onError = function (error) {
            $scope.invalidLogin = true;
        };        
    };

    mainModule.controller("LoginController", LoginController);
})();