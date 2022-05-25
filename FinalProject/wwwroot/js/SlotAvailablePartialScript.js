$(document).ready(function () {
	console.log("slotdom");

	$("#SubmitID2").click(function (e) {
		
		if ($("#Dropdownslot").val() == '') {
			$("#Dropdownslot").css('border', '1px solid red');
			$("#slot_error").html("Please enter  Slot.").css("color", "red");
			console.log("slot");
			return false;
		}

		else {
			$("#serror_name").hide();
			$("#Dropdownslot").css('border', '1px solid black');
			
		}

	});


});

