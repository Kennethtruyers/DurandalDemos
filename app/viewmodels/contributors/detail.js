define(['services/http', 'plugins/observable'],
    function (repo, observable) {

        var self = {};

        self.contributor = {};

        observable.defineProperty(self, 'FullName', function() {
            return self.contributor.FirstName + ' ' + self.contributor.LastName;
        });

        self.activate = function (id) {
            return repo.get('contributors/' + id)
                       .done(function (result) {
                           self.contributor = result;
                       });
        };

        return self;

    });