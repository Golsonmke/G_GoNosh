
function initAutocomplete() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: {
            lat: 43.0334278,
            lng: -87.90930279999999
        },
        zoom: 13,
        mapTypeId: 'roadmap'
    });

    // Create the search box and link it to the UI element.
    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    var markers = [];
    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }

        // Clear out the old markers.
        markers.forEach(function (marker) {
            marker.setMap(null);
        });
        markers = [];

        // For each place, get the icon, name and location.
        var bounds = new google.maps.LatLngBounds();
        places.forEach(function (place) {
            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }
            var icon = {
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(25, 25)
            };

            // Create a marker for each place.
            markers.push(new google.maps.Marker({
                map: map,
                icon: icon,
                title: place.name,
                position: place.geometry.location
            }));

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }
        });
        map.fitBounds(bounds);
    });
}
//////////////////////////////////////////////////////////////////////////
//function initialize() {
//    //To find the current location and add the marker of current location
//    if (navigator.geolocation) {
//        navigator.geolocation.getCurrentPosition(showPosition, showError);
//    }
//    else { $("#message").html("Geolocation is not supported by this browser."); }
//    function showPosition(position) {
//        var currentLatLng = position.coords;
//        var latlon = "Latitude" + currentLatLng.latitude + "," + "Longitude" + currentLatLng.longitude;
//        //Google map options like langitude, latitude and zoom level
//        var mapOptions = {
//            center: new google.maps.LatLng(currentLatLng.latitude, currentLatLng.longitude),
//            zoom: 6,
//            mapTypeId: google.maps.MapTypeId.ROADMAP
//        };
//        var directionsService = new google.maps.DirectionsService;
//        var directionsDisplay = new google.maps.DirectionsRenderer;
//        var geocoder = new google.maps.Geocoder;
//        //Get the element of div to show google maps
//        var map = new google.maps.Map(document.getElementById("map"),
//            mapOptions);
//        directionsDisplay.setMap(map);
//        directionsDisplay.setPanel(document.getElementById('right-panel'));
//        var control = document.getElementById('floating-panel');
//        //control.style.display = 'block';
//        map.controls[google.maps.ControlPosition.TOP_CENTER].push(control);
//        // adding the user current location to teh marker
//        addMarker(currentLatLng.latitude, currentLatLng.longitude, "You are here. Please wait. System is locating near by locations");
//        // Ajax call to get the nearest locations from DB.
//        jQuery.ajax({
//            cache: false,
//            type: "POST",
//            url: "@Url.Action("GetNearByLocations")",
//            dataType: "json",
//            contentType: "application/json; charset=utf-8",
//            data: JSON.stringify({ Currentlat: currentLatLng.latitude, Currentlng: currentLatLng.longitude }),
//            success: function (data) {
//                //Adding the marker of nearest locations
//                if (data != undefined) {
//                    $.each(data, function (i, item) {
//                        // addMarker(item["lat"], item["lng"], item["Name"] + " & Distance: " + (Math.round(0.0 + item["Distance"] / 1000)) + " KM");
//                        addMarker(item["lat"], item["lng"], "Click to get directions");
//                    })
//                }
//            },
//            failure: function (errMsg) {
//                alert(errMsg);
//            }
//        });
//        // Add marker function to add the markers and information window settings
//        function addMarker(x, y, locationName, distance) {
//            var infowindow = new google.maps.InfoWindow({
//                content: locationName
//            });
//            var location = new google.maps.LatLng(x, y);
//            var marker = new google.maps.Marker({
//                position: location,
//                map: map,
//                title: locationName,
//            });
//            infowindow.open(map, marker);

//            // Call the funtion to draw the route map on the clicking on the map marker
//            marker.addListener('click', function () {
//                infowindow.open(map, marker);
//                calculateAndDisplayRoute(directionsService, directionsDisplay, x, y);
//            });
//        }
//        //function to draw the route from the current location to the clicked location on the map
//        function calculateAndDisplayRoute(directionsService, directionsDisplay, x, y) {

//            // Origin is user current location
//            var latlngSource = { lat: parseFloat(currentLatLng.latitude), lng: parseFloat(currentLatLng.longitude) };

//            //destination is clicked marker on the map
//            var latlangDestination = { lat: parseFloat(x), lng: parseFloat(y) };
//            directionsService.route({
//                origin: latlngSource, //Source
//                destination: latlangDestination, //destination
//                travelMode: 'DRIVING'
//            }, function (response, status) {
//                if (status === 'OK') {
//                    directionsDisplay.setDirections(response);
//                } else {
//                    window.alert('Directions request failed due to ' + status);
//                }
//            });
//        }
//    }
//    //show error formats incase the location is not found.
//    function showError(error) {
//        if (error.code == 1) {
//            $("#message").html("User denied the request for Geolocation.");
//        }
//        else if (error.code == 2) {
//            $("#message").html("Location information is unavailable.");
//        }
//        else if (error.code == 3) {
//            $("#message").html("The request to get user location timed out.");
//        }
//        else {
//            $("#message").html("An unknown error occurred.");
//        }
//    }
//}
//// Google maper - starting point
//google.maps.event.addDomListener(window, 'load', initialize);
//    </script >



