var app = angular.module("CouncilTracker", ["ngRoute"]);

//Route Config 
app.config(function ($routeProvider) {
    $routeProvider.
        when("/landing", {
            templateUrl: "NgPartials/_landing.html",
            controller: "LandingCTRL"
        }).
        when("/ordinance/:ordinanceNumber", {
            templateUrl: "/NgPartials/_ordinance.html",
            controller: "LandingCTRL"
        }).
        when("/resolution/:resolutionNumber", {
            templateUrl: "/NgPartials/_resolution.html",
            controller: "LandingCTRL"
        }).
        when("/councilmember/:office", {
            templateUrl: "/NgPartials/_council-member.html",
            controller: "CouncilMemberCTRL"
        }).
    otherwise("/landing");
});

//Controllers
app.controller("LandingCTRL", function ($scope, $http) {
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

app.controller("CouncilMemberCTRL", function ($scope) {
    $scope.test = () => {
        console.log("hey cowpoke, you've got the councilmemberCTRL workin'.");
    }
});