/**
 * Created by admin on 6/16/14.
 */
$.fn.dropdown = function (){
    $this = $(this);
    $this.hide();
    $listId = $this;
    var $parent = $this.parent();

    var $ddListContainer = $('<div class="dropdown-list-container" />');
    $parent.append($ddListContainer);

    var $ddListOptions = $ ('<ul class="dropdown-list-options" />');
    $ddListContainer.append($ddListOptions);

    var $option = $('<li class="dropdown-list-option" />');

    var $options = $this.children();
    for (var i = 0, length = $options.length; i < length ; i+=1){
        if (i===0){
            $option.attr('selected','selected');
        }
        var $curSelect = $($options[i]);
        $option.text($curSelect.text())
            .attr("data-value",i+1);
        $ddListOptions.append($option.clone());
    }

    $ddListOptions.on('click', '.dropdown-list-option', ddOptionOnClick);

    $this.after($ddListContainer);
    $ddListContainer.hide();

    $('button').on('click', function() {
        $ddListContainer.slideToggle();
    });

    return $this;

    function ddOptionOnClick(event){
        var selectedValue = $(this).attr('data-value');
        var pattern = 'option[value=\'' + selectedValue + '\']';

        var optionForSelection = $listId.find(pattern);
        if (optionForSelection.attr('selected')) {
            optionForSelection.removeAttr('selected', 'selected');

            $(this).css('background-color', '');
            $('#selected-item').text('Last clicked: ' + optionForSelection.html());
        } else {
            optionForSelection.attr('selected', 'selected');

            $(this).css('background-color', 'orange');
            $('#selected-item').text('Last clicked: ' + optionForSelection.html());
        }

    }
}