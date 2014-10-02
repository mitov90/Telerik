function IsPrime(n) {
    if (n < 1) return false;
    if (n == 2) return true;
    if (n == 3) return true;
    if (n % 2 == 0) return false;
    if (n % 3 == 0) return false;

    var i = 5;
    var w = 2;
    while (i * i <= n) {
        if (n % i == 0)
            return false;
        i += w;
        w = 6 - w;
    }
    return true;
}

console.log(IsPrime(7919));