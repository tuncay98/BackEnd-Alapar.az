$(document).ready(function(){
    $(".owl-carousel").owlCarousel();
  });

  $('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    center: true,
    responsiveClass:true,
    dots: false,
    responsive:{
        0:{
            items:1,
            nav:true
        },
        600:{
            items:3,
            nav:false
        },
        1000:{
            items:5,
            nav:true,
            loop:true
        }
    },
    autoplay:true,
    autoplayTimeout:2500,
    autoplayHoverPause:true
})





$('.play').on('click',function(){
    owl.trigger('play.owl.autoplay',[1000])
})
$('.stop').on('click',function(){
    owl.trigger('stop.owl.autoplay')
})


var slider = document.getElementById("myRange");
var output = document.getElementById("Max");
var output2 = document.getElementById("Min");



slider.oninput = function() {
  output.value = this.value*5000;
}


//var slider2 = document.getElementById("myRange2");
//var output11 = document.getElementById("MaxPlace");
//var output22 = document.getElementById("MinPlace");

//output11.addEventListener("change", function(){

//    output22.setAttribute("max", ""+ output11.value +"")
//    if(output11.value< output22.value){
//        if(output11.value>1000){
//            output22.value = output11.value-1000;
//        }
//        else{
//            output22.value = output11.value-100;
//        }
//    }
//});

//slider2.addEventListener("change", function(){
//    output22.setAttribute("max", ""+ output11.value +"")


//});

//output22.addEventListener('change', function(){
//    if(output11.value>10  && output11.value < this.value){
//        this.value= output11.value;
//    }
//    else{
//        this.value != output11.value+1;
//    }
//})

//slider2.oninput = function() {
//  output11.value = this.value;
//}







document.querySelectorAll('a[href^="#Nav"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});


document.querySelectorAll("#List img").forEach(function (element) {
    element.style.height = element.offsetWidth + "px"
});

document.querySelectorAll("#VipAds img").forEach(function (element) {
    element.style.height = element.offsetWidth + "px"
});

document.querySelectorAll("#Starter img").forEach(function (element) {
    element.style.height = element.offsetWidth + "px"
});


$(document).ready(function () {

    $("#AddiitoinList").click(function () {
        $.ajax({
            url: "/Home/LoadingMoreAds?Length=" + $(".ForAjax .col-12").length,
            type: "Get",
            dataType: "html",
            success: function (response) {
                if ($(".ForAjax .col-12").length < $("#NumberOfElan").val()) {

                    $(".ForAjax").append(response);
                }
                else {
                   
                    $(".ForAjax").append('<div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"> <center style="padding: 5px 10px; background: red; color: white"><span >Elan bitmişdir</span></center> </div>"');
                    $("#AddiitoinList").remove()
                }


            }

        })
    })


    $("#SearchButton").click(function() {

        var MinMoney;
        if ($("#Min").val() > 0) {
            MinMoney = $("#Min").val();
        }
        else {
            MinMoney = 0;
        }

        var MaxMoney;

        if ($("#Max").val() > 0) {
              MaxMoney = $("#Max").val();
        }
        else {
            MaxMoney = 0;
        }



        $.ajax({
            url: "/Home/Search?MinMoney=" + MinMoney + "&MaxMoney=" + MaxMoney + "&Length=" + $("#NumberOfElan").val() ,
            type: "Post",
            dataType: "html",
            success: function (response) {

                $(".ForAjax").html("");
                $(".ForAjax").append(response).ready(function () {

                    document.querySelectorAll("#List img").forEach(function (element) {
                        element.style.height = element.offsetWidth + "px"
                    });
                });
            },
            load: function () {
                $(".ForAjax").html("Gözləyin");
            }

        })





    })


})