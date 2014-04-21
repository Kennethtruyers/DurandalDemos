define(['knockout', 'jquery'], function (ko, $) {
    var base = "/api/";

    return {
        get: function (url) {
            return $.ajax({
                dataType: "json",
                url: base + url
            }).promise();
        },
        post: function (url, obj) {
            return $.ajax({
                type: "POST",
                url: base + url,
                data: ko.toJSON(obj),
                contentType: "application/json"
            }).promise();
        },
        put: function (url, obj) {
            return $.ajax({
                type: 'PUT',
                url: base + url,
                data: ko.toJSON(obj),
                dataType: 'json',
                processData: false,
                contentType: 'application/json'
            }).promise();
        },
        delete: function (url) {
            return $.ajax({
                type: 'DELETE',
                url: base + url,
                contentType: 'application/json'
            }).promise();
        }
    };
});