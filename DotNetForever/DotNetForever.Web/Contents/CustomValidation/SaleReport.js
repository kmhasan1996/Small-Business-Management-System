$(document).ready(function() {

    //get current date
    function getTodayDate() {
        var date = new Date();
        var currentDate = (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear();
        return currentDate;
    }

    $("#startDate").datepicker();
    $("#startDate").val(getTodayDate());

    $("#endDate").datepicker();
    $("#endDate").val(getTodayDate());

    //default load the data on page load 
    $.ajax({
        type: "POST",
        url: "/Report/SearchSaleReport",
        data: $("#saleReportForm").serialize()

    })
    .done(function (response) {
        $("#ShowSaleReportListing").html(response);
    })
    .fail(function (XMLHttpRequest, textStatus, errorThrown) {
        alert("Fail");
    });


    $("#searchButton").click(function () {
        $.ajax({
            type: "POST",
            url: "/Report/SearchSaleReport",
            data: $("#saleReportForm").serialize()

        })
        .done(function (response) {
            //$("#hideList").hide();
            $("#ShowSaleReportListing").html(response);
        })
        .fail(function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });


    });


})