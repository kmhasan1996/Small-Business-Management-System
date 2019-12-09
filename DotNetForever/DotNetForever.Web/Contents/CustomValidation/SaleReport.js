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

    var x = document.getElementById("startDateError");
    var y = document.getElementById("endDateError");
    var startDateError = false;
    var endDateError = false;

    $('input[name="startDate"]').change(function (e) {
        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        var startDate1 = new Date(startDate);
        var endDate1 = new Date(endDate);

        if (startDate1 > endDate1) {
            x.innerHTML = "Must be less than end date";
            x.style.color = "red";
            startDateError = true;

        } else {
            x.innerHTML = "";
            y.innerHTML = "";
            startDateError = false;
            endDateError = false;
        }

    });
    $('input[name="endDate"]').change(function (e) {
        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        var startDate1 = new Date(startDate);
        var endDate1 = new Date(endDate);

        if (endDate1 < startDate1) {
            y.innerHTML = "Must be greater than start date";
            y.style.color = "red";
            endDateError = true;

        } else {
            y.innerHTML = "";
            x.innerHTML = "";
            endDateError = false;
            startDateError = false;
        }

    });

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