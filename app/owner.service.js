(function () {
    'use strict';

    angular
        .module('app')
        .service('OwnerService', ownerService);

    var Owner = function (id, name, pets) {
    	this.Id = id;
    	this.Name = name;
    	this.Pets = pets;
    	this.PetsCount = pets.length;
    }

    var Pet = function (id, name) {
        this.Id = id;
        this.Name = name;
    }

    

    function ownerService($http) {
        var owners = [];

        var mainController = null;
        var ownerController = null;

        this.registerMainController = function (controller) {
            mainController = controller;
        }

        this.unregisterMainController = function () {
            mainController = null;
        }

        this.registerOwnerController = function (controller) {
            ownerController = controller;
        }

        this.unregisterOwnerController = function () {
            ownerController = null;
        }

        this.updateControllers = function () {
            if (mainController !== null) mainController.update(owners);
            if (ownerController !== null) ownerController.update(owners);
        }

        var updateCtrlrs = this.updateControllers;

    	this.getOwners = function () {
    	    $http.get("api/Owner").then(function (response) {

    	        var data = (angular.fromJson(response.data));

    	        owners = [];

    	        data.forEach(function (item, i, arr) {
    	            var p = [];
    	            item.Pets.forEach(function (item, i, arr) {
    	                p.push(new Pet(item.Id, item.Name));
    	            });

    	            var o = new Owner(item.Id, item.Name, p);
    	            owners.push(o);
    	        });

    	        updateCtrlrs();
    	    });
    	}

    	this.updateControllers = function () {
    	    if (mainController !== null) mainController.update(owners);
    	    if (ownerController !== null) ownerController.update(owners);
        }

    	var updateOwners = this.getOwners;

    	this.addOwner = function(name){
    	    $http.post("api/Owner", JSON.stringify(name)).then(function (response) {
    	        console.log("posted owner");
    	        updateOwners();
    		});
    	}

    	this.deleteOwner = function (id) {
    	    $http.delete("api/Owner/" + id).then(function (response) {
    	        console.log("deleted owner");
    	        updateOwners();
    	    });
    	}

    	this.addPet = function (ownerId, name) {
    	    $http.post("api/Pet", JSON.stringify({ OwnerId : ownerId, Name : name })).then(function (response) {
    	        console.log("posted pet");
    	        updateOwners();
    	    });
    	}

    	this.deletePet = function (id) {
    	    $http.delete("api/Pet/" + id).then(function (response) {
    	        console.log("deleted pet");
    	        updateOwners();
    	    });
    	}
    }

})();