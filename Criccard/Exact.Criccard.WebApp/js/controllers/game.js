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

    $scope.hasErrors = false;

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

    $scope.onSuccess = function (result) {
        $rootScope.model.game = result;
        $state.transitionTo('cricCard.playMatch', {
            gameID: $rootScope.model.game.ID,
            overNumber: $rootScope.model.overNumber,
            bowlNumber: $rootScope.model.bowlNumber
        });
    };

    $scope.onFailure = function (result) {
        $scope.hasErrors = true;
        $scope.message = 'Fail to create match. Please contact your administrator.'
    };

    $scope.submit = function () {
        if ((!$scope.model.FirstTeam.IsBowlFirst && !$scope.model.SecondTeam.IsBowlFirst)) {
            $scope.hasErrors = true;
            $scope.message = 'Choose who you want to ball.'
        } else if (!$scope.createMatchForm.$valid) {
            $scope.hasErrors = true;
            $scope.message = 'Please enter valid teams & select bowling team.'
        } else {
            GameService.createMatch($scope.model, $scope.onSuccess, $scope.onFailure);
        }
    };
}]);


cricCardControllers.controller('MatchCtrl', ['$rootScope', '$scope', '$state', '$stateParams', 'GameService', function ($rootScope, $scope, $state, $stateParams, GameService) {
    $scope.model = {
        game: $rootScope.model.game
    };

    $scope.init = function () {

    };
}]);
