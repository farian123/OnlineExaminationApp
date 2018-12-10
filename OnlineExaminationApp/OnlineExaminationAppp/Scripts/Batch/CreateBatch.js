$("#OrganizationId").change(function() {
    var organizationId = $("#OrganizationId").val();

    var param = { organizationId: organizationId }
    $.ajax({
        url: "../../Batches/GetCourseByOrganizationId",
        type: "POST",
        ContentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function(response) {
            if (response != undefined && response != null && response != "") {
                $.each(response, function(k, v) {
                    $("#CourseId").append("<option value='"+v.Id+"'>'"+v.Name+"'</option>");
                });
            }
        }
    });
});

//$(document).ready(function() {
//    $("#StartDate").datepicker({
//        dateFormat: "dd/MM/yyyy",
//        changeMonth: true,
//        changeYear: true,
//        yearRange: "-60:+0"
//    });
//});
//$("#StartDate").click(function() {
//    $('#StartDate').datetimepicher({
//        formate: "DD/MM/YYYY"
//    }).on('dp.change', function(e) {
//        $(this).data('DateTimePicker').hide();
//    });
//});
//$(function () {
//    $('#StartDate').datetimepicher({
//        formate: "DD/MM/YYYY"
//    }).on('dp.change', function (e) {
//        $(this).data('DateTimePicker').hide();

//    });
//});