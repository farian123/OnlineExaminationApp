//////////partial view load //////////
$(document).ready(function () {
    var id = $("#TakingExamId").attr("data-id");
    var urlSet = "../../ExamAttend/QuestionGetSequentially";
    assaignAllToPv(id, urlSet);
});
$(document.body).on("click", "#CourseDetailsButton", function () {
    var id = $("#TakingExamId").attr("data-id");
    var urlSet = "../../ExamAttend/NextQuestionGet";
    assaignAllToPv(id, urlSet);
});
function assaignAllToPv(id, urlSet) {
    var params = { id: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadQuenstionAndAnswerPv").html(rData);
        }
    });
}