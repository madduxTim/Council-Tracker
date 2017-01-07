app.controller("OrdinanceCTRL", function ($scope, $http, $routeParams, $sce, $location) {

    $scope.follow = (ordNumber) => {
        $http.post("/api/User/Ordinance/" + ordNumber);
    };
    
    $scope.signIn = () => {
        var ID = null;
        $http.get("/api/User")
        .success(function (response) {
            ID = response;
            $("#loginLink").append(`<input type='text' id='signInID' value='${ID}'/>`);
            $("#signInID").hide();
        })
        .error(function (error) {
            console.log(error);
        });
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
        }
        return $scope.ords;
    };

    $scope.ord = [];
    $scope.getOrd = (bill_number) => {
        var url = window.location.href.split("/");
        var number = url[url.length - 1];
        $http.get("/api/Ordinance/" + number)
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