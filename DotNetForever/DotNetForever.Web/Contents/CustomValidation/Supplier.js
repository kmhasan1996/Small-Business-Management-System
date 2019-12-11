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

    var emailError2 = false;
    $('input[name="Email"]').keyup(function (e) {

        var email = $("#Email").val();
        var x = document.getElementById("EmailError2");

        if (email !== "") {
            //alert(email);
            if (!validateEmail($("#Email").val())) {
                emailError2 = true;
                x.innerHTML = "Invalid email address";
                x.style.color = "red";

            } else {
                emailError2 = false;
                x.innerHTML = "";
            }
        } else {
            emailError2 = false;
            x.innerHTML = "";
        }


    });

    function validateEmail(email) {
        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return expr.test(email);
    };
    $('input[name="Contact"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
    });

    $('input[name="ContactPerson"]').keyup(function (e) {
        var regexp = /[^a-zA-Z]/g;
        if ($(this).val().match(regexp)) {
            $(this).val($(this).val().replace(regexp, ''));
        }
    });

    $("#supplierForm").validate({
        rules: {
            Code: {
                required: true,
                minlength: 4,
                maxlength: 4
            },
            Name: {
                required: true
            },
            Email: {
                required: true
            },
            Contact: {
                required: true,
                minlength: 11,
                maxlength: 11
            },
            ContactPerson: {
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
                required: "Name is required"
            },
            Email: {
                required: "Email is required"
            },
            Contact: {
                required: "Contact is required",
                minlength: jQuery.validator.format("Minimum {0} character required"),
                maxlength: jQuery.validator.format("Maximum {0} character allowed")
            },
            ContactPerson: {
                required: "Contact person is required"
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
            url: "Supplier/UniqueEmail",
            type: "POST",
            data: $("#supplierForm").serialize(),
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
            url: "Supplier/UniqueContact",
            type: "POST",
            data: $("#supplierForm").serialize(),
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

    $("#saveButton").click(function () {
        // document.getElementById("saveError").style.display = "none";

        if ($("#supplierForm").valid() && !emailError && !contactError && !emailError2) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Supplier/Create",
                    data: $("#supplierForm").serialize()

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
        };
       
    });

    $("#updateButton").click(function () {
       
        if ($("#supplierForm").valid() && !emailError && !contactError && !emailError2) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Supplier/Edit",
                    data: $("#supplierForm").serialize()

            })
            .done(function (response) {
                if (response.Success) {
                    Swal.fire({
                        title: 'Updated Successfully',
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
                        title: 'Updated Successfully',
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