app.controller("ResolutionCTRL", function ($scope, $http, $routeParams, $sce) {
    $scope.allRes = [];
    $scope.running = false;
    $scope.getAllRes = () => {
        if (!$scope.running) {
            $scope.running = true;
            $http.get("/api/Resolution")
            .success(function (response) {
                $scope.allRes = response;
            })
            .error(function (error) {
                console.log(error);
            });
        };
        return $scope.allRes;
    };

    $scope.res = [];
    $scope.getRes = (bill_number) => {
        console.log("something's happening at least.");
        var url = window.location.href.split("/");
        var number = url[url.length - 1];
        $http.get("/api/Resolution/" + number)
            .success(function (response) {
                console.log(response);
                $scope.res = response;
                $scope.res.Body = $sce.trustAsHtml($scope.res.Body);
            })
            .error(function (error) {
                console.log(error);
            });
    };
    return $scope.res;
});