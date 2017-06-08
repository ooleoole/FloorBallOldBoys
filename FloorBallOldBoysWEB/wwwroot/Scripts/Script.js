
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

$(document).on("click", "#enroll", enrollTraining);

$(document).on("click", "#dismiss", dissmissTraining);
    
function dissmissTraining() {
    var modelJsValue = $(this).attr("data-model");
    $.ajax("/api/training/dismissTraining",
        {
            type: "POST",
            data: JSON.parse(modelJsValue),
            success: function (result) {
                console.log(result);
                $("#main_content").html(result);
                $(document).off("click", this);
            },
            complete: function () {
                $(document).on("click", this, dissmissTraining);
            }
        }
    );
};
function enrollTraining() {
    var modelJsValue = $(this).attr("data-model");
    $.ajax("/api/training/enrollTraining",
        {
            type: "POST",
            data: JSON.parse(modelJsValue),
            success: function (result) {
                console.log(result);
                $("#main_content").html(result);
                $(document).off("click", this);

            },
            complete: function () {
                $(document).on("click", this, enrollTraining);
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




