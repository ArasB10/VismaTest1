var app = angular.module("testApp", ["ngRoute", 'angular-toArrayFilter']);


String.prototype.replaceAt = function (index, replacement) {
    return this.substr(0, index) + replacement + this.substr(index + 1);
};

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



app.controller('controllerList', function ($scope, $http, $route) {
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
        firstName: "Required",
        lastName: "Required",
        email: "Required",
        phone: "Required"
    };

    self.create = function () {

        if (self.contact.phone.charAt(0) === "8") {

            self.contact.phone = self.contact.phone.replaceAt(0, "+370");
        }

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

        if (self.contact.Phone.charAt(0) === "8") {

            self.contact.Phone = self.contact.Phone.replaceAt(0, "+370");
        }

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



