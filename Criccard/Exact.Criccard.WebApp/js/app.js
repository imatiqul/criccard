'use strict';

var cricCard = angular.module('cricCard', [
    'ui.router',
    /*'cricCard.factories',*/
    'cricCard.services',
    'cricCard.controllers',
    'angular-loading-bar',
    'ngAnimate'
]).config(function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
});

cricCard.run(
    ['$rootScope', '$state', '$stateParams',
        function ($rootScope, $state, $stateParams) {
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;

            $rootScope.model = {
                gameID: ''
            };
        }
    ]
);