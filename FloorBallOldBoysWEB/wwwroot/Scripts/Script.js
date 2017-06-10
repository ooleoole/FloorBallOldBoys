
$(function () {
    $("body").on("submit", checkBeforeSubmit);



});

$("#myAccount").on("click",
    function () {
        $.ajax("/api/account/myAccount",
            {
                type: "GET",
                success: function (result) {
                    console.log(result);
                    $("#main_content").html(result);
                }

            });
    });

$("#allTrainings").on("click",
    function () {
        $.ajax("/api/training/getAllTranings",
            {
                type: "GET",
                success: function (result) {
                    console.log(result);
                    $("#main_content").html(result);


                }
            });
    });

$(document).on("click", "#edit",
    function (event) {
        event.preventDefault();
        $.ajax("/api/account/edit",
            {
                type: "GET",
                data: {
                    id: $(document).
                        find("#edit").
                        data().
                        id

                },
                success: function (result) {
                    console.log(result);
                    $("#main_content").html(result);
                }
            });
    });
$(document).on("click", "#post-edit",
    function () {
        $.ajax("/api/account/edit",
            {
                type: "POST",
                data: $("form").serialize(),
                success: function (result) {
                    console.log(result);
                    $("#main_content").html(result);

                }
            }
        );
    });

$(document).on("click", ".enroll", modelRequest);

$(document).on("click", ".dismiss", modelRequest);

$(document).on("click", "#delete-training", modelRequest);
//function () {
//    $(document).off("click", "#delete-training");
//    var modelJsValue = $(this).attr("data-model");
//    $.ajax("/api/training/deleteTraining",
//        {
//            type: "POST",
//            data: JSON.parse(modelJsValue),
//            success: function (result) {
//                console.log(result);
//                $("#main_content").html(result);

//            },
//            complete: function () {
//                //$(document).on("click", "#delete-training", dissmissTraining);
//            }
//        }
//    );
//});

function modelRequest(event) {
    var element = $(event.target);
    if (element.hasClass("requestRunning")) {
        return;
    }
    element.addClass("requestRunning");
    var htmlTarget = element.data("html-target");
    var url = element.data("url");
    var method = element.data("method");
    var modelJsValue = $(element).attr("data-model");
    $.ajax(url,
        {
            type: method,
            data: JSON.parse(modelJsValue),
            success: function (result) {
                console.log(result);
                $(htmlTarget).html(result);

            },
            complete: function () {

                element.removeClass("requestRunning");
            }
        }
    );
};
function enrollTraining(event) {


    if ($(event.target).hasClass("requestRunning")) {
        return;
    }
    $(event.target).addClass("requestRunning");
    var modelJsValue = $("#" + event.target.id).attr("data-model");
    $.ajax("/api/training/enrollTraining",
        {
            type: "POST",
            data: JSON.parse(modelJsValue),
            success: function (result) {
                console.log(result);
                $("#main_content").html(result);


            },
            complete: function () {

                $(event.target).addClass("requestRunning");
            }
        }
    );
};



var wasSubmitted = false;
function checkBeforeSubmit() {
    if (!wasSubmitted) {
        wasSubmitted = true;
        return wasSubmitted;
    }
    return false;
}




