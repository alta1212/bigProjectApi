$(document).ready(function() {
    "use strict";

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
