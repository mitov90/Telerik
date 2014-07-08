function createCalendar(selector, events) {
    var container = document.querySelector(selector),
        monthFragment = document.createDocumentFragment(),
        DAYS = 30,
        daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
        day = document.createElement('div'),
        dayTitle = document.createElement('span'),
        dayContent = document.createElement('div'),
        selected = null;

    day.appendChild(dayTitle);
    day.appendChild(dayContent);

    applyStyles();
    createMonth('June', DAYS, '2014', events);
    applyEvents();
    container.appendChild(monthFragment);

    function createMonth(month, days, year, events) {
        for (var i = 1; i <= days; i += 1) {
            dayTitle.innerHTML = daysOfWeek[(i - 1) % daysOfWeek.length] + ' ' + i + ' ' + month + ' ' + year;
            dayContent.innerHTML = getDayEvents(i, events);
            monthFragment.appendChild(day.cloneNode(true));
        }

        function getDayEvents(day, events) {
            for (var i = events.length - 1; i >= 0; i--) {
                var event = events[i];
                if (event.date === day.toString()) {
                    return event.hour + ' ' + event.title;
                }
            }
            return '&nbsp';
        }
    }

    function applyStyles() {
        container.style.width = "860px";

        day.style.display = "inline-block";
        day.style.width = "120px";
        day.style.height = "120px";
        day.style.border = "1px solid black";
        day.className += 'day-box';

        dayTitle.style.display = "block";
        dayTitle.style.borderBottom = "1px solid black";
        dayTitle.style.backgroundColor = "gray";
        dayTitle.style.textAlign = "center";
        dayTitle.className = 'day-title';

        dayContent.className = 'day-content';
    }

    function applyEvents() {
        var boxes = monthFragment.querySelectorAll('.day-box');
        for (var i = boxes.length - 1; i >= 0; i--) {
            var box = boxes[i];
            box.addEventListener('click', function (ev) {
                if (selected) {
                    selected.style.background = "";
                    selected.classList.remove('selected');
                    selected.querySelector('.day-title').style.background='gray';
                }
                this.querySelector('.day-title').style.background = 'yellowgreen';
                this.className += " selected";
                this.style.background = "orange";
                selected = this;
            })
            box.addEventListener('mouseover', function(ev){
               if (this !== selected){
                   this.querySelector('.day-title').style.background = "pink";
               }
            });
            box.addEventListener('mouseout', function(ev){
                if (this!==selected){
                    this.querySelector('.day-title').style.background = 'gray';
                }
            })
        }
    }
}


