// replaces in string index position with replacment
// e.g  "baby".replaceAt(0, "nn") = "nnaby"
// e.g  "code".replaceAt(1, "ssss") = "cssssde"

String.prototype.replaceAt = function (index, replacement) {
    return this.substr(0, index) + replacement + this.substr(index + 1);
};