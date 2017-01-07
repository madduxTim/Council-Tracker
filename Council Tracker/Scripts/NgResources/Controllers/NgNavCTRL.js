app.controller("NgNavCTRL", function ($scope, $location) {
    $scope.showOrds = () => {
        $location.url("/Ordinance");
    };
    $scope.showAllRes = () => {
        $location.url("/Resolution");
    };
    $scope.showAllMembers = () => {
        $location.url("/CouncilMember");
    };
});