var Cart = {};

Cart.on = function(eventName, callback) {
  if (!Cart.callbacks[eventName]) Cart.callbacks[eventName] = [];
  Cart.callbacks[eventName].push(callback);
  return Cart;
};

Cart.trigger = function(eventName, args) {
  if (Cart.callbacks[eventName]) {
    for (var i = 0; i<Cart.callbacks[eventName].length; i++) {
      Cart.callbacks[eventName][i](args||{});
    }
  }
  return Cart;
};

Cart.save = function() {
  localStorage.setItem('cart-items', JSON.stringify(Cart.items));
  Cart.trigger('saved');

  return Cart;
};

Cart.empty =  function() {
  Cart.items = [];
  Cart.trigger('emptied');
  Cart.save();
  

  return Cart;
};

Cart.indexOfItem = function(id) {
  for (var i = 0; i<Cart.items.length; i++) {
    if (Cart.items[i].id===id) return i;
  }
  return null;
};

Cart.removeEmptyLines = function() {
  newItems = [];
  for (var i = 0; i<Cart.items.length; i++) {
    if (Cart.items[i].quantity>0) newItems.push(Cart.items[i]);
  }
  Cart.items = newItems;
  return Cart;
};

Cart.addItem = function(item) {
  if (!item.quantity) item.quantity = 1;
  var index = Cart.indexOfItem(item.id);
  if (index===null) {
    Cart.items.push(item);
  } else {
    Cart.items[index]. quantity += item.quantity;
  }
  Cart.removeEmptyLines();
  if (item.quantity > 0) {
    Cart.trigger('added', {item: item});
  } else {
    Cart.trigger('removed', {item: item});
  }

  Cart.save();


  return Cart;
};

Cart.itemsCount = function() {
  var accumulator = 0;
  for (var i = 0; i<Cart.items.length; i++) {
    accumulator += Cart.items[i].quantity;
  }
  return accumulator;
};

Cart.currency = '$';

Cart.displayPrice = function(price) {
  if (price===0) return 'Free';
  // var floatPrice = price/100;
  // var decimals = floatPrice==parseInt(floatPrice, 10) ? 0 : 2;
 
  return   price +" "+Cart.currency;
};

Cart.linePrice = function(index) {
  return Cart.items[index].price * Cart.items[index].quantity;
};

Cart.subTotal = function() {
  var accumulator = 0;
  for (var i = 0; i<Cart.items.length; i++) {
    accumulator += Cart.linePrice(i);
  }
  return accumulator;
};

Cart.init = function() {
  var items = localStorage.getItem('cart-items');
  if (items) {
    Cart.items = JSON.parse(items);
  } else {
    Cart.items = [];
  }
  Cart.callbacks = {};
  return Cart;
}

Cart.initJQuery = function() {

  Cart.init();

  Cart.templateCompiler = function(a,b){return function(c,d){return a.replace(/#{([^}]*)}/g,function(a,e){return Function("x","with(x)return "+e).call(c,d||b||{})})}};

  console.log(this)
     
      var h ='	<tbody>\
      <tr>\
        <td>\
          <div class="row align-items-center">\
            <div class="col-3 pr-0">\
               <img style="    max-width: 100px;" src="#{this.image}" alt="..."/>\
            </div>\
            <div class="col-9 pl-1">\
              <h4>#{this.label}</h4>\
            </div>\
          </div>\
        </td>\
        <td> \
          <span class="cartprice">#{Cart.displayPrice(this.price)}</span> \
        </td>\
        <td>								\
        <div class="counteritem">\
          <a href="#" class="sc-minus">-</a>\
            <input type="text" value="#{this.quantity}">\
          <a href="#" class="sc-plus">+</a>\
        </div>\
        </td>\
        <td>\
          <span class="cartprice2">$#{Cart.linePrice(Cart.indexOfItem(this.id))}</span>\
        </td>\
        <td class="text-right">\
          <button><img src="images/close2.png" alt="close"/></button>								\
        </td>\
      </tr>				  \
    </tbody>'
      Cart.lineItemTemplate = h;

  
  $(document).on('click', '.cart-add', function(e) {
    e.preventDefault();
    var button = $(this);
    var item = {
      id: button.data('id'),
      price: button.data('price'),
      quantity: button.data('quantity'),
      label: button.data('label'),
      image: button.data('image')
    }
    Cart.addItem(item);
  });

  var updateReport = function() {
    var count = Cart.itemsCount();
    $('.cart-items-count').text(count);
    $('.cart-subtotal_l').html(Cart.displayPrice(Cart.subTotal()));
    if (count===1) {
      $('.cart-items-count-singular').show();
      $('.cart-items-count-plural').hide();
    } else {
      $('.cart-items-count-singular').hide();
      $('.cart-items-count-plural').show();
    }
  };

  var updateCart = function() {
    if (Cart.items.length>0) {
      var template = Cart.templateCompiler(Cart.lineItemTemplate);
      var lineItems = "";
      for (var i = 0; i<Cart.items.length; i++) {
        lineItems += template(Cart.items[i]);
      }
      $('.cart-line-items').html($('.cart-line-items').html()+lineItems);
      $('.cart-table').show();
      $('.cart-is-empty').hide();
    } else {
      $('.cart-table').hide();
      $('.cart-is-empty').show();
    }
  };

  var update = function() {
    updateReport();
    updateCart();
  };
  update();

  Cart.on('saved', update);

  return Cart;
};

Cart.checkout =function()
{
  if(Cart.items.length!=0)
  {
      
      var $adr=$("#adresst").val();
      var phone=$("#phone").val();
      var name=$("#name").val();
      if($adr.trim()==""||phone.trim()==""||name.trim()=="")
      {
        toastr.error("vui lòng nhập đầy đủ thông tin")
      }
      else{
        var data={
        "Address":$adr,
        "Phone":phone,
        "Order_Name":name,
        "total":Cart.subTotal()
        }
        console.log(data);
        $.ajax({
          type: "POST",
          url: "https://localhost:5001/user/create-order",
          data: data,
          dataType: "json",
          success: function(data)
          { 
            var model=[];
            Cart.items.forEach(element => {
              model.push(element)
            });
            console.log(JSON.stringify(model))
            $.ajax({
              type: "POST",
              url: "https://localhost:5001/user/order-detail-insert",
              data: JSON.stringify(model),
              dataType: "json",
              contentType: 'application/json; charset=utf-8',
              success: function(data)
              { 
                  Cart.empty();
                  window.location.href="index.html";
              },
              error : function (e){      
                  console.log(e)
              
              }
              })

              // Cart.empty();
              // window.location.href="/index.html";
          },
          error : function (e){      
              console.log(e)
          
          }
      })

      }
  }
  else
  {
    toastr.error("Giỏ hàng của bạn trống");
  }
  
}
