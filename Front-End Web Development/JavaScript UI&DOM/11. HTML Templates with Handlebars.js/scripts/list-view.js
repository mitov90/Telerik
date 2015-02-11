$.fn.listview = function (data) {
    $this = $(this);
    var templateId = $this.attr('data-template');
    var template = $('#' + templateId);
    var templateOptions = selectTemplate(template);
    var result = getHtmlResult(templateOptions, data);
    $this.html(result);
}

function selectTemplate(templateId) {
    var templateOptions = Handlebars.compile(($(templateId)).html());
    return templateOptions;
}

function getHtmlResult(templateOptions, data) {
    var result = "";
    for (var i = 0, length = data.length; i < length; i += 1) {
        result += templateOptions(data[i]);
    }
    return result;
}

