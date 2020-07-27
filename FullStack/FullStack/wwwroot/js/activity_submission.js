$(function () {

    // Handle form submission
    $("#form-activity").submit(function (e) {
        e.preventDefault();

        let $form = $("#form-activity");

        if ($form.valid()) {
            // Going to manually remove errors for now. Probably a better way of doing this
            $(".validation-summary-errors").children().remove();

            var $modal = $("#submission-modal");

            $modal.modal('show');
            $modal.find(".modal-body").text("Are you sure?");
        }
    });

    // Handle modal click
    $("#btn-modal-submit").click(function () {
        let $form = $("#form-activity");

        let $modalBody = $("#submission-modal").find(".modal-body");
        $modalBody.text("...processing...");

        let jsonObj = {
            Email: $form.find("#Email").val(),
            FirstName: $form.find("#FirstName").val(),
            LastName: $form.find("#LastName").val(),
            Comments: $form.find("#Comments").val(),
            ActivityId: $form.find("#ActivityId").val()
        };

        $.ajax({
            method: "POST",
            url: $form.attr("action"),
            data: JSON.stringify(jsonObj),
            dataType: "json",
            contentType: "application/json"
        }).done(function (data) {
            $modalBody.html("<span class='text-green'>Success!</span> <a href='/Home/Submissions'>Click the following to see list of submissions.</a>");
            // Clear fields
            $form.find(".form-control").val("");
        }).fail(function (data) {
            $modalBody.text("Sorry, we're experiencing some technical difficuly - please try again later! :)");
        });
    });
});