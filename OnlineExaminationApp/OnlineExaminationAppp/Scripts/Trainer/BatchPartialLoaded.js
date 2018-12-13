////////////partial view load //////////
$(document).ready(function () {
    var id = $("#BatchDetailsButton").attr("data-id");
    var urlSet = "../../Batches/BatchEditPv";
    assaignAllToPv(id, urlSet);
});

$(document.body).on("click", "#BatchDetailsButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Batches/BatchEditPv";
    assaignAllToPv(id, urlSet);
});
$(document.body).on("click", "#AssignParticipantButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Batches/AssignParticipantPv";
    assaignAllToPv(id, urlSet);
});
$(document.body).on("click", "#AssignTrainerForBatchButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Batches/AssignTrainerForBatchPv";
    assaignAllToPv(id, urlSet);
});
$(document.body).on("click", "#SheduleExamCreateButton", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Batches/SheduleExamCreatePv";
    assaignAllToPv(id, urlSet);
});


function assaignAllToPv(id, urlSet) {
    var params = { id: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#BatchPartialLoadDiv").html(rData);
        }
    });
}