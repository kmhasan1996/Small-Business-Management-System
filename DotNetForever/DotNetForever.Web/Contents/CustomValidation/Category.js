$(document).ready(function () {

    $("#Code").prop("disabled", true);

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

    var nameError = false;
    $('input[name="Name"]').keyup(function (e) {
        $("#Code").prop("disabled", false);
        var x = document.getElementById("NameError");
        $.ajax({
            url: "Category/UniqueName",
            type: "POST",
            data: $("#categoryForm").serialize(),
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            //data: "{'name': '" + $("#Name").val() + "','id': '" + $("#id").val() + "'}",
            dataFilter: function (response) {

                if (response === "True") {
                    nameError = true;
                    x.innerHTML = "Name already exist";
                    x.style.color = "red";

                } else {
                    nameError = false;
                    x.innerHTML = "";
                }

            }

        });

    });

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

   
    $("#saveButton").click(function () {
        if ($("#categoryForm").valid() && !nameError) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Category/Create",
                    data: $("#categoryForm").serialize()

            })
            .done(function (response) {
                if (response.Success) {
                    Swal.fire({
                        title: 'Saved SuccessFully',
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

    $("#closeButton").click(function() {
        window.location.reload();
    });

    $("#updateButton").click(function () {
        
        if ($("#categoryForm").valid() && !nameError) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Category/Edit",
                    data: $("#categoryForm").serialize()

            })
                .done(function (response) {
                    //document.getElementById("categoryForm").reset();
                    //$("#Name").val("");
                    //$("#categoryForm").reset();
                    //$("#categoryForm").trigger("reset"); 
                    
                    if (response.Success) {
                    Swal.fire({
                        title: 'Updated SuccessFully',
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
                        title: 'Updated SuccessFully',
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
});