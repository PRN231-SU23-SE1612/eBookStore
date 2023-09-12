// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function (evt) {
    evt.preventDefault();
    let token = $.cookie("access_token");
    $.ajax(
        {
            url: 'http://localhost:7000/api/User/Admin',
            type: 'GET',
            dataType: 'json',
            async: true,
            headers: {
                'Authorization': token
            }
        }).done(function (data) { })
        .fail((function (xhr, status, error) {
            switch (xhr.status) {
                case 401:
                    window.location = 'https://localhost:7185/Auth/Login';
                    break;
                default:
                    alert("something went wrong.\n" + xhr.status + " " + xhr.statusText)
            }
        }));
});