
$(document).ready(function () {

    var url = "../../Organizations/AutoCodeGenerated";
    $.post(URL, function(rData) {
        if (rData != undefined && rData != null && rData != "") {
            $("#OrganizationCode").val(rData);
        }
    });
});