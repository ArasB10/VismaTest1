var app = angular.module("testApp", ["ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider


        .when("/details/:id", {
            templateUrl: "/Templates/Contacts/detailsContact.html",
            controller: "controllerDetails"
        })


        .when("/create", {
            templateUrl: "/Templates/Contacts/createContact.html",
            controller: "controllerCreate"
        });

});




app.controller('controllerList', function ($http) {
    var self = this;
    var uri = 'http://localhost:55946/api/Contact/';

    $http.get(uri).
        then(function (response) {
            self.contacts = response.data;

        });

    self.delete = function (contact) {



        $http.delete(uri + contact.Id).then(

            function (response) {

                var index = self.contacts.indexOf(contact);


                self.contacts.splice(index, 1);

            },

            function (response) {

                alert('error');

            }

        );
    };
});

app.controller('controllerCreate', function ($http) {
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
            alert('Suveike');
        });
    };
});

app.controller('controllerDetails', function ($http, $routeParams) {
    var self = this;
    $http({
        method: 'GET',
        url: 'http://localhost:55946/api/Contact',
        params: { id: $routeParams.id }

    }).then(function (response) {
        self.contact = response.data;
    });
});



