define(['plugins/router', 'services/http'],
    function (router, http) {

    var self = {};

    self.title = "Projects";

    self.projects = [];

    self.gotoDetails = function (selectedProject) {
        if (selectedProject && selectedProject.Id) {
            router.navigate('#/details/' + selectedProject.Id);
        }
    };

    self.activate = function () {
        return http.get("projects")
                   .done(function(projects) {
                        self.projects = projects;
                    });
    };

    return self;

});