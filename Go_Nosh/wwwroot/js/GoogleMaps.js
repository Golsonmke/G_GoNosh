var map;
var infowindow;
var markers = [];
var infowindow; 
var currentcoords = {};



function displaylocation() {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;

    var plocation = document.getelementbyid("location");
    plocation.innerhtml += latitude + " , " + longitude + "<br>";

    showmap(position.coords);

}
function showmap(coords) {
    var googlelatlong = new google.maps.latlng(coords.latitude, coords.longitude);

    var mapoptions = {
        zoom: 11,
        center: googlelatlong,
        maptypeid: google.maptypeid.roadmap

    };

    var mapdiv = document.getelementbyid("map");
    map = new google.maps.map(mapdiv, mapoptions);
    infowindow = new google.maps.infowindow();

    google.maps.event.addlistener(map, "click", function (event) {
        var latitude = event.latlng.lat();
        var longitude = event.latlng.lng();
        currentcoords.latitude = latitude;
        currentcoords.longitude = longitude;

        var plocation = document.getelementbyid("location");
        plocation.innerhtml = latitude + " , " + longitude;
        map.panto(event.latlng);

        

    });
    showform();
}
function makeplacesrequest(lat, lng) {
    var query = document.getelementbyid("query").value;
    if (query) {
        var placesrequest = {
            location: new google.maps.latlng(lat, lng),
            radius: 2000,
            keyword: query
        };
        service.nearbysearch(placesrequest, function (results, status)
{ 
            if (status == google.maps.placces.placesservicestatus.ok) {
                results.foreach(function (place) {
                    //console.log(place);
                    createmarker(place);
                });
            }
        });
    }else {
        console.log("no query entered for places search");
        
    }
}
function createmarker(place) {
    var markeroptions = {
        position: place.geometry.location,
        map: map,
        clickable: true
    };

    var marker = new google.maps.marker(markeroptions);
    markers.push(marker);

    google.maps.event.addlistener(marker, "click", function (place, marker) {
        return function () {
            if (place.vicinity) {
                infowindow.setcontent(place.name + "<br>" + place.vicinity);
            } else {
                infowindow.setcontent(place.name);
            }
            infowindow.open(map, marker);

        };
    }(place, marker));
}
function clearmarkers() {
    markers.foreach(function (marker) { marker.setmap(null); });
    markers = [];
}

function showform() {
    var searchform = document.getelementbyid("search");
    searchform.style.visibility = "visible";
    var button = document.queryselector("button");
    button.onclick = function (e) {
        e.preventdefault();
        makeplacesrequest(currentcoords.latitude, currentcoords.longitude);
        console.log("clicked the search button");
    };
}
function displayerror(error) {
    var errors = ["unknown error", "permission denied by user", "position not available", "timeout error"];
    var message = errors[error.code];
    console.warn("error in getting your location: " + message, error.message);
}
window.onload = function () {
    if (navigator.geolocation) {
        navigator.geolocation.getcurrentposition(displaylocation, displayerror);
    }
    else {
        alert("sorry, this browser doesn't support geolocation")
    }
}

//<html>
//    <head>
//        <title>simple map</title>
//        <meta name="viewport" content="initial-scale=1.0">
//            <meta charset="utf-8">
//                <style>


//                    html, body {
//                        height: 50%;
//            background-color: #d4cdcd;
//            margin: 0;
//            padding: 0;
//        }
//    </style>


//                <h1 class="align-items-lg-center">find food trucks</h1>
//                <form id="search">
//                    <label for="query"> </label>
//                    <input id="query">
//                        <button>search</button>
//    </form>


//                    <script>
//                        var map;
//        function initmap() {
//                            map = new google.maps.map(document.getelementbyid('map'), {
//                                center: {
//                                    lat: 42.958847999999996,
//                                    lng: -87.9427584
//                                },
//                                zoom: 8

//                            });
//        }
//    </script>
//</head>
//                <body>
//                    <div id="map"></div>
//                    <script src="https://maps.googleapis.com/maps/api/js?key=@api_key.googlemapsapikey&libraries=places&callback=initmap"
//                        async defer></script>
//                </body>
//</html>
