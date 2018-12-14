$("#CountryId").change(function () {
    var organizationId = $("#OrganizationId").val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../Batches/GetCourseByOrganizationId",
        type: "POST",
        ContentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function (response) {
            if (response != undefined && response != null && response != "") {
                $.each(response, function (k, v) {
                    $("#CourseId").append("<option value='" + v.Id + "'>'" + v.Name + "'</option>");
                });
            }
        }
    });
});