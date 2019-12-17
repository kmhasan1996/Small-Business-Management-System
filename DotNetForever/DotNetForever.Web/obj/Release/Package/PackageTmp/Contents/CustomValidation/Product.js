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

    $('input[name="ReorderLevel"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
    });

    var nameError = false;
    $('input[name="Name"]').keyup(function (e) {
      
        var x = document.getElementById("NameError");
        $.ajax({
            url: "Product/UniqueName",
            type: "POST",
            data: $("#productForm").serialize(),
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            //data: "{'Name': '" + $("#Name").val() + "'}",
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


   
    $("#productForm").validate({
        rules: {
            CategoryID: {
                required:true
            },
            //Code: {
            //    required: true,
            //    minlength:4,
            //    maxlength: 4
            //},
            Name: {
                required: true
                //remote:true
                //remote: 
                //        function() {

                //            return {
                //                url: "Product/UniqueName1",
                //                type: "POST",
                //                contentType: "application/json; charset=utf-8",
                //                dataType: "json",
                //                data: "{'Name': '" + $("#Name").val() + "'}",
                //                dataFilter: function(response) {
                //                    alert(response);
                //                    if (response == "True") {
                //                        alert("inside true");
                //                        return true;
                //                    } else {
                //                        alert("inside false");
                //                        return false;
                //                    }

                //                }

                //            }
                       
                //         }

            }, 
            ReorderLevel: {
                required: true
            },
            Description: {
                required: true
            }
        },
        messages: {
            CategoryID: {
                required: "Select a category"
            },
            Name: {
                required: "Name is required"
                //, remote:"Name is available"
            },
            ReorderLevel: {
                required: "Reorder level is required"
            },
            Description: {
                required: "Description is required"
            }
        }
    });


    $("#saveButton").click(function () {
      
        if ($("#productForm").valid() && !nameError) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Product/Create",
                    data: $("#productForm").serialize()

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

    $("#closeButton").click(function () {
        location.reload();
    });

    $("#updateButton").click(function () {
       
        if ($("#productForm").valid() && !nameError) {
            $("#Code").prop("disabled", false);
            $.ajax({
                    type: "POST",
                    url: "/Product/Edit",
                    data: $("#productForm").serialize()

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

});