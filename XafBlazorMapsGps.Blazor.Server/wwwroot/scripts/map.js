function getGeolocation() {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                function (position) {
                    const latitude = position.coords.latitude;
                    const longitude = position.coords.longitude;
                    resolve({ latitude, longitude });
                },
                function (error) {
                    reject(error);
                }
            );
        } else {
            reject(new Error("Geolocation is not supported by this browser."));
        }
    });
}

function showGeolocation(dotNetHelper) {
    var lat = 0;
    var lng = 0;

    // Clear existing content inside the 'map' div
    var mapDiv = document.getElementById('map');
    while (mapDiv.firstChild) {
        mapDiv.removeChild(mapDiv.firstChild);
    }

    // Create the map
    var map = new DevExpress.ui.dxMap(document.getElementById('map'), {
        zoom: 10,
        provider: "bing",
        width: "100%",
        height: "400px",
        apiKey: {
            // Specify your API keys for each map provider:
            //bing: "YOUR_BING_MAPS_API_KEY",
            //google: "YOUR_GOOGLE_MAPS_API_KEY",
            //googleStatic: "YOUR_GOOGLE_STATIC_MAPS_API_KEY"
        },
        onReady: function (e) {
            getGeolocation()
                .then((coords) => {
                    lat = coords.latitude;
                    lng = coords.longitude;
                    const tooltipContent = `Latitude: ${lat}, Longitude: ${lng}`;
                    dotNetHelper.invokeMethodAsync('UpdateLocation', { Latitude: lat, Longitude: lng });
                    map.addMarker({
                        location: [lat, lng],
                        tooltip: tooltipContent
                    });
                })
                .catch((error) => {
                    handleNoGeolocation(error.message);
                });
        }
    });

    function handleNoGeolocation(errorMessage) {
        alert(`Error: ${errorMessage}`);
    }
}