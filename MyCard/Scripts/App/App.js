var app = angular.module('app',
    [
        
        'ngAria',
        'ngMaterial',
        'ngMessages',
        'ngAnimate'

    ]);



app.controller("AppController", ['$rootScope', '$scope','$mdSidenav', function ($rootScope, $scope, $mdSidenav) {
    console.log("I AppController");
    $scope.name = "ASLAN"
    $rootScope.openLeftNav = function () {
        $mdSidenav('left').toggle();
    };

    $rootScope.topDirections = ['left', 'up'];
    $rootScope.bottomDirections = ['down', 'right'];

    $rootScope.isOpen = false;

    $rootScope.availableModes = ['md-fling', 'md-scale'];
    $rootScope.selectedMode = 'md-fling';

    $rootScope.availableDirections = ['up', 'down', 'left', 'right'];
    $rootScope.selectedDirection = 'up';

}]);