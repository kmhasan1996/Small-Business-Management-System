$(document).ready(function (){


    function getTodayDate() {
        var date = new Date();
        var currentDate = (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear();
        return currentDate;
    }

    $("#startDate").datepicker();
    $("#startDate").val(getTodayDate());

    $("#endDate").datepicker();
    $("#endDate").val(getTodayDate());

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




    $("#searchButton").click(function () {
        //document.getElementById("saveError").style.display = "none";
        $.ajax({
            type: "POST",
            url: "/Stock/Search",
            data: $("#stockForm").serialize()

        })
        .done(function (response) {
            //$("#hideList").hide();
            $("#showList").html(response);
        })
        .fail(function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });


    });


    $("#categoryId").on("change",
        function () {

            $.ajax({
                type: "POST",
                url: "/Stock/Search",
                data: $("#stockForm").serialize()

            })
                .done(function (response) {
                    $("#showList").html(response);
                })
                .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Fail");
                });

        });

    $("#ProductId").on("change",
        function () {

            $.ajax({
                    type: "POST",
                    url: "/Stock/Search",
                    data: $("#stockForm").serialize()

                })
                .done(function (response) {
                    $("#showList").html(response);
                })
                .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Fail");
                });

        });

});