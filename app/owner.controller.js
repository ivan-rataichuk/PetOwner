(function () {
    'use strict';

    angular
        .module('app')
        .controller('Owner', owner);

    function owner($scope, $routeParams, OwnerService) {
        $scope.newPet;
        $scope.owner;
        $scope.petsTotal;

        var id = $routeParams.id;

        $scope.update = function (data) {
            $scope.owners = data;
        };

        $scope.owners = [];
        $scope.items = [];
        $scope.emptyItems = [];
        $scope.itemsPerPage = 3;
        $scope.currentPage = 1;
        $scope.pageNumbers = [1];

        this.update = function (data) {
            $scope.owners = data;
        };

        $scope.selectOwner = function () {
            $scope.owners.forEach(function (item, i, arr) {
                if (item.Id == id) $scope.owner = item;
            });
            $scope.petsTotal = $scope.owner.Pets.length;
        }

        $scope.selectPage = function (pageNum) {
            $scope.currentPage = pageNum;
            $scope.updatePage();
        }

        $scope.updatePage = function () {

            var start = ($scope.currentPage - 1) * $scope.itemsPerPage;
            $scope.items = $scope.owner.Pets.slice(start, start + $scope.itemsPerPage);

            var emptyLength = $scope.itemsPerPage - $scope.items.length;
            $scope.emptyItems = new Array(emptyLength);

            $scope.pageNumbers = [1];
            for (var i = 1; i < ($scope.owner.Pets.length / $scope.itemsPerPage) ; i++) {
                $scope.pageNumbers[i] = i + 1;
            }
        }

        $scope.$watch('owners', function () {
            $scope.selectOwner();
            $scope.updatePage();
        });

        $scope.addPet = function () {
            if (($scope.owner.Id !== undefined) && ($scope.NewPet !== undefined)) {
                OwnerService.addPet($scope.owner.Id, $scope.NewPet);
            }
        }

        $scope.deletePet = function (id) {
            if (id !== undefined) OwnerService.deletePet(id);
        }

        OwnerService.registerOwnerController(this);
        $scope.$on('$destroy', function () {
            OwnerService.unregisterOwnerController();
        });

        OwnerService.updateControllers();
        $scope.selectOwner();
    }

})();