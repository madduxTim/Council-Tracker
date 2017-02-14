app.controller("OrdinanceCTRL", function ($scope, $http, $routeParams, $sce) {

    $scope.userID = null;
    $scope.signIn = () => {
        $http.get("/api/User")
        .success(function (response) {
            $scope.userID = response;
        })
        .error(function (error) {
            console.log(error);
        })
    };

    $scope.follow = (ordNumber) => {
        if ($scope.userID == null) {
            alert("You need to be logged in for that!");
        }
        else {
            $http.post("/api/User/Ordinance/" + ordNumber);
            alert(`Ordinance ${ordNumber} has been added to your list!`);
        }
    };

    $scope.unfollow = (ordNumber) => {
        if ($scope.userID == null) {
            alert("You need to be logged in for that!");
        }
        else {
            $http.delete("/api/User/Ordinance/" + ordNumber);
            alert(`Ordinance ${ordNumber} has been removed from your list!`);
        }
    };

    $scope.allOrds = [];
    $scope.running = false;
    $scope.getOrds = () => {
        if (!$scope.running) {
            $scope.running = true;
            $http.get("/api/Ordinance")
            .success(function (response) {
                $scope.allOrds = response;
            })
            .error(function (error) {
                console.log(error);
            });
        }
        return $scope.allOrds;
    };

    $scope.ord = [];
    $scope.getOrd = () => {
            var number = $routeParams.ordinanceNumber;
            $http.get(`/api/Ordinance/${number}`)
            .success(function (response) {
                $scope.ord = response;
                $scope.ord.Body = $sce.trustAsHtml($scope.ord.Body);
            })
            .error(function (error) {
                console.log(error);
            });
    };
    return $scope.ord;
    
});