app.controller("ResolutionCTRL", function ($scope, $http, $routeParams, $sce) {

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

    $scope.follow = (resNumber) => {
        if ($scope.userID == null)
        {
            alert("You need to be logged in for that!");
        }
        else
        {
            $http.post("/api/User/Resolution/" + resNumber);
            alert(`Resolution ${resNumber} has been added to your list!`);
        }
    };

    $scope.unfollow = (resNumber) => {
        if ($scope.userID == null) {
            alert("You need to be logged in for that!");
        }
        else {
            $http.delete("/api/User/Resolution/" + resNumber);
            alert(`Resolution ${resNumber} has been removed from your list!`);
        }
    };

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
        }
        return $scope.allRes;
    };

    $scope.res = [];
    $scope.getRes = (bill_number) => {
        var url = window.location.href.split("/");
        var number = url[url.length - 1];
        $http.get("/api/Resolution/" + number)
            .success(function (response) {
                $scope.res = response;
                $scope.res.Body = $sce.trustAsHtml($scope.res.Body);
            })
            .error(function (error) {
                console.log(error);
            });
    };
    return $scope.res;
});