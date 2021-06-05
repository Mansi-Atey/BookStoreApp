function AddToCart(bookID) {

    var addToCartId = "cartBtn-".concat(bookID);
    var addToWishId = "wishBtn-".concat(bookID);
    var addedToCart = "addedCartBtn-".concat(bookID);

    var requestObject = {};
    requestObject.UserId = 1;
    requestObject.BookID = bookID;
    requestObject.TotalQuantity = 1;
    console.log(JSON.stringify(requestObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44314/Cart/AddToCart',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            //Onclick AddToCart button hide AddToCart button
            var AddToCartButton = document.getElementById(addToCartId);
            AddToCartButton.style.display = "none";

            //Onclick AddToCart button hide WishList button
            var AddToWishListButton = document.getElementById(addToWishId);
            AddToWishListButton.style.display = "none";

            //Onclick AddToCart button show AddedToCart button
            var AddedToCartButton = document.getElementById(addedToCart);
            AddedToCartButton.style.display = "block"
            // alert("Data has been added successfully.");  
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}

function AddToWishList(bookID) {

    var addToCartId = "cartBtn-".concat(bookID);
    var addToWishId = "wishBtn-".concat(bookID);
    var addedToWishlist = "addedWishBtn-".concat(bookID);

    var requestObject = {};
    requestObject.UserId = 1;
    requestObject.BookID = bookID;
    requestObject.TotalQuantity = 1;
    console.log(JSON.stringify(requestObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44314/Cart/AddToCart',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            //Onclick AddToWishlist button hide AddToCart button
            var AddToWishButton = document.getElementById(addToWishId);
            AddToWishButton.style.display = "none";

            //Onclick AddToWishlist button hide WishList button
            var AddToCartButton = document.getElementById(addToCartId);
            AddToCartButton.style.display = "none";

            //Onclick AddToWishlist button show Wishlisted button
            var AddedToWishButton = document.getElementById(addedToWishlist);
            AddedToWishButton.style.display = "block"
            // alert("Data has been added successfully.");  

        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}

