angular.module('contactapp.controllers', [])
    .constant("contactUrl", "http://localhost:59141/api/contact/GetAllContact")
    .constant("addcontactUrl", "http://localhost:59141/api/contact/Post")
    .controller('ContactController', function ($scope, $http, contactUrl, addcontactUrl, $location) {

        $scope.getToken = function () {
            var token = $.parseJSON(localStorage.getItem('Token'));
            if (token == null) {
                $location.path("/");
            }
            return token.access_token;
        };

        $scope.GetServerToken = function () {
            $.ajax({
                type: "POST",
                url: "http://localhost:59141/token",
                dataType: "json",
                data: { "grant_type": "password", "username": this.user.username, "password": this.user.password },
                success: function (result) {
                    localStorage.setItem('Token', JSON.stringify(result));
                    $scope.getContacts();
                    window.location = "#/Contacts";
                }, error: function (err) {
                    alert("Username or Password in correct")
                }
            });
        };

        $scope.getContacts = function () {
            var accessToken = $scope.getToken();
            $scope.data = {};
            $http.get(contactUrl, {
                headers: {
                    "accept": "application/json",
                    "content-type": "application/json",
                    "Authorization": "Bearer " + accessToken
                }
            }).
            success(function (data) {
                $scope.data.contacts = data;
            }).error(function (error) {
                $scope.data.error = error;
            });
        }

        $scope.getContacts();

        $scope.saveContact = function () {
            console.log(this.newcontact)
            var accessToken = $scope.getToken();
            $http.post(addcontactUrl, this.newcontact, {
                headers: {
                    "accept": "application/json",
                    "content-type": "application/json",
                    "Authorization": "Bearer " + accessToken
                }
            }).success(function (data) {
                $scope.getContacts();
                $location.path("#Contacts");
            }).error(function (data) {
                
            });
        };

        $scope.DeleteContact = function () {
            console.log(this.contact)
            var accessToken = $scope.getToken();
            $http.post("http://localhost:59141/api/contact/Delete", this.contact, {
                headers: {
                    "accept": "application/json",
                    "content-type": "application/json",
                    "Authorization": "Bearer " + accessToken
                }
            }).success(function (data) {
                $scope.getContacts();
                $location.path("#Contacts");
            }).error(function (data) {
                
            });
        };

        $scope.Login = function () {
            console.log(this.user);
            $http.post("http://localhost:59141/api/user/UserAuthentication", this.user).
            success(function (data) {
                if (data) {
                    $scope.GetServerToken();
                }
            }).error(function (error) {
                alert(error)
            });
        };
    })
    .controller('updatecontroller', function ($scope, $routeParams, $http, $location) {
        console.log($routeParams);
        $scope.getToken = function () {
            var token = $.parseJSON(localStorage.getItem('Token'));
            if (token == null) {
                alert("Unauthorized Request");
                return;
            }
            return token.access_token;
        }

        var accessToken = $scope.getToken();
        $http.get("http://localhost:59141/api/contact/GetContact/" + $routeParams.ContactId, {
            headers: {
                "accept": "application/json",
                "content-type": "application/json",
                "Authorization": "Bearer " + accessToken
            }
        }).
             success(function (data) {
                 $scope.contact = {};
                 console.log(data);
                 $scope.contact = data;
             }).error(function (error) {
                 $scope.data.error = error;
             });

        $scope.updateContact = function () {
            console.log(this.contact)
            var accessToken = $scope.getToken();
            $http.post("http://localhost:59141/api/contact/Update", this.contact, {
                headers: {
                    "accept": "application/json",
                    "content-type": "application/json",
                    "Authorization": "Bearer " + accessToken
                }
            }).success(function (data) {
                $location.path("#Contacts");

            }).error(function (data) {
                $scope.loading = false;
            });
        };
    });