/******************
In Number - Quantity Style - 1
*******************/
function increaseValue() {
  var value = parseInt(document.getElementById('number').value, 10);
  value = isNaN(value) ? 0 : value;
  value++;
  document.getElementById('number').value = value;
}

function decreaseValue() {
  var value = parseInt(document.getElementById('number').value, 10);
  value = isNaN(value) ? 0 : value;
  value < 1 ? value = 1 : '';
  value--;
  document.getElementById('number').value = value;
}


/******************
In Number - Quantity - Modal
*******************/
function increaseValueModal() {
  var value = parseInt(document.getElementById('modal-number').value, 10);
  value = isNaN(value) ? 0 : value;
  value++;
  document.getElementById('modal-number').value = value;
}

function decreaseValueModal() {
  var value = parseInt(document.getElementById('modal-number').value, 10);
  value = isNaN(value) ? 0 : value;
  value < 1 ? value = 1 : '';
  value--;
  document.getElementById('modal-number').value = value;
}

/******************
In Number - Quantity Style -2
*******************/
jQuery('<div class="quantity-nav"><div class="quantity-button quantity-up"><i class="fal fa-plus"></i></div><div class="quantity-button quantity-down"><i class="fal fa-minus"></i></i></div></div>').insertAfter('.quantity input');
jQuery('.quantity').each(function() {
var spinner = jQuery(this),
   input = spinner.find('input[type="number"]'),
   btnUp = spinner.find('.quantity-up'),
   btnDown = spinner.find('.quantity-down'),
   min = input.attr('min'),
   max = input.attr('max');

btnUp.click(function() {
   var oldValue = parseFloat(input.val());
   if (oldValue >= max) {
   var newVal = oldValue;
   } else {
   var newVal = oldValue + 1;
   }
   spinner.find("input").val(newVal);
   spinner.find("input").trigger("change");
});

btnDown.click(function() {
   var oldValue = parseFloat(input.val());
   if (oldValue <= min) {
   var newVal = oldValue;
   } else {
   var newVal = oldValue - 1;
   }
   spinner.find("input").val(newVal);
   spinner.find("input").trigger("change");
});

});
