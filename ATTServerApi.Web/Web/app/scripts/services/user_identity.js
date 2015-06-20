(function() {
    var services = angular.module('att.services');

    var UserIdentity = function () {
        var setCookie = function(name, value, expires, path, domain, secure) {
            document.cookie = name + "=" + escape(value) +
                ((expires) ? "; expires=" + expires : "") +
                ((path) ? "; path=" + path : "") +
                ((domain) ? "; domain=" + domain : "") +
                ((secure) ? "; secure" : "");
        };

        var getCookieVal = function(offset) {
            var endstr = document.cookie.indexOf(";", offset);
            if (endstr == -1) {
                endstr = document.cookie.length;
            }
            return unescape(document.cookie.substring(offset, endstr));
        };

        var getCookie = function(name) {
            var arg = name + "=";
            var alen = arg.length;
            var clen = document.cookie.length;
            var i = 0;
            while (i < clen) {
                var j = i + alen;
                if (document.cookie.substring(i, j) == arg) {
                    return getCookieVal(j);
                }
                i = document.cookie.indexOf(" ", i) + 1;
                if (i == 0) break;
            }
            return "";
        };


        return {
            setIdentity: function(identity) {
                setCookie("att_u", identity.username);
                setCookie("att_p", identity.password);
            },
            getIdentity: function() {
                var identity = {};
                identity.username = getCookie("att_u");
                identity.password = getCookie("att_p");
                return identity;
            }
        };
    };

    services.factory('UserIdentity', UserIdentity);
})();