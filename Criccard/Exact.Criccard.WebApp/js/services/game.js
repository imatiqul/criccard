'use strict';

var cricCardServices = angular.module('cricCard.services', []);

cricCardServices.service('GameService', function ($q, $http) {
    return {
        createMatch: function (game, onsuccess, onfailure) {
            var host = '//localhost:8787';

            var url = host + '/api/game/creatematch';
            var data = JSON.stringify(game);
            $http.get(
                url,
               {
                   params: {
                       game: data
                   }
               }
                ).
            success(function (result, status, headers, config) {
                onsuccess(result);
            }).
            error(function (result, status, headers, config) {
                onfailure(result);
            });


        }
    }

});