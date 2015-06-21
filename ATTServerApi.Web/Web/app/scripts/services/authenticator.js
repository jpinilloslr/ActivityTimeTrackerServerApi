(function() {
    var services = angular.module('att.services');

    var Authenticator = function (AUTH_ENDPOINT, LOGOUT_ENDPOINT, $http, $cookieStore) {
        var auth={};

        auth.login = function(username, password) {
            return $http.post(AUTH_ENDPOINT, { username: username, password: password }).then(function(response, status) {
                auth.user = response.data;
                $cookieStore.put('user', auth.user);
                return auth.user;
            });
        };

        auth.logout = function () {
            return $http.post(LOGOUT_ENDPOINT).then(function (response) {
                auth.user = undefined;
                $cookieStore.remove('user');
            });
        };

        auth.identity = function() {
            return $cookieStore.get('user');
        };

        return auth;
    };

    services.factory('Authenticator', [
        'AUTH_ENDPOINT',
        'LOGOUT_ENDPOINT',
        '$http',
        '$cookieStore',
        Authenticator]);
})();