app.controller("OrdinanceCTRL", function ($scope, $http, $routeParams) {
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

    $scope.ord = [];
    $scope.getOrd = (bill_number) => {
        var x = window.location.href.split("/");
        var y = x[x.length - 1];
        //console.log(bill_number);
        //console.log(window.location.href.split("/")[x.length-1]);
        //console.log(window.location);
        console.log(y);
        $http.get("/api/Ordinance/" + y)
            .success(function (response) {
                $scope.ord = response;
                //console.log($routeParams);
                console.log(response);
                console.log($scope.ord);
            })
            .error(function (error) {
                console.log(error);
            });
        return $scope.ords;
    };
});