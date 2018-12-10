$(document).ready(function () {
    var id = $("#CourseDetailsButton").val();
    var urlSet = "../../Courses/AssignTrainerPv";
    assaignTrainerPv(id,urlSet);
});


$(document.body).on("click", "#AssignTrainerButton", function () {
    var id = $("#AssignTrainerButton").val();
    var urlSet="../../Courses/AssignTrainerPv";
    assaignTrainerPv(id,urlSet);
});
$(document.body).on("click", "#AssignTrainerButton", function () {
    var id = $("#ExamCreateButton").val();
    var urlSet = "../../Courses/AssignTrainerPv";
    assaignTrainerPv(id, urlSet);
});


function assaignTrainerPv(id,urlSet) {
    var url = urlSet;
        $.post(url, function (rData) {
            if (rData != undefined && rData != "") {
                $("#PartialLoadDiv").html(rData);
            }
        });
}



//function assaignTrainerPv(id) {
//    //var param = id;
//    //var value = $("#editCourse").val();
//   // var url = "../../Courses/GetCourseUpdatePV";
//    $.ajax({
//        //url: "Courses/AssignTrainerPv",
//        url: "@Url.Action("+"AssignTrainerPv"+","+"Courses"+")",
//        data:{id:id},
//        type: "POST",
//        ContentType: "html",
//        success: function(res) {
//            $("#PartialLoadDiv").html(res);
//        },
//        error:function(res) {
//            alert("Error");
//        }

//    });
//}
//function getCourseUpdatePV(courseId) {
//    var param = courseId;
//    var url = "../../Courses/GetCourseUpdatePV";
//    //$.post(url, function (rData) {
//    //    if (rData != undefined && rData != null && rData != "") {
//    //        $("#PartialLoadDiv").html(rData);
//    //    }
//    //});
//}

//function getCourseUpdatePV(id) {
//    var param = id;
//    var value = $("#editCourse").val();
//   // var url = "../../Courses/GetCourseUpdatePV";
//    $.ajax({
//        url: '<%: Url.Action("../../Courses/GetCourseUpdatePV")%>?id=' + param,
//        type: "POST",
//        ContentType: "application/json; charset=utf-8",
//        data: JSON.stringify(param),
//        success: function(res) {
//            alert("sdofij");
//        }
//    });
//}



function CourseUpdateSuccess(respons) {
    alert("Update Successfull");
}
function CourseUpdateSuccess(respons) {
    alert(respons);
}