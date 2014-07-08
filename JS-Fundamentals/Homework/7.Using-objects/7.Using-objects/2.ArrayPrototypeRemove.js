function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.toString = function () {
        console.log(firstName + " " + this.lastName + " " + this.age);
    };
}

function group(people, prop) {
    var groups = {};

    for (var i = 0; i < people.length; i++) {

        var p = people[i][prop];

        if (!groups[p]) {
            groups[p] = [];
        }
        groups[p].push(people[i]);

    }
    return groups;
}

var people = [];

people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Hanselman", 39));
people.push(new Person("Jesse", "Liberty", 57));
people.push(new Person("Jon", "Skeet", 36));
people.push(new Person("Anders", "Hejlsberg", 52));
people.push(new Person("Bjarne", "Stroustrup", 62));
people.push(new Person("Erik", "Meijer", 49));
people.push(new Person("Adam", "Nathan", 42));
people.push(new Person("Jeffrey", "Richter", 52));
people.push(new Person("Charles", "Petzold", 60));
people.push(new Person("Jon", "Galloway", 42));
people.push(new Person("Adam", "Freeman", 42));
people.push(new Person("Scott", "Mitchell", 34));

var groups = group(people, "firstName");
console.log(groups);