(function($) {
"use strict";

//testimonials
$('.owl-carousel').owlCarousel({
    loop:true,
    nav: false,
    dots: true,
    dotsEach: 1,
    responsive:{
        0:{
            items:1
        },
        767:{
            items:2
        },
        1000:{
            items:3
        }
    }
})


// menu1 Isotope
$(document).ready(function() {
  var $grida = $('.grid').imagesLoaded( function() {
  var $grid = $('.grid').isotope({
    itemSelector: '.element-item',
    layoutMode: 'fitRows',
    getSortData: {
      price: '.price parseInt',
    }
  });   
  $('#price-sort').on( 'change', function() {
    var type = $(this).find(':selected').attr('data-sorttype');
    console.log(type);
    var sortValue = this.value;
      if(type=='as'){$grid.isotope({ sortBy: sortValue , sortAscending: false});}
      else{$grid.isotope({ sortBy: sortValue , sortAscending: true});}
      $grid.isotope({ sortBy: sortValue });
    });
    $('#price-sort').on( 'change', function() {
      var type = $(this).find(':selected').attr('data-sorttype');
      console.log(type);
      var sortValue2 = this.value;
      if(type=='ra'){$grid.isotope({ sortBy: 'original-order'});}
      else{}
      $grid.isotope({ sortBy: sortValue });
    });
})
});

//toggle button
$(document).ready(function () {
  $('.first-button').on('click', function () {
    $('.animated-icon1').toggleClass('open');
  });
});


// menu2 Isotope
$(document).ready(function() {
  var $gridb = $('.grid').imagesLoaded( function() {
  var $grid = $('.grid2').isotope({
    itemSelector: '.element-item',
    layoutMode: 'fitRows',
    getSortData: {
      price: '.price parseInt',
    }
  });   
  $('#price-sort2').on( 'change', function() {
    var type = $(this).find(':selected').attr('data-sorttype');
    console.log(type);
    var sortValue = this.value;
      if(type=='as'){$grid.isotope({ sortBy: sortValue , sortAscending: false});}
      else{$grid.isotope({ sortBy: sortValue , sortAscending: true});}
      $grid.isotope({ sortBy: sortValue });
    });   
     $('#price-sort2').on( 'change', function() {
      var type = $(this).find(':selected').attr('data-sorttype');
      console.log(type);
      var sortValue2 = this.value;
      if(type=='ra'){$grid.isotope({ sortBy: 'original-order'});}
      else{}
      $grid.isotope({ sortBy: sortValue });
    });
})
});


//scroll to top button
$(document).ready(function() {
$(window).scroll(function() {
if ($(this).scrollTop() > 400) {
$('#toTopBtn').fadeIn();
} else {
$('#toTopBtn').fadeOut();
}
});
$('#toTopBtn').click(function() {
$("html, body").animate({
scrollTop: 0
}, 1000);
return false;
});
});

// load more
   $('#loadMore').simpleLoadMore({
      item: '.item',
      count: 6,
      counterInBtn: false,
      btnText: 'Load more',
      btnHTML: '<div class="col-12 text-center mb-2"><a href="#" class="custom-button3">Load more</a></div>'
    });

    // shopping card plus and minus
    $('a.sc-minus').on('click', function(e) {
      e.preventDefault();
      var $this = $(this);
      var $input = $this.closest('div').find('input');
      var value = parseInt($input.val());   
        if (value > 1) {
            value = value - 1;
        } else {
            value = 0;
        }    
    $input.val(value);
        
    });    
    $('a.sc-plus').on('click', function(e) {
      e.preventDefault();
      var $this = $(this);
      var $input = $this.closest('div').find('input');
      var value = parseInt($input.val());
        if (value < 100) {
        value = value + 1;
        } else {
            value =100;
        }
        $input.val(value);
    });
  $('table input').on('blur', function(){

    var input = $(this);
    var value = parseInt($(this).val());

        if (value < 0 || isNaN(value)) {
            input.val(0);
        } else if
            (value > 100) {
            input.val(100);
        }
});

//hamburger nav
$(document).ready(function(){
  $('.nav-button').click(function(){
	$('body').toggleClass('nav-open');
  });
});

// flexslider for product page
$(document).ready(function(){
$('.flexslider1').flexslider({
  animation: 'slide',
  controlNav: 'thumbnails'
});
});

// animate
const josh = new Josh();


})(jQuery);


Cart.initJQuery();



// $.ajax({
//   type: "get",  
//   url: "https://localhost:5001/Categories/get-Category",


//   success: function(data)
//   {   
//     var html="";
//   console.log(data)
//     for(var i=1;i<data.length+1;i++)
//     {   
//       if(data[i-1].parentid==0)
//       {
//         html+=' <li><a class="dropdown-item" ">'+data[i-1].category_Name+'</a></li>';
//       }
//       else
//       {
//          html+=' <li><a class="dropdown-item" href="type.html?id='+data[i-1].category_ID+'">---'+data[i-1].category_Name+'</a></li>';
//       }
     
//     }
    
//     $("#type").html(html);
//   },
//   error : function (e){      
//     console.log(e)
  
//   }
// })




var dd="";
var html="";
    $.ajax({
    type: "get",  
    url: "https://localhost:5001/Categories/get-Category",


    success: function(data)
    {   
      
        console.log(data)
       
           // html+="<option value='0'>Root</option>";
        for(var i =0;i<data.length;i++)
        { 
            
            if(data[i].parentid==0)
            {
                html+="<li><a href='type.html?id="+data[i].category_ID+"'>";
                html+=data[i].category_Name;
                html+="</li>";
               childmenu(data,data[i].category_ID);
               
            }
           
        }
       

        $("#type").html(html)
        console.log(html)
       
    },
    error : function (e){      
        console.log(e)
    }
})


function childmenu(data,j)
{  
    var idChildMenu=[];
    var nameChildMenu=[];
   
  
        for(var i =0;i<data.length;i++)
        {  
            if(data[i].parentid==j)
            {
               
                idChildMenu.push(data[i].category_ID);
                nameChildMenu.push(data[i].category_Name);
               
               
            }
           
         
        }
       
        if(idChildMenu.length>0)
        {
            
         
            for(var k=0;k<idChildMenu.length;k++)
            {   dd+="---";
                html+="<li ><a href='type.html?id="+idChildMenu[k]+"'>"; //Bắt đầu một dòng menu con với thẻ <li>
                html+=dd;
                html+=nameChildMenu[k];
                
                //Đệ quy, gọi lại chính hàm CreateChildMenu với tham số là idChildMenu hiện tại.
                childmenu(data,idChildMenu[k]);
                html+="</a></li>";
               
            }
           
        }
        else
        {
             dd="";
        }
        
        
}