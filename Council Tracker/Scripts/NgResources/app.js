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
        }).
        when("/Ordinance/:ordinanceNumber", {
            templateUrl: "/NgPartials/_ordinance-template.html",
            controller: "OrdinanceCTRL"
        }).
        when("/Resolution/:resolutionNumber", {
            templateUrl: "/NgPartials/_resolution-template.html",
            controller: "ResolutionCTRL"
        });
        //when("/councilmember/:office", {
        //    templateUrl: "/NgPartials/_council-member.html",
        //    controller: "CouncilMemberCTRL"
        //}).
    //otherwise("/ordinance");

});



