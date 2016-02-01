angular.module("wscApp")
    .controller("gymCtrl",  function ($scope, gyms, $location) {

    $scope.gyms = gyms.data.Items;
    $scope.currentPage = gyms.data.Page;
    $scope.pageSize = 10;
    $scope.numberOfPages = gyms.data.TotalPages;

    //$scope.subtotals = srvCart.subtotals;
    //$scope.addToCart = srvCart.add;
    //$scope.removeFromCart = srvCart.remove;

    $scope.prev = function () {
        $location.path("/article/page/" + (gyms.data.Page - 1) + "/" + $scope.pageSize);
    };

    $scope.next = function () {
        $location.path("/article/page/" + (gyms.data.Page + 1) + "/" + $scope.pageSize);
    };
});