

document.getElementById("Categoryİd").addEventListener("change", function () {
    if(document.getElementById("Categoryİd").value == "1" ||
    
        document.getElementById("Categoryİd").value == '2' ){
        
        
            $('#MenzilOptions').css('display', 'block')
    }
    else{
        $('#MenzilOptions').css('display', 'none')

    }
    if(document.getElementById("Categoryİd").value== '3'){
        $('#HeyetEviOption').css('display', 'block')
    }
    else{
        $('#HeyetEviOption').css('display', 'none')
    }

    if(document.getElementById("Categoryİd").value== '4'){

        $('#OfisOptions').css('display', 'block')
    }
    else{
        $('#OfisOptions').css('display', 'none')
    }

    if(document.getElementById("Categoryİd").value== '6'){

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
    if(document.querySelector("#City").value== "7"){
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

  



$(function () {

    var imagesPreview = function (input, placeToInsertImagePreview) {

        if (input.files) {
            var filesAmount = input.files.length;

            for (i = 0; i < filesAmount; i++) {
                var reader = new FileReader();


              
   
                reader.onload = function (event) {

                    $($.parseHTML('<img>')).attr({ alt: "", src: event.target.result, onclick: 'Sil(event)', style: 'margin-bottom: 5px; margin-right: 3px' }).appendTo(placeToInsertImagePreview);
                    
                }

                reader.readAsDataURL(input.files[i]);

                        }

        }



    };

    $('#PhotoUpload').click(function () {
        $('#PhotoComing').html(" ");
    })

    $('#PhotoUpload').on('change', function () {

       
            imagesPreview(this, 'div#PhotoComing');
        
    




    });

    
});

var arr = [];
var test = document.getElementById("test");
document.getElementById("PhotoUpload").addEventListener("change", function () {

    for (var i = 0; i < this.files.length; i++) {
        arr.push(this.files[i])
    }


    console.log(document.getElementById("PhotoUpload").files.length)
    console.log(arr.length)
})


