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



function continue_order() {

   
}