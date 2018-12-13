
$(document).ready(function () {

    var url = "../../Organizations/AutoCodeGenerated";
<<<<<<< HEAD
    $.post(url, function(rData) {
=======
    $.post(url, function (rData) {
>>>>>>> f74fb189c322710c507fcaa19f4925f7887326ff
        if (rData != undefined && rData != null && rData != "") {
            $("#OrganizationCode").val(rData);
        }
    });
<<<<<<< HEAD
});
=======
});

alert("heiiii");
>>>>>>> f74fb189c322710c507fcaa19f4925f7887326ff
