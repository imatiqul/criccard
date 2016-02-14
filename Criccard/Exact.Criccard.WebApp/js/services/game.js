'use strict';

var cricCardServices = angular.module('cricCard.services', []);

cricCardServices.service('GameService', ['$q', '$http', '$httpParamSerializerJQLike', 'CricSettings', function ($q, $http, $httpParamSerializerJQLike, CricSettings) {
    return {
        apiUrl: "//" + CricSettings.Host + ':' + CricSettings.PORT,
        createMatch: function (data, onSuccess, onFailure) {
            var url = this.apiUrl + '/api/game/matchstart';

            $http.post(url, $httpParamSerializerJQLike(data), {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded', }
            }).success(function (result, status, headers, config) {
                onSuccess(result);
            }).error(function (result, status, headers, config) {
                onFailure(result);
            });
        },
        play: function (data, onSuccess, onFailure) {
            var url = this.apiUrl + '/api/game/play';

            $http.post(url, $httpParamSerializerJQLike(data), {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded', }
            }).success(function (result, status, headers, config) {
                onSuccess(result);
            }).error(function (result, status, headers, config) {
                onFailure(result);
            });
        },
    }
}]);