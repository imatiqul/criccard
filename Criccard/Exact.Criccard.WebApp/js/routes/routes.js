cricCard.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/criccard/start');

    $stateProvider
        .state('cricCard', {
            abstract: true,
            templateUrl: 'views/game/game.html'
        });
    $stateProvider
        .state('cricCard.createMatch', {
            url: "/criccard/start",
            views: {
                'cricCardWindow@': {
                    templateUrl: '/views/game/create-match.html',
                    controller: 'GameCtrl'
                }
            }
        });
    $stateProvider
        .state('cricCard.playMatch', {
            url: "/criccard/:gameID/:overNumber/:bowlNumber",
            views: {
                'cricCardWindow@': {
                    templateUrl: '/views/game/play-match.html',
                    controller: 'MatchCtrl'
                }
            }
        });
}]);
