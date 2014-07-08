define(["todo-list/section"], function (section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (obj) {
            if (!(obj instanceof section)) {
                throw {
                    message: "Not valid section!"
                }
            }
            this._sections.push(obj);
        };

        Container.prototype.getData = function () {
            return this._sections.slice().map(function (section) {
                return section.getData();
            })


        };

        return Container;
    }());
    return Container;
});