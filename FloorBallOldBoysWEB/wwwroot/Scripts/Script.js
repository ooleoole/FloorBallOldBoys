
$(function () {
    $("body").on("submit", checkBeforeSubmit);
});



//--------------AJAX------------------------------------//
$(document).on("click", "#edit-account", modelRequest);
$(document).on("click", ".enroll", modelRequest);
$(document).on("click", ".dismiss", modelRequest);
$(document).on("click", "#delete-training", modelRequest);
$(document).on("click", ".reset-edit-training-form", modelRequest);
$(document).on("click", ".edit-training", modelRequest);

$(document).on("click", "#edit-account-post", formRequest);
$(document).on("click", ".post-edit-training", formRequest);
$(document).on("click", "#create-training-post", formRequest);

$(document).on("click", "#email", basicGetRequest);
$(document).on("click", "#logo", basicGetRequest);
$(document).on("click", "#my-account-btn", basicGetRequest);
$(document).on("click", "#reset-create-training-form", basicGetRequest);
$(document).on("click", "#todays-trainings-btn", basicGetRequest);
$(document).on("click", "#create-training-btn", basicGetRequest);
$(document).on("click", "#all-trainings-btn", basicGetRequest);

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
                actionType === "delete" ?
                    action(htmlTarget) : action(htmlTarget, result);
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
                actionType === "delete" ?
                    action(htmlTarget) : action(htmlTarget, result);
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
            };
        case "add-toggle-training":
            return function (htmlTarget, html) {
                $(htmlTarget).html(html);
                setCurrentPageOnNavbar(html);
                $(".panel-footer").hide().
                    siblings(".main-panel-body").hide().
                    parent().find(".glyphicon")
                    .removeClass("glyphicon-chevron-up")
                    .addClass("glyphicon-chevron-down");

            };
        case "addSmooth":
            return function (htmlTarget, html) {
                setCurrentPageOnNavbar(html);
                $(htmlTarget).hide().html(html).fadeIn();


            }
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

$(document).on("click", ".panel-heading-training", function () {
    $(this).siblings(".main-panel-body").toggle("slow", function () {
        $(this).siblings(".panel-footer").toggle("slow", function () {
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
    element.addClass("effectRunning").
        effect("shake",
        {
            times: 2,
            distance: 2,
            direction: "down"
        }, 500, function () {
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
    }
    else if (~html.indexOf("<div id=\"all-trainings\">")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#all-trainings-btn").addClass("btn-pressed");
    }
    else if (~html.indexOf("<div id=\"todays-trainings\">")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#todays-trainings-btn").addClass("btn-pressed");
    }
    else if (~html.indexOf("<div id=\"create-training\"")) {
        $(".navbar-btn").removeClass(classesToRemove);
        $("#create-training-btn").addClass("create-training-btn-pressed");
    }
}

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




