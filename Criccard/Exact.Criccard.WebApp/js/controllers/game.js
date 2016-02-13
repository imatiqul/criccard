'use strict';

var cricCardControllers = angular.module('cricCard.controllers', []);

cricCardControllers.controller('GameCtrl', ['$rootScope', '$scope', '$state', '$stateParams', 'GameService', function ($rootScope, $scope, $state, $stateParams, GameService) {
    $scope.model = {
        FirstTeam: {
            Name: '',
            IsBowlFirst: false
        },
        SecondTeam: {
            Name: '',
            IsBowlFirst: false
        }
    };

    $scope.toggleBowling = function () {
        $scope.model.FirstTeam.IsBowlFirst = !$scope.model.FirstTeam.IsBowlFirst;
        if (!$scope.model.FirstTeam.IsBowlFirst) {
            $scope.model.SecondTeam.IsBowlFirst = true;
        } else {
            $scope.model.SecondTeam.IsBowlFirst = false;
        }
    }

    $scope.selectcss = function (data) {
        if (data === true) {
            return 'up';
        } else {
            return 'down';
        }
    }

    $scope.onsuccess = function (result)
    {

    };

    $scope.onfailure = function (result) {

    };
    $scope.submit = function () {
        //submitted
        var game = GameService.createMatch($scope.model, $scope.onsuccess, $scope.onfaulure);
        if (game)
        {

        }
    };
}]);