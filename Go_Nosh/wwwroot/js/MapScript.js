let map = null;

function initMap() {
    let location = new Object();
    navigator.geolocation.getCurrentPosition(function (pos) {
        location.lat = pos.coords.latitude;
        location.long = pos.coords.longitude;
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: location.lat, lng: location.long },
            zoom: 8
        });
    });
    getFoodTrucks(location);
}

function getFoodTrucks(location) {
    var milwaukee = new google.maps.LatLng(location.lat, location.long);
    var request = {
        location: milwaukee,
        radius: '1500',
        type: ['foodtruck']
    };
    service = new google.maps.places.PlacesService(map);
    service.nearbySearch(request, callback);
}

function callback(results, status) {
    if (status == google.maps.places.PlacesServiceStatus.Ok) {
        for (var i = 0; i < results.length; i++) {
            var place = results[i];
            let price = createPrice(place.price_level);
            let content = `<h3>${place.name}<h3>
              <h4>${place.vicinity}<h4>
                <p>Price: ${price}<br>
                Rating: ${place.rating}`;

            var marker = new google.maps.Marker({
                position: place.geometry.location,
                map: map,
                title: place.name
            });

            var infowindow = new google.maps.InfoWindow({
                content: content
            });

            bindInfoWindow(mark, map, infowindow, content);
            marker.setMap(map);
        }

    }
}

function bindfInfoWindow(marker, map, infowindow, html) {
    marker.addlistener('click', function(){
        infowindow.setContent(html);
        infowindow.open(map, this);
    });
}

function creatPrice(level) {
    if (level != "" && level != null ) {
        let out;
        for (var x = 0; x < level; x++) {
            out += "$";
        }
        return out;
    } else {
        return "?";
    }
}



var map;
function createMap() {
    var options = {
        center: { lat: -34.397, lng: 150, 644 },
        zoom: 10
    };

    map = new google.maps.Map(document.getElementById('map'), options);

    var input = document.getElementById('search');
    var searchBox = new google.maps.places.SeachBox(input);

    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });
    var markers = [];

    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length === 0)
            return;
        markers.forEach(function (m) { m.setMap(null); });
        markers = [];

        var bounds = new google.maps.LatLngBounds();

        places.forEach(function (p) {
            if (!p.geometry)
                return;

            markers.push(new google.maps.Marker({
                map: map,
                titile: p.name,
                position: pgeometry.location
            }));

            if (p.geometry.viewport)
                bounds.union(p.geometry.viewport);
            else
                bounds.extend(p.geometry.location);
        });
        map.fitBounds(bounds);
    });
}






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
        service.nearbysearch(placesrequest, function (results, status) {
            if (status == google.maps.placces.placesservicestatus.ok) {
                results.foreach(function (place) {
                    //console.log(place);
                    createmarker(place);
                });
            }
        });
    } else {
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



//***************************************************************************
 //var map;
        //var infoWindow;
        //var request;
        //var markers = [];
        //var service;
        //function initialize() {
        //    var center = new google.maps.LatLng(-34.397, l50.644);
        //    map = new google.Map(document.getElementById('map'), {
        //        center: center,
        //        zoom: 13
        //    });
        //}


        //var request = {
        //    location: center,
        //    radius: 8000,
        //    types: ['foodtrucks']
        //};
        //var service = new google.maps.places.PlacesService(map);

        //service.nearbySearch(request, callback);

        //function callback(results, status) {
        //    if (status == google.maps.places.PlacesServiceStatus.Ok) {
        //        for (var i = 0; i < results.length; i++) {
        //            createMarker(results[i]);
        //        }
        //    }
        //}
        //function createMarker(place) {
        //    var placeLoc = place.geometry.location;
        //    var marker = new google.maps.Marker({
        //        map: map,
        //        position: place.geometry.location
        //    });
        //    goog.maps.event.addListener(marker, 'click', function () {
        //        infowindow.setContent(place.name);
        //        infoWindow.open(map, this);
        //    });
        //} return marker;

        //function clearResult(markers) {
        //    for (var m in markers) {
        //      markers[m].setMap(null)    

        //    }
        //    markers = []
        //}

        //google.maps.event.addDomListener(windo, 'load', initialize)










function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 12

    });
    infoWindow = new google.maps.InfoWindow;

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(pos);
            infoWindow.setContent("Hi Mom!");
            infoWindow.open(map);
            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {

        handleLocationError(false, infoWindow, map.getCenter());
    }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}
function makeplacesrequest(lat, lng) {
    var query = document.getelementbyid("query").value;
    if (query) {
        var placesrequest = {
            location: new google.maps.latlng(lat, lng),
            radius: 2000,
            keyword: query
        };
        service = new google.maps.places.PlacesService(map);

        service.findPlaceFromQuery(request, function (results, status) {
            if (status === google.maps.places.PlacesServiceStatus.OK) {
                for (var i = 0; i < results.length; i++) {
                    createMarker(results[i]);
                }

                map.setCenter(results[0].geometry.location);
            }
        });
    } else {
        console.log("no query entered for places search");

    }
    function createMarker(place) {
        var marker = new google.maps.Marker({
            map: map,
            position: place.geometry.location
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.setContent(place.name);
            infowindow.open(map, this);
        });
    }
}


function showform() {
    var searchform = document.getelementbyid("search");
    searchform.style.visibility = "visible";
    var button = document.queryselector("button");
    button.onclick = function (e) {
        e.preventdefault();
        makePlacesRequest(currentcoords.latitude, currentcoords.longitude);
        console.log("clicked the search button");
    };
}










//WOrkin/////////////////////////////////////////


//< !DOCTYPE html >
//    <html>
//        <head>
//            <title>Place Searches</title>
//            <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
//                <meta charset="utf-8">
//                    <style>
//                        html, body {
//                            height: 50%;
//            background-color: #d4cdcd;
//            margin: 5px;
//            padding: 5px;
//        }

//    </style>
//                    <script>

//                        var map;
//                        var infowindow;
//                        var markers = [];
//                        var infowindow;
//                        var service;
//        var currentcoords = {};

//        function initMap() {
//                            map = new google.maps.Map(document.getElementById('map'), {
//                                center: { lat: 43.0334278, lng: -87.90930279999999 },
//                                zoom: 10

//                            });
//            infoWindow = new google.maps.InfoWindow;


//            if (navigator.geolocation) {
//                            navigator.geolocation.getCurrentPosition(function (position) {
//                                var pos = {
//                                    lat: position.coords.latitude,
//                                    lng: position.coords.longitude
//                                };

//                                infoWindow.setPosition(pos);
//                                infoWindow.setContent("Hi Mom!");
//                                infoWindow.open(map);
//                                map.setCenter(pos);
//                            }, function () {
//                                handleLocationError(true, infoWindow, map.getCenter());
//                            });
//            } else {

//                            handleLocationError(false, infoWindow, map.getCenter());
//            }
//        }

//        function handlelocationerror(browserhasgeolocation, infowindow, pos) {
//                            infowindow.setposition(pos);
//            infowindow.setcontent(browserhasgeolocation ?
//                'error: the geolocation service failed.' :
//                'error: your browser doesn\'t support geolocation.');
//            infowindow.open(map);
//        }
//        function makeplacesrequest(lat, lng) {
//            var query = document.getelementbyid("query").value;
//            if (query) {
//                var placesrequest = {
//                            location: new google.maps.latlng(lat, lng),
//                    radius: 2000,
//                    keyword: query
//                };
//                service = new google.maps.places.PlacesService(map);

//                service.findPlaceFromQuery(placesrequest, function (results, status) {
//                    if (status === google.maps.places.PlacesServiceStatus.OK) {
//                        for (var i = 0; i < results.length; {
//                            createMarker(results[i]);
//                        }

//                        map.setCenter(results[0].geometry.location);
//                    }
//                });
//            } else {
//                            console.log("no query entered for places search");

//            }
//            function createMarker(place) {
//                var marker = new google.maps.Marker({
//                            map: map,
//                    position: place.geometry.location
//                });

//                google.maps.event.addListener(marker, 'click', function () {
//                            infowindow.setContent(place.name);
//                    infowindow.open(map, this);
//                });
//            }
//        }


//        function showform() {
//            var searchform = document.getelementbyid("search");
//            searchform.style.visibility = "visible";
//            var button = document.querySelector("button");
//            button.onclick = function (e) {
//                            e.preventdefault();
//                makePlacesRequest(currentcoords.latitude, currentcoords.longitude);
//                console.log("clicked the search button");
//            };
//        }


//    </script>
//</head>
//                <body>
//                    <h1 class="align-items-lg-center">Find Food trucks</h1>
//                    <form id="search">
//                        <label for="query"> </label>
//                        <input id="query">
//                            <button onclick="makeplacesrequest">Search</button>
//    </form>

//                        <div id="map"></div>
//                        <script src="https://maps.googleapis.com/maps/api/js?key=@API_KEY.googleMapsApiKey&libraries=places&callback=initMap" async defer></script>
//</body>
//</html>