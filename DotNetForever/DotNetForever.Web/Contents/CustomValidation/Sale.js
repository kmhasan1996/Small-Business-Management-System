$(function() {

//customer change
    $("#customerId").on("change",
        function() {
            var customerId = $("#customerId").val();
            var jsonData = { customerId: customerId };

            if (parseInt(customerId) > 0) {
                $.ajax({
                    type: "POST",
                    url: "/Customer/GetLoyaltyPointById",
                    data: JSON.stringify(jsonData),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(response) {

                        if (response != null) {
                            //set the values to input field by id
                            $("#loyaltyPoint").val(response.loyaltyPoint);

                        }
                    }
                });
            } else {
                $("#loyaltyPoint").val("0");
            }

        });

    $("#saleForm").validate({
        rules: {
            customerId: {
                required: true
            } ,
            categoryId: {
                required: true
            },
            productId: {
                required: true
            },
            quantity: {
                required: true
            },
            mrp: {
                required: true
            }
        },
        messages: {
            customerId: {
                required: "Select a Customer"
            },
            categoryId: {
                required: "Select a category"
            },
            productId: {
                required: "Select a product"
            },
            quantity: {
                required: "Quantity is required"
            },
            mrp: {
                required: "MRP is required"
            }
        }
    });


    //category changes
    $("#categoryId").on("change",
        function () {

            var categoryId = $("#categoryId").val();
            if (categoryId<=0) {
                $("#availableQty").val("");
                $("#quantity").val("");
                $("#mrp").val("");
                $("#totalPrice").val("");
            }


            //var val = $("#customerId").val();
            //alert(val);

            if ($("#customerId").valid() /*&& val !== ""*/) {

                $("#dateTime").prop("disabled", true);
                $("#Code").prop("disabled", true);
                $("#customerId").prop("disabled", true);

                var jsonData = { categoryId: categoryId };


                $("#productId").empty();

                if (categoryId <= 0) {
                    //alert("hi");
                    var defaultValue = '<option value=0 > Select One</option>';
                    $("#productId").append(defaultValue);
                } else {
                    var defaultValue1 = '<option value=0 > Select One</option>';
                    $("#productId").append(defaultValue1);
                    $.ajax({
                        type: "POST",
                        url: "/Product/GetProductByCategoryId/",
                        data: JSON.stringify(jsonData),
                        //data: {
                        //    categoryId:$("#categoryId").val()
                        //} ,
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            $.each(data,
                                function (key, category) {
                                    var optionText = "<option value='" + category.Id + "' >" + category.Name + "</option>";
                                    $("#productId").append(optionText);
                                });
                        }
                    });
                }
            } else {
                $("#categoryId").val("");
                
            }
            

        });


    var reorderLevel;
//product changes
    $("#productId").on("change",
        function() {

            //clear the field
            $("#quantity").val("");
            $("#totalPrice").val("");

            //get the sending data
            var dateTime = $("#dateTime").val();
            var productId = $("#productId").val();

            //alert(dateTime);

            //if (dateTime == "") {
            //    dateTime = getTodayDate();
            //}

            //alert(dateTime);

            var jsonData = { productId: productId, saleDateTime: dateTime };

            $.ajax({
                type: "POST",
                url: "/Sale/GetAvailableProductQtyByIdAndDate",
                data: JSON.stringify(jsonData),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response) {

                    if (response != null) {
                        //set the values to input field by id
                        $("#availableQty").val(response.availableProduct);
                        $("#mrp").val(response.currentMRP);
                        reorderLevel = response.reorderLevel;
                    }

                }
            });

        });


    $('input[name="quantity"]').keyup(function(e) {

        //alert(reorderLevel);

        //input field accept numeric value
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
        var sellQty = $("#quantity").val();

        var availableQty = $("#availableQty").val();

        var afterSellAvailableQty = availableQty - sellQty;

        if (parseInt(availableQty) < parseInt(sellQty)) {
            swal({
                    title: "Quantity not available",
                    text: "Please, enter less than available quantity ! ",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true

                })
                .then((willDelete) => {
                    $("#quantity").val("");
                    //var sellQty1 = $('#quantity').val();
                    //alert(sellQty1);
                });
        }
        //alert(rr);
        //if (parseInt(reorderLevel) > parseInt(afterSellAvailableQty)) {
        //    swal({
        //            title: "Reorder level reached ",
        //            html: "Please, purchase product ! " +
        //                "<br/>Reorder Level " +
        //                reorderLevel +
        //                "<br/> After Sold Available Quantity will be " +
        //                afterSellAvailableQty,
        //            icon: "warning",
        //            buttons: true,
        //            dangerMode: true

        //    })
        //    .then((willDelete) => {

        //    });
        //}


        var unitPrice = $('#mrp').val();
        $('#totalPrice').val(sellQty * unitPrice);
    });

    $('input[name="mrp"]').keyup(function(e) {

        //input field accept numeric value
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }

        var sellQty = $('#quantity').val();
        var unitPrice = $('#mrp').val();

        var totalPrice = sellQty * unitPrice;

        $('#totalPrice').val(totalPrice);

        $('#grandTotal').val(totalPrice);
        $('#discount').val("hi");
    });


//Product List Table 

    var index = 0;

    var grandTotalTk = parseInt(0);

    $("#addButton").click(function() {
        //$("#saleForm").validate().element($("#customerId"));

        if ($("#saleForm").valid()) {


            //grand total calculation

            var totalPrice = $("#totalPrice").val();
            grandTotalTk = grandTotalTk + parseInt(totalPrice);
            $("#grandTotal").val(grandTotalTk);

            var loyaltyPoint = $("#loyaltyPoint").val();

            var discountPercentage = parseInt(loyaltyPoint) / 10;

            $("#discountPercentage").val(discountPercentage);

            var discountAmount = parseInt(grandTotalTk) * parseInt(discountPercentage) / 100;
            $("#discountAmount").val(discountAmount);

            $("#payableAmount").val(parseInt(grandTotalTk) - parseInt(discountAmount));

            
            //enable the submit button
            $("#submitButton").prop("disabled", false);

            var result = getResultData();

            var resultRow = gerResultRow(result);

            $("#ProductListTable").append(resultRow);
            index++;


            //set default the product details field
            $("#categoryId").val("");

            $("#productId").empty();
            $("#productId").append('<option value=0 > Select One</option>');

            $("#availableQty").val("");
            $("#quantity").val("");
            $("#mrp").val("");
            $("#totalPrice").val("");
        }

    });
//initially disable the submit button
    if (index <= 0) {
        $("#submitButton").prop("disabled", true);
    }

    function getResultData() {
        var productId = $("#productId").val();
        var productName = $("#productId  option:selected").text();
        var quantity = $("#quantity").val();
        var mrp = $("#mrp").val();
        var totalPrice = $("#totalPrice").val();

        return { ProductId: productId, ProductName: productName, Quantity: quantity, MRP: mrp, TotalPrice: totalPrice }
    }

    var sl = index;

    function gerResultRow(result) {
        var productIdHidden = "<input type='hidden' name='SaleDetails[" +
            index +
            "].ProductId' value='" +
            result.ProductId +
            "'></div>";
        //var productNameHidden = "<input type='hidden' name='PurchaseDetails[" + index + "].ProductName' value='" + result.ProductName + "'></div>";
        var quantityHidden = "<input type='hidden' name='SaleDetails[" +
            index +
            "].Quantity' value='" +
            result.Quantity +
            "'></div>";
        var mrpHidden = "<input type='hidden' name='SaleDetails[" + index + "].MRP' value='" + result.MRP + "'></div>";
        var totalPriceHidden = "<input type='hidden' name='SaleDetails[" +
            index +
            "].TotalPrice' value='" +
            result.TotalPrice +
            "'></div>";

        //var grandTotal = grandTotal + result.TotalPrice;

        var startTr = "<tr>";
        var slCell = "<td class='text-success'>" + (++sl) + "</td>";

        var productIdCell = productIdHidden;
        var productNameCell = "<td class='text-success'>" + result.ProductName + "</td>";
        var quantityCell = "<td class='text-success'>" + quantityHidden + result.Quantity + "</td>";
        var mrpCell = "<td class='text-success'>" + mrpHidden + result.MRP + "</td>";
        var totalPriceCell = "<td class='text-success'>" + totalPriceHidden + result.TotalPrice + "</td>";

        var endTr = "</tr>";

        return (startTr + slCell + productIdCell + productNameCell + quantityCell + mrpCell + totalPriceCell + endTr);

    }


    var saleDetails = $("#SaleDetails[2]").val();

    $("#submitButton").click(function() {

        $("#dateTime").prop("disabled", false);
        $("#Code").prop("disabled", false);
        $("#customerId").prop("disabled", false);

        //if ($("#PurchaseForm").valid()) {
        $.ajax({
                type: "POST",
                url: "/Sale/Create",
                data: $("#saleForm").serialize()

            })
            .done(function(response) {
                //if (response.Success) {
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

                //} else {
                //    alert("failed");
                //}

            })
            .fail(function(XMLHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });
        //};

    });
});