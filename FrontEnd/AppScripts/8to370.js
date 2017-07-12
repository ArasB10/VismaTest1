
// if the number starts with 8 returns same number starting with +370  

function globalNumber(number) {
    if (number.charAt(0) === "8") {
        number = number.replaceAt(0, "+370");
    }
    return number;
}