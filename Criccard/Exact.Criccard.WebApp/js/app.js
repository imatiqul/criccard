'use strict';

var cricCard = angular.module('cricCard', [
    'ui.router',
    'cricCard.settings',
    'cricCard.services',
    'cricCard.controllers',
    'angular-loading-bar',
    'ngAnimate'
]).config(function (cfpLoadingBarProvider, $httpProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
});

cricCard.run(
    ['$rootScope', '$state', '$stateParams',
        function ($rootScope, $state, $stateParams) {
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;

            $rootScope.model = {
                game: {},
                overNumber: 0,
                bowlNumber: 0
            };
        }
    ]
);