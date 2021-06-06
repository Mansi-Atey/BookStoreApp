const { intl } = require("modernizr");

function increment() {
    document.getElementById('demoInput').stepUp();
}
function decrement() {
    document.getElementById('demoInput').stepDown();
}

function place_order() {
    var place_order = document.getElementById('placeid');
    place_order.style.display = "none";
     
    var form_name = document.getElementById('form-div-cart');
    form_name.style.display = "block";
}


function RemoveCart(CartId) {
    var removeFromCart = "remove-".concat(CartId);
    var requestObject = {};
    requestObject.CartId = CartId;

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

            },
        error: function () {
            alert("Error while removing data");
        }
    });
}


function continue_order() {

    var getSelectedValue = document.querySelector('input[name="type"]:checked');

    var customersObject = {};
    customersObject.Name = $("#txtName").val();
    customersObject.PhoneNumber = $("#intNum").val();
    customersObject.Pincode = $("#intPin").val();
    customersObject.Locality = $("#txtLocal").val();
    customersObject.Address = $("#txtAddress").val();
    customersObject.City = $("#txtCity").val();
    customersObject.Landmark = $("#txtLand").val();
    customersObject.type = getSelectedValue.value;

    console.log(JSON.stringify(customersObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44314/CustomerDetails/AddCustomerDetails',
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