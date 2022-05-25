$(document).ready(function () {
	

	$("#submitForm").click(function (e) {
		
		var FirstName = $('#FName').val();
		var LastName = $('#LName').val();
		var startDT = ($("#vsfrom").val());
		var endDT = ($("#vsto").val());
		var CorrectHours = daysdifference(startDT, endDT);

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
			$("#Lerror_name").html("Please enter valid Last Name with no special characters and numbers..").css("color", "red");
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
		if ($("#specialization").val() == '') {
			$("#specialization").css('border', '1px solid red');
			$("#serror_name").html("Please enter Specialization").css("color", "red");
			return false;
		}
		else {
			$("#serror_name").hide();
			$("#specialization").css('border', '1px solid black');
		}

		if ($("#vsfrom").val() == '' || CorrectHours == false) {

			$("#vsfrom").css('border', '1px solid red');
			$("#vferror_name").html("Please enter valid visiting hours like r 1hr, 2hrs, 3hrs etc.").css("color", "red");
			return false;
		}
		else {
			$("#vferror_name").hide();
			$("#vsfrom").css('border', '1px solid black');
		}
		if ($("#vsto").val() == '' || CorrectHours == false) {
			$("#vsto").css('border', '1px solid red');
			$("#vuerror_name").html("Please enter exact visiting hours upto 3 hours").css("color", "red");
			return false;
		}
		else {
			$("#vuerror_name").hide();
			$("#vsto").css('border', '1px solid black');
		}
	});

	function daysdifference(firstDate, secondDate){
		var startDay = new Date(firstDate);
		var endDay = new Date(secondDate);    
		var millisBetween = endDay.getTime() - startDay.getTime();

		var diff = (millisBetween) / 1000;
		diff /= 60;
		minutes = Math.abs(Math.round(diff));
		if (minutes % 60 == 0 && millisBetween > 0 && minutes <= 180) {
			return true;
		}
		else {
			$("#vsto").css('border', '1px solid red');
			$("#vuerror_name").html("Please enter exact visiting hours upto 3 hours").css("color", "red");
          return false;
        }
		
	}

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

