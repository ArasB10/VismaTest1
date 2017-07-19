var app = angular.module("testApp", ["ngRoute", 'angular-toArrayFilter']);

app.config(function ($routeProvider, $locationProvider, $httpProvider) {

    $httpProvider.defaults.withCredentials = true;

    $routeProvider
        .when("/list", {
            templateUrl: "/Templates/Contacts/listContact.html",
            controller: "controllerList"
        })
        .when("/contact/:id", {
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
        })
        .when("/login", {
            templateUrl: "/Templates/Login/login.html",
            controller: "controllerLogin"
        });


    $locationProvider.html5Mode(true);

})

    .service('authInterceptor', function ($q) { //custom interceptorius

        var service = this;

        service.responseError = function (response) {

            if (response.status === 401) { //jeigu is api gauname 401 (unauthorised) errora 
                window.location = "/login"; //redirectiname useri i login langa
            }
            return $q.reject(response);

        };

    })

    .config(['$httpProvider', function ($httpProvider) {

        $httpProvider.interceptors.push('authInterceptor'); //interceptorius

    }]);


app.controller('controllerList', function ($scope, $http, $route) {
    var self = this;
    var uri = 'http://localhost:55946/api/Contact/';

    $http({
        method: 'GET',
        url: 'http://localhost:55946/api/Contact/'
    }).then(function (response) {
        self.contacts = response.data;
    });


    //$http.get(uri).
    //    then(function (response) {
    //        self.contacts = response.data;
    //    });

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

app.controller('controllerCreate', function ($http, $location, $route) {
    var self = this;

    self.contact = {
        firstName: "Required",
        lastName: "Required",
        email: "Required",
        phone: "Required"
    };

    self.isShown = true;

    self.create = function () {

        self.contact.phone = globalNumber(self.contact.phone);

        $http({
            method: 'POST',
            url: 'http://localhost:55946/api/Contact',
            data: self.contact
        }).then(function (response) {
            $location.url("/list");
        });
    };

    self.hi = function () {
        self.isShown = !self.isShown;
        alert(self.isShown);
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

        self.contact.Phone = globalNumber(self.contact.Phone);

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

app.controller('controllerSend', function ($http, $route) {
    var self = this;

    self.message = {
        Text: "",
        ContactsId: 0
    };

    self.send = function (number) {
        $http({
            method: 'POST',
            url: 'http://localhost:55946/api/Message',
            params: { id: number },
            data: self.message
        }).then(function (response) {
            $route.reload();
        });

        //alert(self.message + number);
    };
});

app.controller('controllerLogin', function ($http) {
    var self = this;
    self.login = function () {
        $http({
            method: 'GET',
            url: 'http://localhost:55946/api/login',
            headers: {
                'Location': "http://localhost:55885/list"
            }
        }).then(function (response) {
            alert(response.data);
        });
    };
});



