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


    //for search and ajax search
    //var categoryId = $('#categoryId').val();
    //var productId = $('#ProductId').val();

    //var startDate = $("#startDate").val();
    //var endDate = $("#endDate").val();

    //var inProduct = false;
    //var outProduct = false;

    //if ($("#inCheckbox").is(":checked")) {
    //    inProduct = true;
    //}
    //if ($("#outCheckbox").is(":checked")) {
    //    outProduct = true;
    //}


    $("#searchButton").click(function () {

        var categoryId = $('#categoryId').val();
        var productId = $('#ProductId').val();

        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        var inProduct = false;
        var outProduct = false;

        if ($("#inCheckbox").is(":checked")) {
            inProduct = true;
        }
        if ($("#outCheckbox").is(":checked")) {
            outProduct = true;
        }

        var jsonData = { inProduct: inProduct, outProduct: outProduct, categoryId: categoryId, productId: productId, startDate: startDate, endDate: endDate };

        $.ajax({
            type: "POST",
            url: "/Stock/Search",
            data: JSON.stringify(jsonData),
            contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            //$("#hideList").hide();
            $("#showList").html(response);
        })
        .fail(function (xmlHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });

    });

    //$("#searchButton").click(function () {
    //    //document.getElementById("saveError").style.display = "none";
    //    $.ajax({
    //        type: "POST",
    //        url: "/Stock/Search",
    //        data: $("#stockForm").serialize()

    //    })
    //    .done(function (response) {
    //        //$("#hideList").hide();
    //        $("#showList").html(response);
    //    })
    //    .fail(function (xmlHttpRequest, textStatus, errorThrown) {
    //        alert("Fail");
    //    });

    //});


    $("#inCheckbox").click(function() {
        var categoryId = $('#categoryId').val();
        var productId = $('#ProductId').val();

        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        var searchVal = true;

        var inProduct = false;
        var outProduct = false;

        if ($("#inCheckbox").is(":checked")) {
            inProduct = true;
        }
        if ($("#outCheckbox").is(":checked")) {
            outProduct = true;
        }
       

        var jsonData = {inProduct: inProduct, outProduct: outProduct, categoryId: categoryId, productId: productId, startDate: startDate, endDate: endDate };


        $.ajax({
                type: "POST",
                url: "/Stock/Search",
                data: JSON.stringify(jsonData),
                contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            //$("#hideList").hide();
            $("#showList").html(response);
        })
        .fail(function (xmlHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });
    });

    $("#outCheckbox").click(function () {

        var categoryId = $('#categoryId').val();
        var productId = $('#ProductId').val();

        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        var searchVal = true;

        var inProduct = false;
        var outProduct = false;

        if ($("#inCheckbox").is(":checked")) {
            inProduct = true;
        }
        if ($("#outCheckbox").is(":checked")) {
            outProduct = true;
        }
       

        var jsonData = { inProduct: inProduct, outProduct: outProduct, categoryId: categoryId, productId: productId, startDate: startDate, endDate: endDate };


        $.ajax({
                type: "POST",
                url: "/Stock/Search",
                data: JSON.stringify(jsonData),
                contentType: "application/json; charset=utf-8"
        })
        .done(function (response) {
            //$("#hideList").hide();
            $("#showList").html(response);
        })
        .fail(function (xmlHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });
    });

    $("#categoryId").on("change",
        function () {

            var categoryId = $('#categoryId').val();
            var productId = $('#ProductId').val();

            var startDate = $("#startDate").val();
            var endDate = $("#endDate").val();

            var searchVal = true;

            var inProduct = false;
            var outProduct = false;

            if ($("#inCheckbox").is(":checked")) {
                inProduct = true;
            }
            if ($("#outCheckbox").is(":checked")) {
                outProduct = true;
            }


            var jsonData = { inProduct: inProduct, outProduct: outProduct, categoryId: categoryId, productId: productId, startDate: startDate, endDate: endDate };


            $.ajax({
                    type: "POST",
                    url: "/Stock/Search",
                    data: JSON.stringify(jsonData),
                    contentType: "application/json; charset=utf-8"
            })
            .done(function (response) {
                $("#showList").html(response);
            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });

        });

    $("#ProductId").on("change",
        function () {

            var categoryId = $('#categoryId').val();
            var productId = $('#ProductId').val();

            var startDate = $("#startDate").val();
            var endDate = $("#endDate").val();

            var searchVal = true;

            var inProduct = false;
            var outProduct = false;

            if ($("#inCheckbox").is(":checked")) {
                inProduct = true;
            }
            if ($("#outCheckbox").is(":checked")) {
                outProduct = true;
            }


            var jsonData = {inProduct: inProduct, outProduct: outProduct, categoryId: categoryId, productId: productId, startDate: startDate, endDate: endDate };


            $.ajax({
                    type: "POST",
                    url: "/Stock/Search",
                    data: JSON.stringify(jsonData),
                    contentType: "application/json; charset=utf-8"
            })
            .done(function (response) {
                $("#showList").html(response);
            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });

        });

});