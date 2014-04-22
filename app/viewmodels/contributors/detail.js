define(['services/http'],
    function (repo) {

        var self = {};

        self.contributor = {};

        self.activate = function (id) {
            return repo.get('contributors/' + id)
                       .done(function (result) {
                           self.contributor = result;
                       });
        };

        return self;

    });