var app = angular.module("CouncilTracker", ["ngRoute"]);

//Route Config 
app.config(function ($routeProvider) {
    $routeProvider.
        when("/Ordinance", {
            templateUrl: "NgPartials/_ordinance.html",
            controller: "OrdinanceCTRL"
        }).
        when("/Resolution", {
            templateUrl: "NgPartials/_resolution.html",
            controller: "ResolutionCTRL"
        }).
        when("/CouncilMember", {
            templateUrl: "NgPartials/_council-member.html",
            controller: "CouncilMemberCTRL"
        });

        //when("/ordinance/:ordinanceNumber", {
        //    templateUrl: "/NgPartials/_ordinance.html",
        //    controller: "LandingCTRL"
        //}).
        //when("/resolution/:resolutionNumber", {
        //    templateUrl: "/NgPartials/_resolution.html",
        //    controller: "LandingCTRL"
        //}).
        //when("/councilmember/:office", {
        //    templateUrl: "/NgPartials/_council-member.html",
        //    controller: "CouncilMemberCTRL"
        //}).
    //otherwise("/ordinance");

});

//Controllers
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

app.controller("ResolutionCTRL", function ($scope) {
    $scope.test = () => {
        console.log("hey, here's the ResolutionCTRL .");
    }
});

app.controller("CouncilMemberCTRL", function ($scope) {
    $scope.test = () => {
        console.log("hey cowpoke, you've got the councilmemberCTRL workin'.");
    }
});