(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', main);

    function main($scope, OwnerService) {
        $scope.owners = [];

        $scope.items = [];
        $scope.emptyItems = [];
        $scope.itemsPerPage = 3;
        $scope.currentPage = 1;
        $scope.pageNumbers = [1];

        $scope.dataLoading = true;

        this.update = function (data) {
            $scope.owners = data;
            $scope.dataLoading = false;
        };

        $scope.selectPage = function (pageNum) {
            $scope.currentPage = pageNum;
            $scope.updatePage();
        }

        $scope.updatePage = function () {

            var start = ($scope.currentPage - 1) * $scope.itemsPerPage;
            $scope.items = $scope.owners.slice(start, start + $scope.itemsPerPage);

            var emptyLength = $scope.itemsPerPage - $scope.items.length;
            $scope.emptyItems = new Array(emptyLength);

            $scope.pageNumbers = [1];
            for (var i = 1; i < ($scope.owners.length / $scope.itemsPerPage) ; i++) {
                $scope.pageNumbers[i] = i+1;
            }
        }

        $scope.$watch('owners', function () {
            $scope.ownersTotal = $scope.owners.length;
            $scope.updatePage();
        });

        $scope.NewOwnerName;
        $scope.addNewOwner = function () {
            OwnerService.addOwner($scope.NewOwnerName);
            $scope.NewOwnerName = '';
        }

        $scope.deleteOwner = function (id) {
            if (id !== undefined) OwnerService.deleteOwner(id); 
        }

        OwnerService.registerMainController(this);
        $scope.$on('$destroy', function () {
            OwnerService.unregisterMainController();
        });
        OwnerService.getOwners();
    }

})();