define(['services/http'],
    function (http) {

        var self = {};

        self.project = {};
        self.contributors = [];

        var loadItem = function (id) {
            return http.get("projects/" + id)
                       .done(function (proj) {
                           self.project = proj;
                       });
        };

        self.editing = false;

        self.save = function () {
            http.put("projects/" + self.project.Id, self.project);
        };

        self.edit = function () {
            self.editing = true;
        };


        self.cancel = function () {
            self.editing = false;
            return loadItem(self.project.Id);
        };

        self.activate = function (id) {
            self.editing = false;

            return loadItem(id);
        };

        return self;

    });