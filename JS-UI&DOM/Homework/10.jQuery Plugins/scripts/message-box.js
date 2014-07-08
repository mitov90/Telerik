(function ($) {
    $.fn.messageBox = function (message, type) {
        $this = $(this);

        var $msgBox = $('<div class="message"/>')
            .addClass(type)
            .text(message);

        $msgBox.fadeIn(3000, "linear");
        $this.append($msgBox);

        setTimeout(function () {
            $msgBox.fadeOut(3000, "linear");
            setTimeout(function () {
                $msgBox.remove();
            }, 3000);
        }, 3000);
    }

})(jQuery);

window.onload = function() {
    var errorMsg = $('#message-box').messageBox("You can't do this now!", 'error');
    var successMsg = $('#message-box').messageBox('You changed your password!', 'success');
};