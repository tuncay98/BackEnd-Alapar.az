document.getElementById("Categoryİd").addEventListener("change", function(){
    if(document.getElementById("Categoryİd").value == "0" ||
    
        document.getElementById("Categoryİd").value == '1' ){
        
        
            $('#MenzilOptions').css('display', 'block')
    }
    else{
        $('#MenzilOptions').css('display', 'none')

    }
    if(document.getElementById("Categoryİd").value== '2'){
        $('#HeyetEviOption').css('display', 'block')
    }
    else{
        $('#HeyetEviOption').css('display', 'none')
    }

    if(document.getElementById("Categoryİd").value== '3'){

        $('#OfisOptions').css('display', 'block')
    }
    else{
        $('#OfisOptions').css('display', 'none')
    }

    if(document.getElementById("Categoryİd").value== '5'){

        $('#MorS').html(" Sot")
    }
    else{
        $('#MorS').html(" m²")
    }
});

document.querySelector('#TorpaqSahesi').addEventListener('change', function(){
    this.value= this.value + ' Sot'
})

document.querySelector("#City").addEventListener("change", function(){
    if(document.querySelector("#City").value== "0"){
        $('#BakiRayonQesebe').css("display","block")
    }
    else{
        $('#BakiRayonQesebe').css("display","none")

    }
})




function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
      zoom: 13,
      center: {lat: 40.403873, lng: 49.8319962}
    });

    marker = new google.maps.Marker({
      map: map,
      draggable: true,
      animation: google.maps.Animation.DROP,
      position: {lat: 40.403873, lng: 49.8319962}
    });
    marker.addListener('click', toggleBounce);

    google.maps.event.addListener(marker, 'dragend', function (event) {
        document.getElementById("Xloc").value = marker.getPosition().lat();
        document.getElementById("Yloc").value = marker.getPosition().lng();
      });

  }

  function toggleBounce() {
    if (marker.getAnimation() !== null) {
      marker.setAnimation(null);
    } else {
      marker.setAnimation(google.maps.Animation.BOUNCE);
    }
  }

  

var photo= document.getElementById('PhotoUpload');

$(function() {
    // Multiple images preview in browser
    var imagesPreview = function(input, placeToInsertImagePreview) {

        if (input.files) {
            var filesAmount = input.files.length;

            for (i = 0; i < filesAmount; i++) {
                var reader = new FileReader();
               
               
   
                reader.onload = function(event) {
                    $($.parseHTML('<img>')).attr({src: event.target.result, onclick:'Sil(event)', style: 'margin-bottom: 5px'}).appendTo(placeToInsertImagePreview);
                    $($.parseHTML('<br>')).appendTo(placeToInsertImagePreview);
                }

                reader.readAsDataURL(input.files[i]);

                        }

        }



    };

    $('#PhotoUpload').on('change', function() {
        imagesPreview(this, 'div#PhotoComing');




    });

    
});


function Sil(event){
 
    $(event.target).remove()

}



document.querySelector("#SubmitBtn").addEventListener('click', function(){
    var c=document.getElementById("myCanvas");
var ctx=c.getContext("2d");
var imageObj1 = new Image();
var imageObj2 = new Image();
imageObj1.src = "1.png"
imageObj1.onload = function() {
   ctx.drawImage(imageObj1, 0, 0, 328, 526);
   imageObj2.src = "2.png";
   imageObj2.onload = function() {
      ctx.drawImage(imageObj2, 15, 85, 300, 300);
      var img = c.toDataURL("image/png");
      document.write('<img src="' + img + '" width="200" height="200"/>');
   }
};	
})

