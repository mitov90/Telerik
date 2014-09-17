define(["tech-store-models/item"], function (Item) {
    'use strict';
    var Store;
    Store = (function () {

        //Constants
        var MAX_ITEM_NAME_LENGTH = 30;
        var MIN_ITEM_NAME_LENGTH = 6;

        //Hidden helper functions
        function validateName(name) {
            if (name.length >= MIN_ITEM_NAME_LENGTH &&
                name.length <= MAX_ITEM_NAME_LENGTH) {
                return true;
            }
            else
                return false;

        }

        function sortAlphabetically(item1, item2) {
            if (item1.name < item2.name)
                return -1;
            if (item1.name > item2.name)
                return 1;
            return 0;
        }

        function isTypeOfItem(item, type) {
            if (item.type === type) {
                return true;
            }
            return false;

        }

        //Constructor
        function Store(name) {
            if (!validateName(name)) {
                throw {
                    message: "Invalid store's name length!"
                }
            }
            this.name = name;
            this._items = [];
        }

        //Public functions
        Store.prototype.addItem = function (item) {
            if (!(item instanceof Item)) {
                throw {
                    message: "Store can add objects instanceof Item!"
                }
            }
            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            return this._items.slice().sort(sortAlphabetically)
        };

        Store.prototype.getSmartPhones = function () {
            return this._items.slice().filter(function (item) {
                return isTypeOfItem(item, 'smart-phone');
            }).sort(sortAlphabetically)
        };

        Store.prototype.getMobiles = function () {
            return this._items.slice().filter(function (item) {
                return isTypeOfItem(item, 'smart-phone') || isTypeOfItem(item, 'tablet');
            }).sort(sortAlphabetically)
        };

        Store.prototype.getComputers = function () {
            return this._items.slice().filter(function (item) {
                return isTypeOfItem(item, 'pc') || isTypeOfItem(item, 'notebook');
            }).sort(sortAlphabetically)
        };

        Store.prototype.filterItemsByType = function (itemType) {
            return this._items.slice().filter(function (item) {
                return isTypeOfItem(item, itemType);
            }).sort(sortAlphabetically);
        };

        Store.prototype.filterItemsByPrice = function () {
            var args = arguments[0] || {};
            var min = args.min || 0;
            var max = args.max || +Infinity;

            return this._items.slice().filter(function (item) {
                if (item.price >= min && item.price <= max) return 1;
                else return 0;
            }).sort(function (item1, item2) {
                return item1.price - item2.price;
            })

        };

        Store.prototype.filterItemsByName = function (partOfName) {
            return this._items.slice().filter(function (item) {
                if (item.name.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1)
                    return true;
                else return false;
            }).sort(sortAlphabetically)
        };

        Store.prototype.countItemsByType = function () {
            var result = {};

            for (var i = 0, length = this._items.length; i < length; i += 1) {
                var curItem = this._items[i];
                if (result[curItem.type] === undefined) {
                    result[curItem.type] = [];
                }
                result[curItem.type].push(curItem.clone());
            }

            return result;
        };

        return Store;
    })();
    return Store;
});