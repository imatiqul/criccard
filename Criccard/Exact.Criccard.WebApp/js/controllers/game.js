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
    $scope.hasSubmitted = false;

    $scope.toggleBowling = function (team) {

        switch (team) {
            case 'FirstTeam':
                $scope.model.FirstTeam.IsBowlFirst = true;
                $scope.model.SecondTeam.IsBowlFirst = false;
                break;
            case 'SecondTeam':
                $scope.model.FirstTeam.IsBowlFirst = false;
                $scope.model.SecondTeam.IsBowlFirst = true;
                break;
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
        $scope.hasSubmitted = false;
        $rootScope.model.game = result;
        $state.transitionTo('cricCard.playMatch', {
            gameID: $rootScope.model.game.ID,
            overNumber: $rootScope.model.overNumber,
            bowlNumber: $rootScope.model.bowlNumber
        });
    };

    $scope.onFailure = function (result) {
        $scope.hasSubmitted = false;
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
            $scope.hasSubmitted = true;
            GameService.createMatch($scope.model, $scope.onSuccess, $scope.onFailure);
        }
    };
}]);

cricCardControllers.controller('MatchCtrl', ['$rootScope', '$scope', '$state', '$stateParams', 'GameService', function ($rootScope, $scope, $state, $stateParams, GameService) {
    $scope.model = {
        game: $rootScope.model.game,
        bowl: {
            Number: 0,
            Run: 0,
            IsWide: false,
            Over: {
                OverNumber: 0,
                Team: {
                    Name: ''
                }
            }
        },
        bowls: [{}],
        score: 0
    };
    $scope.paused = false;
    $scope.hasErrors = true;

    $scope.init = function () {
        $scope.model.game.FirstTeam.Score = 0;
        $scope.model.game.SecondTeam.Score = 0;
    };
    $scope.init();

    $scope.onSuccess = function (result) {
        if (result) {
            $scope.paused = false;
            $scope.model.bowl = result;
            $scope.model.bowls.push($scope.model.bowl)
            $scope.model.score += $scope.model.bowl.Run;
            var params = {
                gameID: $rootScope.model.game.ID,
                overNumber: $scope.model.bowl.Over.OverNumber,
                bowlNumber: $scope.model.bowl.Number
            };
            $state.transitionTo('cricCard.playMatch', params, {
                location: true,
                inherit: true,
                relative: $state.$current,
                notify: false
            });
        } else {
            $scope.paused = true;
        }
        
    };

    $scope.onFailure = function (result) {
        $scope.paused = false;
        $scope.hasErrors = true;
        $scope.message = 'Fail to create match. Please contact your administrator.'
    };

    $scope.play = function () {
        var team = $scope.model.game.FirstTeam;
        if (!$scope.model.game.FirstTeam.IsBowlFirst) {
            team = $scope.model.game.SecondTeam;
        }

        GameService.play(team, $scope.onSuccess, $scope.onFailure);
    };
}]);
