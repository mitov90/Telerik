function nestedDivsSelector() {

    //using css selector
    var nestedDivs = document.querySelectorAll('div>div');
    return nestedDivs;
}

function nestedDivsByTag() {
    var allDivs = document.getElementsByTagName('div');
    var nestedDivs = [];

    for (var i = 0, length = allDivs.length; i < length; i++) {
        if (allDivs[i].parentNode instanceof   HTMLDivElement) {
            nestedDivs.push(allDivs[i]);
        }
    }

    return nestedDivs;

}

function allDivsCount() {
    return document.getElementsByTagName('div').length;
}

window.onload = function() {
    //var nestedDivs = nestedDivsSelector();
    var nestedDivs = nestedDivsByTag();

    for (var i = 0, length = nestedDivs.length; i < length; i++) {
        console.log('nestedDivs[' + i + '] = ' + nestedDivs[i]);
    }

    console.log("all divs count:" + allDivsCount());
    console.log("innerDivs count: " + nestedDivs.length);
};