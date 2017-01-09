var app = angular.module("CouncilTracker", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.
        when("/Ordinance", {
            templateUrl: "/NgPartials/_ordinance.html",
            controller: "OrdinanceCTRL"
        }).
        when("/Ordinance/:ordinanceNumber", {
            templateUrl: "/NgPartials/_ordinance-template.html",
            controller: "OrdinanceCTRL"
        }).
        when("/Resolution", {
            templateUrl: "/NgPartials/_resolution.html",
            controller: "ResolutionCTRL"
        }).
        when("/Resolution/:resolutionNumber", {
            templateUrl: "/NgPartials/_resolution-template.html",
            controller: "ResolutionCTRL"
        }).
        when("/CouncilMember", {
            templateUrl: "/NgPartials/_council-members.html",
            controller: "CouncilMemberCTRL"
        }).
        when("/CouncilMember/:ID", {
            templateUrl: "/NgPartials/_council-member-template.html",
            controller: "CouncilMemberCTRL"
        }).
        when("/Tracking", {
            templateUrl: "/NgPartials/_tracking-list.html",
            controller: "TrackingCTRL"
        });
});



