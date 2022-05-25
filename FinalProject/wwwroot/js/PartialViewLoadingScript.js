$(document).ready(function () {

   
        $("#btnClosePopup").click(function () {
            $("#MyPopup").modal("hide");
        });
 
    $("#partialviews").click(function () {

        if ($("#pid").val() == '') {
            $("#pid").css('border', '1px solid red');
            $("#error_name").html("Please enter Patient ID.").css("color", "red");
            return false;
        }
        else if ($("#specialization").val() == '') {
            $("#specialization").css('border', '1px solid red');
            $("#error_specialization").html("Please enter Specialization").css("color", "red");
            return false;
        }

        else {

            $("#error_name").hide();
            $("#pid").css('border', '1px solid black');
            $("#error_specialization").hide();
            $("#specialization").css('border', '1px solid black');
            //Set the URL.
            var url = "/Home/SearchPatient";

            //Add the Field values to FormData object.
            var formData = new FormData();
            formData.append("patientID", $("#pid").val());
            formData.append("Specialization", $("#specialization").val());

            $.ajax({
                type: 'POST',
                url: url,
                data: formData,
                processData: false,
                contentType: false,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },

                success: function (response) {
                    if (response.message != null) {
                        $("#viewholder").load('/Home/PartialViewAction');
                    }
                    else {
                        $("#MyPopup .modal-body").html("Patient ID Doesn't Exist Please Add patient");

                        $("#MyPopup").modal("show");

                    }

                },
                error: function (response) {

                }
            });
        }
    });
    
});