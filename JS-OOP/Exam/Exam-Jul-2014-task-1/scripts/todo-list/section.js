define(["todo-list/item"],function(item) {
  'use strict';
  var Section;
  Section = (function() {
    function Section(title) {
	    this.title=title;
        this._items=[];
    }
      Section.prototype.add = function (obj) {
        if (!(obj instanceof item)){
            throw {
                message: "Not a valid item!"
            }
        }
          this._items.push(obj);
      };

      Section.prototype.getData = function () {
          var result = this._items.slice().map(function (item) {
              return item.getData();
          });
        return {
            title: this.title,
            items: result
        }
      };
	
	return Section;
  }());
  return Section;
});