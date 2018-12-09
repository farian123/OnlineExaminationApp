
$(document).ready(function () {

    var url = "../../Organizations/AutoCodeGenerated";
    $.post(url, function (rData) {
        if (rData != undefined && rData != null && rData != "") {
            $("#OrganizationCode").val(rData);
        }
    });
});

alert("heiiii");
