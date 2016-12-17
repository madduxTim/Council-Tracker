var app = angular.module("CouncilTracker", []);

app.controller("OrdsCTRL", function ($scope, $http) {
    $scope.ords = [];
    $scope.running = false;
    $scope.getOrds = () => {
        if (!$scope.running) {
            $scope.running = true;
            $http.get("/api/Ordinance")
            .success(function (response) {
                $scope.ords = response;
            })
            .error(function (error) {
                console.log(error);
            });
        }
        return $scope.ords;
    };
});

//app.controller("ResolutionsCTRL", function ($scope) {
//    $scope.getResolutions = () => {

//    }
//});

//app.controller("CouncilMembersCTRL", function ($scope) {
//    $scope.getMembers = () => {

//    }
//});