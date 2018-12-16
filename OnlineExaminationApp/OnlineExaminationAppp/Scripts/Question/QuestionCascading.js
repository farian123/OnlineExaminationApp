//Get course By Organization cascading//////////////
$(document.body).on("change", "#OrganizationId", function () {
    var organizationId = $(this).val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../Questions/GetCourseByOrganizationId",
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
    $.ajax({
        url: "../../Questions/GetExamByCourseId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function (response) {
            if (response != undefined && response != null && response != "") {
                $("#ExamId").empty();
                $("#ExamId").append('<option>--Select--</option>');
                $.each(response, function (k, v) {
                    $("#ExamId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    }), fail(function (rdata) {
        alert(rdata);
    });
});

//Get All Question by ExamId cascading//////////////
$(document.body).on("change", "#ExamId", function () {
    var id = $(this).val();

    var urlSet = "../../Questions/GetAllQuestionByExamId";
    assaignAllToPv2(id, urlSet);
});

function assaignAllToPv2(id, urlSet) {
    var params = { examId: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadAllQuestionByExam").html(rData);
        }
    });
}



//Get Question Option by AnswerTypeId cascading//////////////
$(document.body).on("change", "#AnswerTypeId", function () {
    var id = $(this).val();

    var urlSet = "../../Questions/AnswerTypeSelectByAnswerTypeId";
    assaignAllToPv(id, urlSet);
});

function assaignAllToPv(id, urlSet) {
    var params = { answerTypeId: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadAddingQuestionAnswer").html(rData);
        }
    });
}


//Answer By click + button cascading//////////////
$(document.body).on("click", "#AddAnswerButton", function () {
    var id = $(this).val();

    var urlSet = "../../Questions/AnswerTypeSelectByAnswerTypeId";
    assaignAllToPv(id, urlSet);
});

function assaignAllToPv(id, urlSet) {
    var params = { answerTypeId: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadAddingQuestionAnswer").html(rData);
        }
    });
}


//////////Answer create or not create Ajax messege//////////////////
function SelectionAnswerSuccess(respons) {
    //alert("Exam Created Successfull");

    if (respons != undefined && respons != "") {
        $("#AddedWrittenAnswerShowPv").html(respons);
    }

    //var id = $("#ExamCreateButton").attr("data-id");
    //var urlSet = "../../Courses/ExamCreatePv";
    //assaignAllToPv(id, urlSet);
}
function SelectionAnswerFailed(respons) {

    alert("Exam Created Unsuccessfull");

}


//Answer Delete by click remove  button//////////////
$(document.body).on("click", "#RemoveButton", function () {
    var id = $(this).attr("data-id");

    var urlSet = "../../Questions/RemoveSelectionAnswer";
    var params = { answerIdd: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadAddingQuestionAnswer").html(rData);
        }
    });
});
//Answer And question Save by Save  button//////////////
$(document.body).on("click", "#SaveButton", function () {
    var textQuestion = $("#WriteQuestion").val();
    var mark = $("#Mark").val();

    var urlSet = "../../Questions/SaveQuestion";
    var params = { question: textQuestion,mark:mark };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            alert("Save successfull");
            $("#PartialLoadAllQuestionByExam").html(rData);
        } else {
            alert("Please first select Exam,Option Type and Add Question and answer");
        }
    });
});