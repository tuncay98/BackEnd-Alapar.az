function initMap() {
    // The location of Uluru
    var uluru = {lat: 40.403873, lng: 49.8319962};
    // The map, centered at Uluru
    var map = new google.maps.Map(
        document.getElementById('map'), {zoom: 10, center: uluru});
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({position: uluru, map: map});
    

}

