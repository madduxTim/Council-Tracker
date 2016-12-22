var app = angular.module("CouncilTracker", ["ngRoute"]);

//Route Config 
app.config(function ($routeProvider) {
    $routeProvider.
        when("/index", {
            templateUrl: "/NgPartials/_index.html",
            controller: "IndexCTRL"
        }).
        when("/ordinance/:ordinanceNumber", {
            templateUrl: "/NgPartials/_ordinance.html",
            controller: "IndexCTRL"
        }).
        when("/resolution/:resolutionNumber", {
            templateUrl: "/NgPartials/_resolution.html",
            controller: "IndexCTRL"
        }).
        when("/councilmember/:office", {
            templateUrl: "/NgPartials/_council-member.html",
            controller: "CouncilMemberCTRL"
        });
    //otherwise("/index");
});

//Controllers
app.controller("IndexCTRL", function ($scope, $http) {
    $scope.test = () => {
        console.log("hey cowpoke. you've got the IndexCTRL working.");
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

app.controller("CouncilMemberCTRL", function ($scope) {
    $scope.test = () => {
        console.log("hey cowpoke, you've got the councilmemberCTRL workin'.");
    }
});