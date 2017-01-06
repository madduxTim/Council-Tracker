app.controller("OrdinanceCTRL", function ($scope, $http, $routeParams, $sce, $location) {

    $scope.follow = () => {
        //if (user is !logged in) {
        alert("You need to signed in to do that! Please Register or Log.");
    //} else { api post } 
    }

    $scope.signIn = () => {
        console.log("blah");
        $("#loginLink").append("<div id='signInID' >hello!</div>");
        $("#signInID").hide();
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