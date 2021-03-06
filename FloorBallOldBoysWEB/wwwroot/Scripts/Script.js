﻿
$(function () {
    $("body").on("submit", checkBeforeSubmit);
});


//--------------AJAX------------------------------------//
$(document).on("click", "#edit-account, #delete-training," +
    ".enroll, .dismiss, #delete-training," +
    ".reset-edit-training-form, .edit-training," +
    ".uncancel, .cancel", modelRequest);


$(document).on("click", "#edit-account-post, #create-training-post," +
    ".post-edit-training", formRequest);


$(document).on("click", "#cancel-account-post-btn, #email, #logo," +
    "#my-account-btn, #reset-create-training-form, #todays-trainings-btn," +
    "#create-training-btn, #all-trainings-btn", basicGetRequest);



function basicGetRequest(event) {
    var element = $(event.target);
    if (element.hasClass("requestRunning")) {
        return;
    }
    element.addClass("requestRunning");
    var htmlTarget = element.data("html-target");
    var url = element.data("url");
    var actionType = element.data("action-type");
    $.ajax(url,
        {
            type: "GET",
            success: function (result) {
                console.log(result);
                var action = domActionSelector(actionType);
                actionType === "delete" ? action(htmlTarget) : action(htmlTarget, result);
            },
            error: function (xhr, textStatus, error) {
                errorHandler(xhr, textStatus, error);
                element.removeClass("requestRunning");

            },
            complete: function () {

                element.removeClass("requestRunning");

            }
        }
    );
}


function formRequest(event) {
    event.preventDefault();
    var element = $(event.target);
    if (element.hasClass("requestRunning")) {
        return;
    }

    element.addClass("requestRunning");
    var htmlTarget = element.data("html-target");
    var url = element.data("url");
    var actionType = element.data("action-type");
    var form = $(element).data("form");
    $.ajax(url,
        {
            type: "POST",
            data: $(form).serialize(),
            success: function (result) {
                console.log(result);
                var action = domActionSelector(actionType);
                actionType === "delete" ? action(htmlTarget) : action(htmlTarget, result);
            },
            error: function (xhr, textStatus, error) {
                errorHandler(xhr, textStatus, error);
                element.removeClass("requestRunning");
            },
            complete: function () {

                element.removeClass("requestRunning");
            }
        }
    );
}

function modelRequest(event) {
    event.preventDefault();
    var element = $(event.target);
    if (element.hasClass("requestRunning")) {
        return;
    }
    element.addClass("requestRunning");
    var htmlTarget = element.data("html-target");
    var url = element.data("url");
    var method = element.data("method");
    var actionType = element.data("action-type");
    var modelJsValue = $(element).attr("data-model");
    $.ajax(url,
        {
            type: method,
            data: JSON.parse(modelJsValue),
            success: function (result) {
                console.log(result);
                var action = domActionSelector(actionType);
                actionType === "delete" ? action(htmlTarget) : action(htmlTarget, result);
            },
            error: function (xhr, textStatus, error) {
                errorHandler(xhr, textStatus, error);
                element.removeClass("requestRunning");

            },
            complete: function () {

                element.removeClass("requestRunning");
            }
        }
    );
}

function domActionSelector(actionType) {

    switch (actionType) {
        case "add":
            return function (htmlTarget, html) {
                $(htmlTarget).html(html);
                setCurrentPageOnNavbar(html);
                registerFormsToValidator();
            };
        case "add-toggle-training":
            return function (htmlTarget, html) {
                $(htmlTarget).html(html);
                setCurrentPageOnNavbar(html);
                registerFormsToValidator();
                $(".panel-footer").hide().siblings(".main-panel-body").hide().parent().find(".glyphicon")
                    .removeClass("glyphicon-chevron-up")
                    .addClass("glyphicon-chevron-down");

            };
        case "addSmooth":
            return function (htmlTarget, html) {
                setCurrentPageOnNavbar(html);
                $(htmlTarget).hide().html(html).fadeIn();
                registerFormsToValidator();

            };
        case "delete":
            return function (htmlTarget) {
                $(htmlTarget).fadeOut("slow",
                    function () {
                        $(this).remove();
                    });
            };

        default:
            throw "Invalid action-type";
    }

};

//------------------------styling---------------------------------//
$(document).on("click",
    ".panel-heading-training",
    function () {
        $(this).siblings(".main-panel-body").toggle("slow",
            function () {
                $(this).siblings(".panel-footer").toggle("slow",
                    function () {
                        $(this).parent().find(".glyphicon")
                            .toggleClass("glyphicon-chevron-down").toggleClass("glyphicon-chevron-up");
                    });
            });
    });

$(document).on("mouseenter", ".training-panel", shake);
$(document).on("touchmove", ".training-panel", shake);
$("#navbar-buttons").buttonset();

function shake() {
    var element = $(this).children(":hidden").parents(".training-panel");
    if (element.hasClass("effectRunning")) {
        return;
    }
    element.addClass("effectRunning").effect("shake",
        {
            times: 2,
            distance: 2,
            direction: "down"
        },
        500,
        function () {
            element.removeClass("effectRunning");
        });
};

function setCurrentPageOnNavbar(html) {
    var classesToRemove = "btn-pressed " +
        "myaccount-btn-pressed " +
        "create-training-btn-pressed";
    if (~html.indexOf("<div id=\"my-account\"")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#my-account-btn").addClass("myaccount-btn-pressed");
    } else if (~html.indexOf("<div id=\"all-trainings\">")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#all-trainings-btn").addClass("btn-pressed");
    } else if (~html.indexOf("<div id=\"todays-trainings\">")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#todays-trainings-btn").addClass("btn-pressed");
    } else if (~html.indexOf("<div id=\"create-training\"")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#create-training-btn").addClass("create-training-btn-pressed");
    }
}

$(document).on("mouseenter touchstart ",
    "#delete-training",
    function () {
        $("[data-toggle=confirmation]").confirmation({
            rootSelector: "[data-toggle=confirmation]"
        });
    });

$(document).on("click",
    "#change-password-btn",
    function () {
        $("#change-password-tbody").toggle();
        $(this).hide();
    });
//---------------------------misc-------------------------------//
function errorHandler(xhr, textStatus, error) {
    console.log(xhr.statusText);
    console.log(textStatus);
    console.log(error);
};


var wasSubmitted = false;

function checkBeforeSubmit() {
    if (!wasSubmitted) {
        wasSubmitted = true;
        return wasSubmitted;
    }
    return false;
}


function registerFormsToValidator() {
    $(document).find("form").removeData("validator").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");

};
