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
    //$.ajax({
    //    type: "POST",
    //    url: "/Report/SearchPurchaseReport",
    //    data: $("#purchaseReportForm").serialize()

    //})
    //.done(function (response) {
    //    $("#showPurchaseReportListing").html(response);
    //})
    //.fail(function (XMLHttpRequest, textStatus, errorThrown) {
    //    alert("Fail");
    //});


    $("#searchButton").click(function () {
        $.ajax({
            type: "POST",
            url: "/Report/SearchPurchaseReport",
            data: $("#purchaseReportForm").serialize()

        })
        .done(function (response) {
            //$("#hideList").hide();
            $("#showPurchaseReportListing").html(response);
        })
        .fail(function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });


    });


})