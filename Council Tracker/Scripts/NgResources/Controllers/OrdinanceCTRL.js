app.controller("OrdinanceCTRL", function ($scope, $http) {
    $scope.test = () => {
        console.log("hey cowpoke. you've got the OrdinanceCTRL working.");
    };
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
        };
        return $scope.ords;
    };

    $scope.ord = {};
    $scope.getOrd = (ordNumber) => {
        if (!$scope.running) {
            $scope.running = true;
            $http.get("/api/Ordinance")
                .success(function (response) {
                    $scope.ord = response;
                })
                .error(function (error) {
                    console.log(error);
                });
        };
        return $scope.ord;
    };