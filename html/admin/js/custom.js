$(document).ready(function() {
    "use strict";
    $('.modal').modal({
        dismissible: true
    });
    
   
   
    //puscher
    toastr.options = {
        "timeOut": "5000",
        "progressBar": true,
        "onclick": function(e) { $('#noti').modal('open'); }
    }
    Pusher.logToConsole = true;

    var pusher = new Pusher('0c74ee77eb82bc0b814a', {
      cluster: 'ap3'
    });

    var channel = pusher.subscribe('anhlatuananh');
    channel.bind('Neworder', function(data) {
        toastr["info"](' <span>You have new order click this <br> dialog for detail</span>')
      var ht=' <a href="order-all.html" class="list-group-item list-group-item-action flex-column align-items-start ">\
      <div class="d-flex w-100 justify-content-between">\
          <h5 class="mb-1">You have new order</h5>\
          <small>Just now</small>\
      </div>\
      <p class="mb-1">Name :'+ data.message.Order_Name+' </p>\
      <p class="mb-1">Address :'+ data.message.Address+' </p>\
      <p class="mb-1">Phone :'+ data.message.Phone+' </p>\
      <small>Total : '+ data.message.total+'$</small>\
      </a>';
      $("#noti").append(ht)

    });


    $(".ho-dr-con-last.waves-effect").click(function(){
        localStorage.removeItem("token");
        window.location.reload()
    })
    //LEFT MOBILE MENU OPEN
    $(".atab-menu").on('click', function() {
        $(".sb2-1").css("left", "0");
        $(".btn-close-menu").css("display", "inline-block");
    });

    //LEFT MOBILE MENU CLOSE
    $(".btn-close-menu").on('click', function() {
        $(".sb2-1").css("left", "-350px");
        $(".btn-close-menu").css("display", "none");
    });

    //MATERIAL SELECT BOX
    $('select').material_select();

    //MATERIAL COLLAPSIBLE
    $('.collapsible').collapsible();

    //MATERIAL CHIP COMMON
    $('.chips').material_chip();
    $('.chips-initial').material_chip({
        data: [{
            tag: 'Apple',
        }, {
            tag: 'Microsoft',
        }, {
            tag: 'Google',
        }],
    });

    //MATERIAL CHIP PLACEHOLDER
    $('.chips-placeholder').material_chip({
        placeholder: 'Enter a tag',
        secondaryPlaceholder: '+Amini (press enter)',
    });

    //MATERIAL CHIP AUTO-COMPLETE
    $('.chips-autocomplete').material_chip({
        autocompleteOptions: {
            data: {
                'Apple': null,
                'Microsoft': null,
                'Google': null
            },
            limit: Infinity,
            minLength: 1
        }
    });

});


if(!localStorage.getItem("token"))
{
    window.location.href="login.html";
}
else
{
    $(".container-fluid.sb2 .sb2-12").find("img").attr("src",localStorage.getItem("admin_Image"));
    $(".top-user-pro").find("img").attr("src",localStorage.getItem("admin_Image"));
    $(".container-fluid.sb2").find("h5").html(localStorage.getItem("admin_Name")+"<span>"+localStorage.getItem("admin_type")+"</span>");
}
