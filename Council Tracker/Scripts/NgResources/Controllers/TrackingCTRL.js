app.controller("TrackingCTRL", function ($scope, $http, $routeParams, $sce, $location) {

    $scope.ords = [];
    $scope.ordsrunning = false;
    $scope.getTrackedOrds = () => {
        if (!$scope.ordsrunning) {
            $scope.ordsrunning = true;
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

    $scope.allRes = [];
    $scope.resrunning = false;
    $scope.getTrackedRes = () => {
        if (!$scope.resrunning) {
            $scope.resrunning = true;
            $http.get("/api/Resolution")
            .success(function (response) {
                $scope.allRes = response;
            })
            .error(function (error) {
                console.log(error);
            });
        }
        return $scope.allRes;
    };
});