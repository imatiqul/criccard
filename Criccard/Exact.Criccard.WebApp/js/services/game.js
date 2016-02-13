'use strict';

var cricCardServices = angular.module('cricCard.services', []);

cricCardServices.service('GameService', function ($q, $http) {
    return {
        createMatch: function (data) {
            var host = '//localhost:87';

            var url = host + '/api/Game/createMatch';
            var promise = function (url) {

                var deffered = $q.defer();

                $http({
                    url: url,
                    method: 'POST',
                    data: data
                }).
                success(function (result) {
                    deffered.resolve(data);
                }).
                error(function (error) {
                    deffered.reject();
                });

                return deffered.promise;

            };

            return $q.all(promise);
        }
    }

});