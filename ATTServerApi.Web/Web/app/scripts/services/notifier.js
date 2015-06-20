(function() {
    var services = angular.module('att.services');

    var Notifier = function () {
        var addEntry = function (text, type) {
            var code =
                "<div style='display: none' class='alert alert-" + type + " alert-dismissable'>" +
                "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>" +
                text + 
                "</div>";
            var content = $("#notifier");
            content.html(content.html() + code);

            $("#notifier .alert").fadeIn(1000);

        };

        return {
            success: function (text) {
                addEntry(text, "success");
            },
            info: function (text) {
                addEntry(text, "info");
            },
            warning: function (text) {
                addEntry(text, "warning");
            },
            error: function (text) {
                addEntry(text, "danger");
            },
            clear: function () {
                $("#notifier .alert").fadeOut(200, function() {
                    $("#notifier").html("");
                });
            }
        };
    };

    services.factory('Notifier', Notifier);
})();