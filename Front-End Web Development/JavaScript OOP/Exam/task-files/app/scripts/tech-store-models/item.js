define(function () {
    'use strict';
    var Item;
    Item = (function () {

        //Constants
        var MAX_ITEM_NAME_LENGTH = 40;
        var MIN_ITEM_NAME_LENGTH = 6;

        //Hidden helper func
        function validateName(name) {
            if (name.length >= MIN_ITEM_NAME_LENGTH &&
                name.length <= MAX_ITEM_NAME_LENGTH) {
                return true;
            }
            else
                return false;

        }

        function validateItemType(type) {
            switch (type) {
                case "accessory":
                case "smart-phone":
                case "notebook":
                case "pc":
                case "tablet":
                    return true;
                default :
                    return false;
            }
        }

        //Constructor
        function Item(type, name, price) {
            if (!validateName(name)) {
                throw {
                    message: "Invalid name length!"
                }
            }
            if (!validateItemType(type)) {
                throw {
                    message: "Invalid item type!"
                }
            }

            this.type = type;
            this.name = name;
            this.price = price;
        }

        Item.prototype.clone = function (){
            var copy= new Item (this.type,this.name,this.price);
            return copy;
        };

        return Item;
    })();
    return Item;
});