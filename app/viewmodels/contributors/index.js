define(['knockout', 'services/http'],
    function (ko, http) {

        var self = {};

        self.title = "Contributors";

        self.contributors = ko.observableArray();

        self.activate = function () {
            return http.get("contributors")
                       .done(function(result) {
                            self.contributors(result);
                        });
        };

        return self;

    });