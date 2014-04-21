define(['plugins/router'],
    function (router) {
        'use strict';

        var self = {};

        self.router = router;

        self.activate = function() {

            router.makeRelative({ moduleId: 'viewmodels' })
                .map([
                    { route: '',                title: 'Projects',          moduleId: 'projects/index',     nav: true },
                    { route: 'contributors',    title: 'Contributors',      moduleId: 'contributors/index', nav: true },
                    { route: 'details/:id',     title: 'Project detail',    moduleId: 'projects/detail',    nav: false },
                    { route: 'about',           title: 'About us',          moduleId: 'about/index',        nav: true}
                ])
                .buildNavigationModel();

            return router.activate();
        };

        return self;
});