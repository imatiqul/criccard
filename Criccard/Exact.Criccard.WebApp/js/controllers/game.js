'use strict';

var cricCardControllers = angular.module('cricCard.controllers', []);

cricCardControllers.controller('GameCtrl', ['$rootScope', '$scope', '$state', '$stateParams', 'GameService', function ($rootScope, $scope, $state, $stateParams, GameService) {
    $scope.model = {
        firstTeam: {
            Name: '',
            IsBowlFirst: false
        },
        secondTeam: {
            Name: '',
            IsBowlFirst: false
        }
    };

    $scope.toggleBowling = function () {
        $scope.model.firstTeam.IsBowlFirst = !$scope.model.firstTeam.IsBowlFirst;
        if (!$scope.model.firstTeam.IsBowlFirst) {
            $scope.model.secondTeam.IsBowlFirst = true;
        } else {
            $scope.model.secondTeam.IsBowlFirst = false;
        }
    }

    $scope.selectcss = function (data) {
        if (data === true) {
            return 'up';
        } else {
            return 'down';
        }
    }
    $scope.submit = function () {
        ////submitted
        //var game = GameService.createMatch($scope.model);
        //if (game)
        //{

        //}
    };
}]);