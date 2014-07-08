window.onload = function () {
    Handlebars.registerHelper('list', function (items, options) {
        var html = "";

        for (var index in items) {
            var item = items[index];
            html += options.fn({
                index: index,
                title: item.title,
                firstDate: item.firstDate.toDateString(),
                secondDate: item.secondDate.toDateString()
            });
        }

        return html;
    });

    var data = [
        {
            title: 'Course Introduction',
            firstDate: new Date(),
            secondDate: new Date()
        },
        {
            title: 'Document Object Model',
            firstDate: new Date(),
            secondDate: new Date()
        },
        {
            title: 'HTML5 Canvas',
            firstDate: new Date(),
            secondDate: new Date()
        },
        {
            title: 'Kinetic.js Overview',
            firstDate: new Date(),
            secondDate: new Date()
        },
        {
            title: 'SVG and Raphael.js',
            firstDate: new Date(),
            secondDate: new Date()
        },
        {
            title: 'DOM Operations',
            firstDate: new Date(),
            secondDate: new Date()
        }
    ];

    var postTemplate = Handlebars.compile(document.getElementById('table-template').innerHTML);
    document.getElementById('content').innerHTML = postTemplate({data:data});

}