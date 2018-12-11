
function isValidLetterSpace(key) {  
    return (isLetter(key) || escapeBasicsSpace(key)) ? true : false;
}

function isNumberOrLetter(key) {
    return (isLetter(key) || isNumber(key) || escapeBasics(key)) ? true : false;
}

function isLetterWithoutSpace(key) {
    return (isLetter(key) || escapeBasics(key)) ? true : false;

}


//Solo Capturan Números
function isNumber(key) {
    var key = selectKey(key);
    return ((key >= 48 && key <= 57) || escapeBasics(key)) ? true : false;
}

function isInRange(key, min, sup) {
    var key = selectKey(key);
    return (key >= min && key <= sup) ? true : false;

}


function isLetter(key) {
    var key = selectKey(key);

    console.log("Dentro de is letter");
    console.log(key);
    return ((key >= 97 && key <= 122)//letras mayusculas
        || (key >= 65 && key <= 90) //letras minusculas
        // && (key.charCode != 45) //-
        || (key == 241) //ñ
        || (key == 209) //Ñ
        || (key == 225) //á
        || (key == 233) //é
        || (key == 237) //í
        || (key == 243) //ó
        || (key == 250) //ú
        || (key == 193) //Á
        || (key == 201) //É
        || (key == 205) //Í
        || (key == 211) //Ó
        || (key == 218) //Ú
    ) ? true : false;

}

function selectKey(e) {
    var charCode = (e.which) ? e.which : e.keyCode;
    return charCode;
}

function escapeBasics(e) {
    var e = selectKey(e);
    return (
        escapeF5(e)
        || escapeBackspace(e)
        || escapeTab(e)
        || escapeRightArrow(e)
        || escapeLeftArrow(e)
    ) ? true : false;
}

function escapeBasicsSpace(e) {
    var e = selectKey(e);

    return (
        escapeF5(e)
        || escapeBackspace(e)
        || escapeTab(e)
        || escapeRightArrow(e)
        || escapeLeftArrow(e)
        || escapeSpace(e)
    ) ? true : false;
}

function escapeF5(e) {
    return (e == 116) ? true : false;
}


function escapeBackspace(e) {
    return (e == 8) ? true : false;
}

function escapeTab(e) {
    return (e == 9) ? true : false;
}

function escapeLeftArrow(e) {
    return (e == 37) ? true : false;
}

function escapeRightArrow(e) {
    return (e == 39) ? true : false;
}

function escapeSpace(e) {
    return (e == 32) ? true : false;
}
