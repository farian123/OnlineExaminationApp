//Get course By Organization cascading//////////////
$(document.body).on("change", "#OrganizationId", function () {
    var organizationId = $(this).val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../Exams/GetCourseByOrganizationId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function (response) {
            if (response != undefined && response != null && response != "") {
                $("#CourseId").empty();
                $("#CourseId").append('<option>--Select--</option>');
                $.each(response, function (k, v) {
                    $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    }), fail(function (rdata) {
        alert(rdata);
    });
});