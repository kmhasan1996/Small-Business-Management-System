$(function () {
    //alert("hi");
    $('input[name="Code"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
    });
    $('input[name="Name"]').keyup(function (e) {
        var regexp = /[^a-zA-Z]/g;
        if ($(this).val().match(regexp)) {
            $(this).val($(this).val().replace(regexp, ''));
        }
    });

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

    //$.validator.setDefaults({
    //    errorClass: "help-block",
    //    highlight: function (element) {
    //        $(element)
    //        .closest(".form-control")
    //        //.closest('.form-control')
    //        .addClass("has-error");
    //    },
    //    unhighlight: function (element) {
    //        $(element)
    //        .closest(".form-control")
    //        //.closest('.form-control')
    //        .removeClass("has-error");
    //    }
    //});

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
                required: true,
                email: true
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
                required: "Email is required",
                email: "Enter a valid email"
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


    $("#saveButton").click(function () {
        // document.getElementById("saveError").style.display = "none";

        if ($("#supplierForm").valid()) {
            $.ajax({
                    type: "POST",
                    url: "/Supplier/Create",
                    data: $("#supplierForm").serialize()

                })
                .done(function (response) {
                    if (response.Success) {
                        swal({
                            title: "Saved Successfully",
                            //text: "Once deleted, you will not be able to recover this imaginary file!",
                            icon: "warning",
                            buttons: true,
                            dangerMode: true

                        })
                        .then((willDelete) => {
                            if (willDelete) {
                                window.location.reload();
                            }
                        });
                    } else {
                        $("#saveError").html(response.Message);
                    }

                })
                .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Fail");
                });
        };
       
    });

    $("#updateButton").click(function () {
        // document.getElementById("saveError").style.display = "none";
        if ($("#supplierForm").valid()) {
            $.ajax({
                    type: "POST",
                    url: "/Supplier/Edit",
                    data: $("#supplierForm").serialize()

            })
            .done(function (response) {
                if (response.Success) {
                    swal({
                            title: "Updated Successfully",
                            //text: "Once deleted, you will not be able to recover this imaginary file!",
                            icon: "warning",
                            buttons: true,
                            dangerMode: true

                        })
                        .then((willDelete) => {
                            if (willDelete) {
                                window.location.reload();
                            }
                        });
                } else {
                    $("#saveError").html(response.Message);
                }

            })
            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });
        };
        
    });

    $("#closeButton").click(function () {
        location.reload();
    });


});