$(document).ready(function (){
    //category changes
    $("#categoryId").on("change",
    function() {

        var categoryId = $('#categoryId').val();
        var jsonData = { categoryId: categoryId };


        $('#ProductId').empty();

        if (categoryId <= 0) {
            //alert("hi");
            var defaultValue = '<option value=0 > Select One</option>';
            $('#ProductId').append(defaultValue);
        }
        else {
            var defaultValue1 = '<option value=0 > Select One</option>';
            $('#ProductId').append(defaultValue1);
            $.ajax({
                type: "POST",
                url: "/Product/GetProductByCategoryId/",
                data: JSON.stringify(jsonData),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $.each(data, function (key, category) {
                        var optionText = "<option value='" + category.Id + "' >" + category.Name + "</option>";
                        $('#ProductId').append(optionText);
                    });
                }
            });
        }

    });

    function getTodayDate() {
        var date = new Date();
        var currentDate = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
        return currentDate;
    }


    //$("#startDate").val(getTodayDate());
    //$("#endDate").val(getTodayDate());

    // alert(getTodayDate());
    //$("#startDate").val(getTodayDate());
    //$("#endDate").val(getTodayDate());

    //$("#searchButton").click(function () {
    //    //document.getElementById("saveError").style.display = "none";
    //    alert("ds");
    //    $.ajax({
    //        type: "get",
    //        url: "/Stock/Search",
    //        data: $("#stockForm").serialize()

    //    })
    //    .done(function (response) {
    //        if (response) {
    //            $("list").html(response);
    //            swal({
    //                    title: "search Successfully",
    //                    //text: "Once deleted, you will not be able to recover this imaginary file!",
    //                    icon: "success",
    //                    buttons: true,
    //                    dangerMode: true

    //                })
    //                .then((willDelete) => {
    //                    if (willDelete) {
    //                        window.location.reload();
    //                    }
    //                });

    //        } else {

    //        }

    //    })
    //    .fail(function (XMLHttpRequest, textStatus, errorThrown) {
    //        alert("Fail");
    //    });

    //});

});