
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

    var id = $("#ExamCreateButton").attr("data-id");
    var urlSet = "../../Courses/ExamCreatePv";
    assaignAllToPv(id, urlSet);
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
//$("#CountryId").change(function () {
$(document.body).on("change", "#CountryId", function () {
    var countryId = $("#CountryId").val();

    var param = { countryId: countryId };
    $.ajax({
        url: "../../Courses/GetCityByCountryId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function (response) {
            if (response != undefined && response != null && response != "") {
                $("#CityId").empty();
                $("#CityId").append('<option>--Select--</option>');
                $.each(response, function (k, v) {
                    $("#CityId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    });
});



///////////for image save from partialview//////////////
//$(document.body).on("change", "#image1", function () {
//    var data = new FormData();
//    var files = $("#image1").get(0).files;
//    if (files.length > 0) {
//        data.append("image1", files[0]);
//    }
//    $.ajax({
//        url: "../../Create/Trainers",
//        type: "POST",
//        processData: false,
//        contentType: false,
//        data: data,
//        success: function (response) {
//            alert("uploaded");
//        },
//        error: function (er) {
//            alert("error");
//        }

//    });
//});

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



