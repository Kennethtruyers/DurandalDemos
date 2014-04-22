define(['knockout', 'services/http', 'plugins/router'],
    function (ko, http, router) {

        var self = {};

        self.title = "Contributors";

        self.contributors = ko.observableArray();

        self.gotoDetail = function(contributor) {
            router.navigate('contributor/' + contributor.Id);
        };

        self.activate = function () {
            return http.get("contributors")
                       .done(function(result) {
                            self.contributors(result);
                        });
        };

        return self;

    });