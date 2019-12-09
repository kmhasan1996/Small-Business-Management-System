$(document).ready(function () {

    $("#Code").prop("disabled", true);

    $('input[name="Code"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
    });
    //$('input[name="Name"]').keyup(function (e) {
    //    var regexp = /[^a-zA-Z]/g;
    //    if ($(this).val().match(regexp)) {
    //        $(this).val($(this).val().replace(regexp, ''));
    //    }
    //});

    $('input[name="LoyaltyPoint"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
    });
    $('input[name="Contact"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }

    });


    $("#customerForm").validate({
        rules: {
            Code: {
                required: true,
                minlength:4,
                maxlength: 4
            },
            Name: {
                required: true
            },
            Email: {
                required: true,
                email: true
                //remote: function () {
                //    var r = {
                //        url: "Customer/CheckEmailAvailability",
                //        type: "POST",
                //        contentType: "application/json; charset=utf-8",
                //        dataType: "json",
                //        data: "{'email': '" + $("#Email").val() + "'}",
                //        //dataFilter: function (data) { return (JSON.parse(data)).d; }
                //    }
                //    return r;
                //}
            },
            Contact: {
                required: true,
                minlength: 11,
                maxlength: 11
            },
            LoyaltyPoint: {
                required: true
            },
            Address: {
                required: true
            }
        },
        messages: {
            Code: {
                required: "Code is required",
                minlength: jQuery.validator.format("Minimum {0} character required"),
                maxlength: jQuery.validator.format("Maximum {0} character allowed")
            },
            Name: {
                required:"Name is required"
            },
            Email: {
                required: "Email is required",
                email: "Enter a valid email"
                //remote: "This email address is already registered."
            },
            Contact: {
                required: "Contact is required",
                minlength: jQuery.validator.format("Minimum {0} character required"),
                maxlength: jQuery.validator.format("Maximum {0} character allowed")
            },
            LoyaltyPoint: {
                required: "LoyaltyPoint is required"
            },
            Address: {
                required: "Address is required"
            }
        }
    });

    var emailError = false;

    $('input[name="Email"]').keyup(function (e) {

        var x = document.getElementById("EmailError");
        $.ajax({
            url: "Customer/UniqueEmail",
            type: "POST",
            data: $("#customerForm").serialize(),
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            //data: "{'Email': '" + $("#Email").val() + "'}",
            dataFilter: function (response) {

                if (response === "True") {
                    emailError = true;
                    x.innerHTML = "Email already exist";
                    x.style.color = "red";

                } else {
                    emailError = false;
                    x.innerHTML = "";
                }

            }

        });

    });
    var contactError = false;
    $('input[name="Contact"]').keyup(function (e) {

        var x = document.getElementById("ContactError");
        $.ajax({
            url: "Customer/UniqueContact",
            type: "POST",
            data: $("#customerForm").serialize(),
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            //data: "{'contact': '" + $("#Contact").val() + "'}",
            dataFilter: function (response) {

                if (response === "True") {
                    contactError = true;
                    x.innerHTML = "Contact already exist";
                    x.style.color = "red";

                } else {
                    contactError = false;
                    x.innerHTML = "";
                }

            }

        });

    });



    $("#saveButton").click(function() {

        if ($("#customerForm").valid() && !emailError && !contactError) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Customer/Create",
                    data: $("#customerForm").serialize()

                })
                .done(function (response) {
                    if (response.Success) {
                        Swal.fire({
                            title: 'Saved Successfully',
                            icon: 'success',
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'OK'
                        }).then((result) => {
                            if (result.value) {
                                window.location.reload();
                            }
                        });

                    } 

                })
                .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                    alert("Fail");
                });
        }
        
    });

    $("#updateButton").click(function () {
       
        if ($("#customerForm").valid() && !emailError && !contactError) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Customer/Edit",
                    data: $("#customerForm").serialize()

            })
            .done(function (response) {
                if (response.Success) {
                    Swal.fire({
                        title: "Updated Successfully",
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.value) {
                            window.location.reload();
                        }
                    });

                } else {
                    Swal.fire({
                        title: "Updated Successfully",
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.value) {
                            window.location.reload();
                        }
                    });
                }

            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });
        };
        
    });

    $("#closeButton").click(function () {
        location.reload();
    });

});