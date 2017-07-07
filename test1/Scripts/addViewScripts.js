function validateForm() {
    var x = document.forms["contactForm"]["lastName"].value;
    if (x == "") {
        alert("Uzmirsai");
        return false;
    }
}