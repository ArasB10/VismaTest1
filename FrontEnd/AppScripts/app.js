var app = angular.module("testApp", ["ngRoute"]);


app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/list", {
            templateUrl: "/Templates/Contacts/listContact.html",
            controller: "controllerList"
        })
        .when("/details/:id", {
            templateUrl: "/Templates/Contacts/detailsContact.html",
            controller: "controllerDetails"
        })
        .when("/create", {
            templateUrl: "/Templates/Contacts/createContact.html",
            controller: "controllerCreate"
        })
        .when("/edit/:id", {
            templateUrl: "/Templates/Contacts/editContact.html",
            controller: "controllerEdit"
        });

    $locationProvider.html5Mode(true);
});



app.controller('controllerList', function ($http, $route) {
    var self = this;
    var uri = 'http://localhost:55946/api/Contact/';

    $http.get(uri).
        then(function (response) {
            self.contacts = response.data;
        });

    self.delete = function (contact) {



        $http.delete(uri + contact.Id).then(

            function (response) {
                $route.reload();
            },

            function (response) {

                alert('error');

            }

        );
    };
});

app.controller('controllerCreate', function ($http, $location) {
    var self = this;
    self.contact = {
        firstName: "Test firstName",
        lastName: "Test lastName",
        email: "arasbraziunas@gmail.com",
        phone: "862959639"
    };

    self.create = function () {
        $http({
            method: 'POST',
            url: 'http://localhost:55946/api/Contact',
            data: self.contact
        }).then(function (response) {
            $location.url("/list");
        });
    };
});

app.controller('controllerDetails', function ($http, $routeParams) {
    var self = this;
    $http({
        method: 'GET',
        url: 'http://localhost:55946/api/Contact/',
        params: { id: $routeParams.id }

    }).then(function (response) {
        self.contact = response.data;
    });
});

app.controller('controllerEdit', function ($http, $routeParams, $location) {
    var self = this;
    $http({
        method: 'GET',
        url: 'http://localhost:55946/api/Contact/',
        params: { id: $routeParams.id }

    }).then(function (response) {
        self.contact = response.data;
    });



    self.edit = function () {
        $http({
            method: 'PUT',
            url: 'http://localhost:55946/api/Contact',
            params: { id: $routeParams.id },
            data: self.contact
            
        }).then(function (response) {
            $location.url("/list");
        });
    };
});



