define(['services/http', 'toastr', './contribList', './emptyContrib', 'plugins/dialog'],
    function (http, toastr, contribList, emptyContrib, dialog) {

        var self = {};

        self.project = {};
        self.contributors = [];

        self.contribView = null;

        var loadItem = function (id) {
            return http.get("projects/" + id)
                       .done(function (proj) {
                           self.project = proj;

                           if (self.project.Contributors.length > 1) {
                               self.contribView = new contribList(self.project.Contributors);
                           } else {
                               self.contribView = new emptyContrib();
                           }
                       });
        };

        self.editing = false;

        self.save = function () {
            http.put("projects/" + self.project.Id, self.project)
                .done(function() {
                    toastr.success("Succesfully saved " + self.project.Name);
                });
        };

        self.edit = function () {
            self.editing = true;
        };


        self.cancel = function () {
            self.editing = false;
            return loadItem(self.project.Id);
        };

        self.canDeactivate = function() {
            return dialog.showMessage("Are you sure?", "Do you want to leave?", ["Yes", "No"]);
        };

        self.activate = function (id) {
            self.editing = false;

            return loadItem(id);
        };

        return self;

    });