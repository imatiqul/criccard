cricCard.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('cricCard', {
            abstract: true,
            templateUrl: 'views/game/game.html'
        });
    $stateProvider
        .state('cricCard.createMatch', {
            url: "/",
            views: {
                'cricCardWindow@': {
                    templateUrl: '/views/game/create-match.html',
                    controller: 'GameCtrl'
                }
            }
        });
    $stateProvider
        .state('cricCard.playMatch', {
            url: "/:gameID/:overNumber/:bowlNumber",
            views: {
                'cricCardWindow@': {
                    templateUrl: '/views/game/play-match.html',
                    controller: 'MatchCtrl'
                }
            }
        });
}]);
