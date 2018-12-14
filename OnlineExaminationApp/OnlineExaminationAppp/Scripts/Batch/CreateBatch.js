$("#OrganizationId").change(function() {
    var organizationId = $(this).val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../Batches/GetCourseByOrganizationId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function(response) {
            if (response != undefined && response != null && response != "") {
                $("#CourseId").empty();
                $("#CourseId").append('<option>--Select--</option>');

                $.each(response, function(k, v) {
                    $("#CourseId").append("<option value='"+v.Id+"'>"+v.Name+"</option>");
                });
            }
        }
    });
});

