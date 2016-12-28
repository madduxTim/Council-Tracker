app.controller("OrdinanceCTRL", function ($scope, $http) {
    $scope.test = () => {
        console.log("hey cowpoke. you've got the LandingCTRL working.");
    }
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