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

    $("#categoryForm").validate({
        rules: {
            Code: {
                required: true,
                minlength:4,
                maxlength: 4
            },
            Name: {
                required: true
            }
        },
        messages: {
            Code: {
                required: "Code is required",
                minlength:"Minimum 4 character required",
                //minlength: jQuery.validator.format("At least {0} characters required!"),
                maxlength: "Maximum 4 character allowed"
            },
            Name: {
                required:"Name is required"
            }
        }
    });

    //document.getElementById("saveError").style.display = "none";
    $("#saveButton").click(function () {
        //document.getElementById("saveError").style.display = "none";
        //alert("hi");
        if ($("#categoryForm").valid()) {
            $.ajax({
                    type: "POST",
                    url: "/Category/Create",
                    data: $("#categoryForm").serialize()

            })
            .done(function (response) {
                if (response.Success) {
                    swal({
                            title: "Saved Successfully",
                            //text: "Once deleted, you will not be able to recover this imaginary file!",
                            icon: "success",
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

    $("#updateButton").click(function () {
        //document.getElementById("saveError").style.display = "none";
        alert("hi");
        if ($("#categoryForm").valid()) {
            $.ajax({
                    type: "POST",
                    url: "/Category/Edit",
                    data: $("#categoryForm").serialize()

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
});