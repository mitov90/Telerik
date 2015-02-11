$.fn.tabs = function () {
    $this = $(this);
    $this.addClass('tabs-container');

    var $tabTitles = $this.find('.tab-item-title');
    $this.find('.tab-item-content').hide();
    var $selected = $tabTitles.first().parent().addClass('current');
        $selected.find('.tab-item-content').show();

    $tabTitles.on('click', function(ev){
        var $this = $(this);
        $selected.removeClass('current');
        $selected.find('.tab-item-content').hide();
        $selected = $this.parent().addClass('current');
        $selected.find('.tab-item-content').show();
    });

};