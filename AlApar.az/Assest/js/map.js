
    var X = $("#Xloc").val();
    var Y = $("#Yloc").val();

    function initMap() {
        // The location of Uluru
        var uluru = { lat: parseFloat(X), lng: parseFloat(Y) };
        // The map, centered at Uluru
        var map = new google.maps.Map(
            document.getElementById('map'), { zoom: 15, center: uluru });
        // The marker, positioned at Uluru
        var marker = new google.maps.Marker({ position: uluru, map: map });


    }

