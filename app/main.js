requirejs.config({
    paths: {
        'text': '/lib/text',
        'durandal': '/lib/durandal',
        'plugins': '/lib/durandal/plugins',
        'transitions': '/lib/durandal/transitions',
        'knockout': '/lib/knockout-3.1.0',
        'jquery': '/lib/jquery-1.10.2',
        'bootstrap': '/lib/bootstrap',
        'lodash': '/lib/lodash',
        'moment': '/lib/moment',
        'toastr': '/lib/toastr'

    }
});

define(['durandal/app', 'durandal/viewLocator', 'durandal/system'],
        function (app, viewLocator, system) {
            "use strict";

            system.debug(true);

            app.configurePlugins({
                router: true,
                dialog: true,
                observable: true
            });

            app.title = "Durandal JS Kickstart";

            app.start()
               .then(
                    function () {
                        viewLocator.useConvention();

                        app.setRoot('viewmodels/shell', 'entrance');
                    });
        });