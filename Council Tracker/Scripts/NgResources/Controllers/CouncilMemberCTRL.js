app.controller("CouncilMemberCTRL", function ($scope, $http, $routeParams, $sce) {
    $scope.members = [];
    $scope.running = false;
    $scope.getMembers = () => {
        if (!$scope.running) {
            $scope.running = true;
            $http.get("/api/Member")
            .success(function (response) {
                $scope.members = response;
            })
            .error(function (error) {
                console.log(error);
            });
        }
        return $scope.members;
    };

    $scope.member = [];
    $scope.getMember = (id) => {
        var url = window.location.href.split("/");
        var id = url[url.length - 1];
        $http.get("/api/Member/" + id)
            .success(function (response) {
                $scope.member = response;
                console.log(response);
            })
            .error(function (error) {
                console.log(error);
            });
    };
    return $scope.member;
});