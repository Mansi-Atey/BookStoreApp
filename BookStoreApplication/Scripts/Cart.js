

function increment() {
    document.getElementById('demoInput').stepUp();
}
function decrement() {
    document.getElementById('demoInput').stepDown();
}

function RemoveCart(CartId) {
    var removeFromCart = "remove-".concat(CartId);
    var requestObject = {};
    requestObject.CartId = CartId;
    //var cartId = parseInt(CartId);
    console.log(JSON.stringify(requestObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44314/Cart/DeleteCartByCartId',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success:
            function () {
                //Onclick REMOVE button hide AddToCart button
                var RemoveButton = document.getElementById('placeid');
                RemoveButton.style.display = "none";
                window.location.reload();
            },
        error: function () {
            alert("Error while removing data");
        }
    });
}

function place_order() {
    getCustomers();
    var place_order = document.getElementById('placeid');
    place_order.style.display = "none";
     
    var form_name = document.getElementById('form-div-cart');
    form_name.style.display = "block";
}


var customerlist;
function getCustomers() {
    var customers = {};
    var UserId = 1;
    //int userId = ;
    //console.log(JSON.stringify(customers));
    $.ajax({
        type: "GET",
        url: 'https://localhost:44314/CustomerDetails/GetAllCustomerDetails?UserId=1',
        //  data: userId,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            console.log("response=" + response);
            customerlist = response.Data;
            // continue_order()
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}

function continue_order() {
    getCustomers()
    var isPresent = false;
    var customersObject = {};
    var getSelectedValue = document.querySelector('input[name="type"]:checked').value;

    customersObject.Name = $("#txtName").val();
    customersObject.PhoneNumber = $("#intNum").val();
    customersObject.Pincode = $("#intPin").val();
    customersObject.Locality = $("#txtLocal").val();
    customersObject.Address = $("#txtAddress").val();
    customersObject.City = $("#txtCity").val();
    customersObject.Landmark = $("#txtLand").val();
    customersObject.type = getSelectedValue;

    for (i = 0; i < customerlist.length; i++) {
        if (customerlist[i].Name == customersObject.Name && customerlist[i].PhoneNumber == customersObject.PhoneNumber) {
            isPresent = true;
            customersObject.CustomerId = customerlist[i].CustomerId;
        }
    }


    if (isPresent === false) {
        $.ajax({
            type: "POST",
            url: 'https://localhost:44314/CustomerDetails/AddCustomerDetails',
            data: JSON.stringify(customersObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                document.getElementById("cont-id").style.display = "none";
                document.getElementById('oder-details').style.display = "block";
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    } else {
        $.ajax({
            type: "POST",
            url: 'https://localhost:44314/CustomerDetails/UpdateCustomerDetails',
            data: JSON.stringify(customersObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                var place_order = document.getElementById('cont-id');
                place_order.style.display = "none";
                var Order_details = document.getElementById('oder-details');
                Order_details.style.display = "block";
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    }
}




//var customerlist;
//function getCustomers() {
//    var customers = {};
//    var userId = 1;
//    //int userId = ;
//    //console.log(JSON.stringify(customers));
//    $.ajax({
//        type: "GET",
//        url: 'https://localhost:44314/CustomerDetails/GetAllCustomerDetails?UserId=1',
//        //  data: userId,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            console.log("response=" + response);
//            customerlist = response.Data;
//           // continue_order()
//        },
//        error: function () {
//            alert("Error while inserting data");
//        }
//    });
//}

