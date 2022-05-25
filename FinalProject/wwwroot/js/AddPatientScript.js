$(document).ready(function () {


	$("#submitFormid").click(function (e) {
		var FirstName = $('#FName').val();
		var LastName = $('#LName').val();
		var age = $("#Age").val()


		if ($("#FName").val() == '' || checkName(FirstName) == false) {
			$("#FName").css('border', '1px solid red');
			$("#error_name").html("Please enter valid First Name with no special characters and numbers.").css("color", "red");
			return false;
		}
		else {
			$("#error_name").hide();
			$("#FName").css('border', '1px solid black');
        }


		if ($("#LName").val() == '' || checkName(LastName) == false) {
			$("#LName").css('border', '1px solid red');
			$("#Lerror_name").html("Please enter valid Last Name with no special characters and numbers.").css("color", "red");
			return false;
		}
		else {
			$("#Lerror_name").hide();
			$("#LName").css('border', '1px solid black');
        }
		if ($("#Gender").val() == '') {
			$("#Gender").css('border', '1px solid red');
			$("#gerror_name").html("Please enter Gender").css("color", "red");
			return false;
		}
		else {
			$("#gerror_name").hide();
			$("#Gender").css('border', '1px solid black');
        }
		if ($("#Age").val() == '' || age > 120) {
			$("#Age").css('border', '1px solid red');
			$("#error_age").html("Please enter valid age less than 120").css("color", "red");
			return false;
		}
		else {
			$("#error_age").hide();
			$("#Age").css('border', '1px solid black');
        }

		if ($("#dob").val() == '') {
			$("#dob").css('border', '1px solid red');
			$("#error_dob").html("Please enter Date of birth").css("color", "red");
			return false;
		}
		else {
			$("#error_dob").hide();
			$("#dob").css('border', '1px solid black');

        }
		
	});

	function checkName(namevalue) {
		//regular expression for email
		var pattern = new RegExp("^[a-zA-Z ]+$")
		if (pattern.test(namevalue)) {
			return true;
		} else {
			return false;
		}
	}

});

