var p = $('.Getting').position();
 
$(document).ready(function(){
    window.onscroll = function() {
        if (window.pageYOffset >= p.top){
            $('.Fixed').css({position: 'fixed' ,top:"0", width: ""+$('.Custom-Container-Search-Box').width()});
        }
        else {
            $('.Fixed').css({position: '', top: ''});
        }
    }
});



