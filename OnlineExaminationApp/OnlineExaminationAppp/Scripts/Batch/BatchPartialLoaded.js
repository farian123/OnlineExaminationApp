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



//////////////for cascading/////////////////
$(document.body).on("change", "#OrganizationId", function () {
    var organizationId = $(this).val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../Batches/GetCourseByOrganizationId",
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
    });
});

//////////////create trainer when click + button....Show Modal.............//////
$(document.body).on("click", "#AddTrainerForFixedBatch", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Batches/CreateTrainerInBatchPv";

    var params = { id: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadTrainerShowDiv").html(rData);
        }
    });
});

//////////////create participant when click + button....Show Modal.............//////
$(document.body).on("click", "#AddParticipantForFixedBatch", function () {
    var id = $(this).attr("data-id");
    var urlSet = "../../Batches/CreateParticipantInBatchPv";

    var params = { id: id };
    $.post(urlSet, params, function (rData) {
        if (rData != undefined && rData != "") {
            $("#PartialLoadParticipantShowDiv").html(rData);
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

//////////Trainer create or not create Ajaz messege//////////////////
function TrainerCreateSuccess(respons) {
    alert("Trainer Created Successfull");
    //var id = $("#AssignTrainerButton").attr("data-id");
    //var urlSet = "../../Courses/AssignTrainerPv";
    //assaignAllToPv(id, urlSet);

}
function TrainerCreateFailed(respons) {
    alert("Trainer Created Unsuccessfull");
}

//////////Add Trainer for batch Ajaz messege//////////////////
function TrainerAddedSuccess(respons) {
    alert("Trainer Created Successfull");
    var id = $("#AssignTrainerForBatchButton").attr("data-id");
    var urlSet = "../../Batches/AssignTrainerForBatchPv";
    assaignAllToPv(id, urlSet);

}
function TrainerAddedFailed(respons) {
    alert("Trainer Created Unsuccessfull");
}