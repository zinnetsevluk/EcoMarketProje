var app = angular.module("CustomerApp", []);

app.service("api", function ($http) {
    var apiUrl = "http://localhost:4770/musteri/";
    return {
        getAllCustomer: function (success) {
            $http({
                url: apiUrl + 'GetAllCustomer',
                method: 'GET',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        updateCustomer: function (model, success) {
            $http({
                url: apiUrl + 'UpdateCustomer',
                method: 'POST',
                data: model,
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        newCustomer: function (model, success) {
        
            $http({
                url: apiUrl + 'NewCustomer',
                method: 'POST',
                data: model,
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        }
    }
});

app.controller("CustomerCtrl", function ($scope, api) {
    $scope.customers = [];
    $scope.customer = {};
    $scope.isnew = false;
    $scope.isopen = false;
   
    function init() {
        api.getAllCustomer(function (response) {
            if (response.success)
                $scope.customers = response.data;
            else
                alert(response.message);
        });
    }
    $scope.duzenle = function (cus) {
        debugger;
        $scope.customer = cus;
    }
    $scope.guncelle = function (cus) {
        api.updateCustomer(cus, function (response) {
            if (response.success) {
                $scope.customer = {};
                $scope.isnew = false;
                $scope.isopen = false;
                init();
            } else
                alert(response.message);
        });
    }
    $scope.kaydet = function (cus) {
        api.newCustomer(cus, function (response) {
            if (response.success) {
                $scope.customer = {};
                init();
            } else
                alert(response.message);
        });
    }
    init();
});