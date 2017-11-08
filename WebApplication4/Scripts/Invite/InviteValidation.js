$(document).ready(() => {
    this.NumberValidator();
  

});


function OnChange(){
    $('#Phone').change(() => {
        $('#Phone').validate();
    });
}



function NumberValidator()  {
    jQuery.validator.addMethod('isNumber',
        () => {
            return this.isNumeric();
        },
        'Numer telefonu jest niepoprawny');
}