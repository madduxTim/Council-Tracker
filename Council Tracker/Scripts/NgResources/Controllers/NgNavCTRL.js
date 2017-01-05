app.controller("NgNavCTRL", function ($scope, $location) {
    $scope.showOrds = () => {
        //console.log("hey cowpoke, you've got the NgNavCTRL workin'.");
        $location.url("/Ordinance");
    };
    $scope.showAllRes = () => {
        $location.url("/Resolution");
    };
});