$(document).ready(function () {


	$("#SubmitID").click(function (e) {

		if ($("#Dropdownspecial").val() == '') {
			$("#Dropdownspecial").css('border', '1px solid red');
			$("#serror_name").html("Please enter  Doctor.").css("color", "red");
			
			return false;
		}
	   
		else {
			
		    $("#serror_name").hide();
			$("#Dropdownspecial").css('border', '1px solid black');
			console.log("doctor2");
			var url = "/Home/ScheduleAppointments";
			var formData = new FormData();
			formData.append("DoctorName", $("#Dropdownspecial").val());
			$.ajax({
				type: 'POST',
				url: url,
				data: formData,
				processData: false,
				contentType: false,
				
				success: function (response) {
					if (response.message != null) {
						$("#viewholder2").load('/Home/partialViewSlot');
					}
				}
			});
			return false;
		}
		
	});


});

