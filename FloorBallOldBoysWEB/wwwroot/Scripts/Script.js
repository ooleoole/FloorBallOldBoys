
$(function() {
    $("body").on("submit", checkBeforeSubmit);



});

$("#MyAccount").on("click",
    function () {
        $.ajax("/api/account/myAccount",
            {
                type: "GET",
                success:function(result) {
                    console.log(result);
                    $("#main_content").html(result);

                }

            });
    });

var wasSubmitted = false;
function checkBeforeSubmit() {
    if (!wasSubmitted) {
        wasSubmitted = true;
        return wasSubmitted;
    }
    return false;
}




