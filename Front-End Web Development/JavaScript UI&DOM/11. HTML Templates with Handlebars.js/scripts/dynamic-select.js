window.onload = function() {
    var items = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    },{
        value:4,
        text: 'Four'
    }];

    var selectHTML = selectTemplate('dynamic-select');
    var selectMenu = document.getElementById('wrapper');
    selectMenu.innerHTML=selectHTML({items:items});

    function selectTemplate(template) {
        var templateOptions =  Handlebars.compile(document.getElementById(template).innerHTML);
        return templateOptions;
    }


}