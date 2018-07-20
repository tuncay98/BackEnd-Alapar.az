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

output.addEventListener("change", function(){

    output2.setAttribute("max", ""+ output.value +"")
    if(output2.value> output.value){
        if(output.value>1000){
            output2.value= output.value-1000;
        }
        else{
            output2.value= output.value-100;
        }
    }
});
slider.addEventListener("change", function(){
    output2.setAttribute("max", ""+ output.value +"")


});

output2.addEventListener('change', function(){
    if( output.value>10 && output.value < output2.value){
        output2.value= output.value;
    }
    else{
        this.value != output.value+1000;
    }
})

slider.oninput = function() {
  output.value = this.value*10000;
}


var slider2 = document.getElementById("myRange2");
var output11 = document.getElementById("MaxPlace");
var output22 = document.getElementById("MinPlace");

output11.addEventListener("change", function(){

    output22.setAttribute("max", ""+ output11.value +"")
    if(output11.value< output22.value){
        if(output11.value>1000){
            output22.value = output11.value-1000;
        }
        else{
            output22.value = output11.value-100;
        }
    }
});

slider2.addEventListener("change", function(){
    output22.setAttribute("max", ""+ output11.value +"")


});

output22.addEventListener('change', function(){
    if(output11.value>10  && output11.value < this.value){
        this.value= output11.value;
    }
    else{
        this.value != output11.value+1;
    }
})

slider2.oninput = function() {
  output11.value = this.value;
}







document.querySelectorAll('a[href^="#Nav"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});



