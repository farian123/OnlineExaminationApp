$(document.body).on("change", "#OrganizationId", function () {
    var organizationId = $(this).val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../ExamAttend/GetCourseByOrganizationId",
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

//Get Exam by course cascading//////////////
$(document.body).on("change", "#CourseId", function () {
    var courseId = $(this).val();

    var param = { courseId: courseId };
    takeParticipantByCourseId(param);
    takeExamByCourseId(param);
    

});

function takeExamByCourseId(param) {
    $.ajax({
        url: "../../ExamAttend/GetExamByCourseId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function(response) {
            if (response != undefined && response != null && response != "") {
                $("#ExamId").empty();
                $("#ExamId").append('<option>--Select--</option>');
                $.each(response, function(k, v) {
                    $("#ExamId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    });
}
function takeParticipantByCourseId(param) {
    $.ajax({
        url: "../../ExamAttend/GetAllParticipantByCourseId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function(response) {
            if (response != undefined && response != null && response != "") {
                $("#ParticipantId").empty();
                $("#ParticipantId").append('<option>--Select--</option>');
                $.each(response, function(k, v) {
                    $("#ParticipantId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    });
}