(function() {
    'use strict';

    angular
        .module('cricCard')
        .directive('cricHeader', header);

    header.$inject = ['$window'];
    
    function header ($window) {
        // Usage:
        //     <header></header>
        // Creates:
        // 
        var directive = {
            link: link,
            templateUrl: 'views/header.html',
            restrict: 'EA'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();