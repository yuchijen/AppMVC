
//function IsFirstNameEmpty() {

//    if ($('#TxtFName').val() == "") {
//        return 'First Name should not be empty';
//    }
//    else { return ""; }
//}
//function IsFirstNameInValid() {    
//    if ($('#TxtFName').val().indexOf("@") != -1) {
//        return 'First Name should not contain @';
//    }
//    else { return ""; }
//}
//function IsLastNameInValid() {
//    if ($('#TxtLName').val().length >= 5) {
//        return 'Last Name should not contain more than 5 character';
//    }
//    else { return ""; }
//}
//function IsSalaryEmpty() {
//    if (document.getElementById('TxtSalary').value=="") {
//        return 'Salary should not be empty';
//    }
//    else { return ""; }
//}
//function IsSalaryInValid() {
//    if (isNaN(document.getElementById('TxtSalary').value)) {
//        return 'Enter valid salary';
//    }
//    else { return ""; }
//}
function IsValid() {

    //var FirstNameEmptyMessage = IsFirstNameEmpty();
    //var FirstNameInValidMessage = IsFirstNameInValid();
    //var LastNameInValidMessage = IsLastNameInValid();
    //var SalaryEmptyMessage = IsSalaryEmpty();
    //var SalaryInvalidMessage = IsSalaryInValid();

    var errMsg = "";

    if ($('#TxtFName').val() == "") {
        errMsg += "First Name should not be empty. \n";
    }
    
    if ($('#TxtFName').val().indexOf("@") != -1) {
        errMsg += "First Name should not contain @ \n";
    }
    

    if ($('#TxtLName').val().length >= 5) {
        errMsg += "Last Name should not contain more than 5 character \n";
    }
    
    if ($('#TxtSalary').val() == "" || IsNaN($('#TxtSalary').val())) {
        errMsg += "Salary should not be empty \n";
    }
    
  
    //var FinalErrorMessage = "Errors:";
    //if (FirstNameEmptyMessage != "")
    //    FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    //if (FirstNameInValidMessage != "")
    //    FinalErrorMessage += "\n" + FirstNameInValidMessage;
    //if (LastNameInValidMessage != "")
    //    FinalErrorMessage += "\n" + LastNameInValidMessage;
    //if (SalaryEmptyMessage != "")
    //    FinalErrorMessage += "\n" + SalaryEmptyMessage;
    //if (SalaryInvalidMessage != "")
    //    FinalErrorMessage += "\n" + SalaryInvalidMessage;

    if (errMsg != "") {
        alert(errMsg);
        return false;
    }
    else {
        return true;
    }
}