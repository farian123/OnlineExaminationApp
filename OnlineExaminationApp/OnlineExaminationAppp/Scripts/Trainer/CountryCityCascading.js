//$("#CountryId").change(function () {
//    var organizationId = $("#OrganizationId").val();

//    var param = { organizationId: organizationId };
//    $.ajax({
//        url: "../../Batches/GetCourseByOrganizationId",
//        type: "POST",
//        ContentType: "application/json; charset=utf-8",
//        data: JSON.stringify(param),
//        success: function (response) {
//            if (response != undefined && response != null && response != "") {
//                $.each(response, function (k, v) {
//                    $("#CourseId").append("<option value='" + v.Id + "'>'" + v.Name + "'</option>");
//                });
//            }
//        }
//    }), fail(function (rdata) {
//        alert(rdata);
//    });
//});

////////for cascading dropdown//////////////
//country and city cascading//////////////
$(document.body).on("change", "#CountryId", function () {
    var countryId = $("#CountryId").val();

    var param = { countryId: countryId };
    $.ajax({
        url: "../../Trainers/GetCityByCountryId",
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
    }), fail(function (rdata) {
        alert(rdata);
    });
});


//Get course By Organization cascading//////////////
$(document.body).on("change", "#OrganizationId", function () {
    var organizationId = $(this).val();

    var param = { organizationId: organizationId };
    $.ajax({
        url: "../../Trainers/GetCourseByOrganizationId",
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
    }),fail(function (rdata) {
        alert(rdata);
    });
});

//Get batch by course cascading//////////////
$(document.body).on("change", "#CourseId", function () {
    var courseId = $(this).val();

    var param = { courseId: courseId };
    $.ajax({
        url: "../../Trainers/GetBatchByCourseId",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(param),
        success: function (response) {
            if (response != undefined && response != null && response != "") {
                $("#BatchId").empty();
                $("#BatchId").append('<option>--Select--</option>');
                $.each(response, function (k, v) {
                    $("#BatchId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    }),fail(function(rdata) {
        alert(rdata);
    });
});

