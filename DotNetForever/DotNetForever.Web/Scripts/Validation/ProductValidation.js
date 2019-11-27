$(function () {


    $('input[name="Name"]').focusout(function () {
       
        var name = $('#Name').val();
        var jsonData = { name: name };

        $.ajax({
            type: "POST",
            url: "/Product/UniqueName/",
            data: JSON.stringify(jsonData),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data=="true") {
                    document.getElementById("NameError").innerHTML = "Name Exist !";
                    document.getElementById("NameError").style.color = "red";
                } else {
                    document.getElementById("NameError").innerHTML = "Name Available !";
                    document.getElementById("NameError").style.color = "green";
                }
            },
            error: function() {
                alert("Failed");
            }
        });

    });



    //alert("hi");
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

   
    //$("#productForm").validate({
    //    rules: {
    //        CategoryID: {
    //            required:true
    //        },
    //        Code: {
    //            required: true,
    //            minlength:4,
    //            maxlength: 4
    //        },
    //        Name: {
    //            required: true
    //            //remote:false
    //            //remote: function () {
                    
    //            //    return  {
    //            //        url: "Product/UniqueName1",
    //            //        type: "POST",
    //            //        contentType: "application/json; charset=utf-8",
    //            //        dataType: "json",
    //            //        data: "{'Name': '" + $("#Name").val() + "'}",
    //            //        dataFilter: function (response) {
    //            //            alert(response);
    //            //            if (response == "True") {
    //            //                alert("inside true");
    //            //                return true;
    //            //            } else {
    //            //                alert("inside false");
    //            //                return false;
    //            //            }

    //            //        }
                        
    //            //    }
    //            //}

    //        }, 
    //        ReorderLevel: {
    //            required: true
    //        },
    //        Description: {
    //            required: true
    //        }
    //    },
    //    messages: {
    //        CategoryID: {
    //            required: "Select a category"
    //        },
    //        Code: {
    //            required: "Code is required",
    //            minlength:"Minimum 4 character required",
    //            //minlength: jQuery.validator.format("At least {0} characters required!"),
    //            maxlength: "Maximum 4 character allowed"
    //        },
    //        Name: {
    //            required: "Name is required"
    //           //remote:"Name is required"
    //        },
    //        ReorderLevel: {
    //            required: "Reorder level is required"
    //        },
    //        Description: {
    //            required: "Description is required"
    //        }
    //    }
    //});




    //document.getElementById("saveError").style.display = "none";
    $("#saveButton").click(function () {

        //document.getElementById("saveError").style.display = "none";

        if ($("#productForm").valid()) {
            $.ajax({
                    type: "POST",
                    url: "/Product/Create",
                    data: $("#productForm").serialize()

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

    //$("#closeButton").click(function () {
    //    location.reload();
    //});


   
    $("#updateButton").click(function () {
        //document.getElementById("saveError").style.display = "none";
        if ($("#productForm").valid()) {
            $.ajax({
                    type: "POST",
                    url: "/Product/Edit",
                    data: $("#productForm").serialize()

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