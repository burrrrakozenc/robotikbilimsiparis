function getProduct(id) {
    var rows = '';
    
    $.get('/Order/GetProductList/' + id, function (data) {
        for (let prop of data) {
            debugger
            rows += '<tr><td>' + prop['ProductName'] + '</td><td>' + prop['Quantity'] + '</td><td>' + prop['SubTotal'] + '</td></tr>';
        } 
        document.getElementById("tableBody").innerHTML = rows;
        $('#getProductModal').modal();
    })

}

$(".orderDateForm").submit(function () {
    debugger
    var orderDateForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/GetDate/", // Controller/View
            dataType: 'json',
            data: orderDateForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".shipmentForm").submit(function () {
    debugger
    var shipmentForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/GetShipmentNo/", // Controller/View
            dataType: 'json',
            data: shipmentForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".basketForm").submit(function (e) {
    debugger
    var basketForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Product/AddToBasket/", // Controller/View
            dataType: 'json',
            data: basketForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});


$(".placeOrder").submit(function (e) {
    debugger
    var placeOrder = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Basket/OrderSend/", // Controller/View
            dataType: 'json',
            data: placeOrder.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});



$(".orderUserSubmit").submit(function (e) {
    debugger
    var orderUserSubmit = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/OrderUserSubmit/", // Controller/View
            dataType: 'json',
            data: orderUserSubmit.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});


$(".orderDeliveryArrived").submit(function (e) {
    debugger
    var orderDeliveryArrived = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/OrderDeliveryReceived/", // Controller/View
            dataType: 'json',
            data: orderDeliveryArrived.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".paymentReceived").submit(function (e) {
    debugger
    var paymentReceived = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/PaymentReceived/", // Controller/View
            dataType: 'json',
            data: paymentReceived.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".accountantStatusForm").submit(function (e) {
    debugger
    var accountantStatusForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/GetOrderListAccountant/", // Controller/View
            dataType: 'json',
            data: accountantStatusForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".storageStatusForm").submit(function (e) {
    debugger
    var storageStatusForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/OrderListStorage/", // Controller/View
            dataType: 'json',
            data: storageStatusForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".shipmentStatusForm").submit(function (e) {
    debugger
    var shipmentStatusForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/OrderListShipment/", // Controller/View
            dataType: 'json',
            data: shipmentStatusForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".basketDeleteForm").submit(function (e) {
    debugger
    var basketDeleteForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Basket/BasketProductDelete/", // Controller/View
            dataType: 'json',
            data: basketDeleteForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});

$(".orderDeleteForm").submit(function (e) {
    debugger
    var orderDeleteForm = $(this);
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "/Order/OrderDelete/", // Controller/View
            dataType: 'json',
            data: orderDeleteForm.serialize(),
            success: function (data) {
                alert("successfully inserted");
            },

            failure: function () {
                alert("not successfull");
            }

        });
});


//function deleteOrderFunction() {
//    debugger
//    var OrderID = $("#OrderID").val();
//    $.ajax({
//        type: 'POST',
//        dataType: 'json',
//        url: '/Order/OrderDelete',
//        data: JSON.stringify({ OrderID: OrderID}), //ProductID: ProductID,
//        contentType: 'application/json',
//        success: function (data) {
//            $(document).ajaxStop(function () {
//                setInterval(function () {
//                    location.reload();
//                }, 100);
//            });
//        }
//    })
//}

//function getDate(id) {
//    $.get('/Order/GetDate/' + id, function (data) {
//        $('#getDateOrderModal').modal();
//    }) 
//}

//$(".sendOrderModal").submit(function (e) {
//    debugger
//    var sendOrderModal = $(this);
//    $('#kt_datepicker_modal').modal('show');
//});

//function deliveryDate() {
//    debugger
//    var OrderID = $("#OrderID").val();
//    var date = $("#date").val();
//    $.ajax({
//        type: 'POST',
//        dataType: 'json',
//        url: '/Order/DeliveryAdd',
//        data: JSON.stringify({ OrderID: OrderID, date:date}), //ProductID: ProductID,
//        contentType: 'application/json',
//        success: function (data) {
//            $(document).ajaxStop(function () {
//                setInterval(function () {
//                    location.reload();
//                }, 100);
//            });
//        }
//    })
//}


//$(document).ready(function () {
//    var date_input = $('input[name="date"]'); //our date input has the name "date"
//    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
//    date_input.datepicker({
//        format: 'mm/dd/yyyy',
//        container: container,
//        todayHighlight: true,
//        autoclose: true,
//    })
//})

//$("#datepicker").datepicker({

//    onSelect: function (date, OrderID) {

//        $.ajax
//            ({
//                type: "Post",
//                url: '/Order/DeliveryAdd',
//                data: {[date:date, OrderID:Order]},
//                success: function (result) {
//                    alert(result);
//                }
//            });
//    }
//});

