var app = angular.module("Homeapp", []);

app.filter("mydate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var m = x.match(re);
        if (m) return new Date(parseInt(m[1]));
        else return null;
    };
});

app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "Encrypt";
    $scope.encrypt = function () {
        $scope.btntext = "Encrypting";
        $http({
            method: 'POST',
            url: '/Home/AddMessage',
            data: $scope.message
        }).then(function successCallback(response) {
            $scope.btntext = "Encrypt";
            $scope.message = null;
            $scope.messages.push(response.data);
            alert("Success");
        }, function errorCallback(response) {
            alert("Failed");
        });
    };

    $http.get("/Home/GetMessages").then(function (response) {
        $scope.messages = response.data;
    }, function (responce) {
        alert('Failed');
    });
});