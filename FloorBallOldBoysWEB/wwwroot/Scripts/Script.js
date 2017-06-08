
$(function () {
    $("body").on("submit", checkBeforeSubmit);



});

$("#MyAccount").on("click",
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
                success:function(result) {
                    console.log(result);
                    $("#main_content").html(result);

                }
    }
    )
});

var wasSubmitted = false;
function checkBeforeSubmit() {
    if (!wasSubmitted) {
        wasSubmitted = true;
        return wasSubmitted;
    }
    return false;
}




