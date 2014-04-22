define(['plugins/router', 'services/http', 'plugins/observable'],
    function (router, http, observable) {

        var self = {};

        self.title = "Projects";

        self.projects = [];

        self.name = "";

        observable.defineProperty(self, 'filteredProjects', function () {

            var filtered = [];

            for (var i = 0; i < self.projects.length; i++) {
                if (self.projects[i].Name.indexOf(self.name) !== -1) {
                    filtered.push(projects[i]);
                }
            }

            return filtered;

        });

        self.gotoDetails = function (selectedProject) {
            if (selectedProject && selectedProject.Id) {
                router.navigate('#/details/' + selectedProject.Id);
            }
        };

        self.removeProject = function (project) {
            self.projects.remove(project);
        };

        self.activate = function () {
            return http.get("projects")
                       .done(function (projects) {
                           self.projects = projects;
                       });
        };

        return self;

    });