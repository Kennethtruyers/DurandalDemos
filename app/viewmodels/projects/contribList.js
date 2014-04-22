define(function () {

        var ctor = function(contributors) {
            var self = this;

            self.contributors = contributors;

            return self;
        };

        return ctor;
    });