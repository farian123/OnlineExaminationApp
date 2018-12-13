
////////////partial view load //////////
$(document).ready(function () {
    var id = $("#CourseDetailsButton").attr("data-id");
    var urlSet = "../../Courses/CourseEditPv";
    assaignAllToPv(id, urlSet);
});

$(document.body).on("click", "#CourseDetailsButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Courses/CourseEditPv";
    assaignAllToPv(id, urlSet);
});
$(document.body).on("click", "#AssignTrainerButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Courses/AssignTrainerPv";
    assaignAllToPv(id, urlSet);
});
$(document.body).on("click", "#ExamCreateButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Courses/ExamCreatePv";
    assaignAllToPv(id, urlSet);
});


function assaignAllToPv(id, urlSet) {
    var params = { id: id };
    $.post(urlSet, params, function (rData) {
            if (rData != undefined && rData != "") {
                $("#PartialLoadDiv").html(rData);
            }
        });
}
//////////Exam create or not create Ajaz messege//////////////////
function ExamCreateSuccess(respons) {
    alert("Exam Created Successfull");
}
function ExamCreateFailed(respons) {
    alert("Exam Created Unsuccessfull");
}

//////////Trainer create or not create Ajaz messege//////////////////
function TrainerCreateSuccess(respons) {
    alert("Trainer Created Successfull");
}
function TrainerCreateFailed(respons) {
    alert("Trainer Created Unsuccessfull");
}


//////////////add trainer when click + button....Show Modal.............//////
$(document.body).on("click", "#AddTrainerForFixedCourse", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Courses/CreateTrainerInCoursePv";

    var params = { id: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadTrainerCreateDiv").html(rData);
        }
    });
});

////////for cascading dropdown//////////////
$("#CountryId").change(function () {
    var countryId = $("#CountryId").val();

    var param = { countryId: countryId };
    $.ajax({
        url: "../../Courses/GetCityByCountryId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function (response) {
            if (response != undefined && response != null && response != "") {
                $.each(response, function (k, v) {
                    $("#CityId").append("<option value='" + v.Id + "'>'" + v.Name + "'</option>");
                });
            }
        }
    });
});
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



