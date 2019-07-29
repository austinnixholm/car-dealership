$(document).ready(function() {

    $('#submitSearch').on('click',
        function() {
            var minPrice = getMinSearchPrice();
            var maxPrice = getMaxSearchPrice();
            var minYear = getMinYear();
            var maxYear = getMaxYear();
            var searchTerm = $('#searchTerm').val();
            if (isNaN(minPrice)) minPrice = 0;
            if (isNaN(maxPrice)) maxPrice = 0;
            if (isNaN(minYear)) minYear = 0;
            if (isNaN(maxYear)) maxYear = 0;
            if (searchTerm === "") searchTerm = "none";
            var inventoryType = $('#inventoryType').val();
            submitSearch(inventoryType, minPrice, maxPrice, minYear, maxYear, searchTerm);
        });
    $('#resetSearchTerms').on('click',
        function() {
            resetSearchTerms();
        });
    $('#searchTerm, #minPrice, #maxPrice, #minYear, #maxYear').keypress(
        function(e) {
            if (e.which == 13) { //Enter key pressed
                $('#submitSearch').click(); //Trigger button click event
            }
        });
});

function submitSearch(inventoryType, minimumPrice, maximumPrice, minimumYear, maximumYear, searchTerm) {
    $('#searchResultsSection').show();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:54067/inventory/search/' + inventoryType.toLowerCase() + '/' +
            minimumPrice +
            "/" +
            maximumPrice +
            "/" +
            minimumYear +
            "/" +
            maximumYear +
            "/" +
            searchTerm,
        success: function(vehicleData) {
            appendToList(vehicleData, inventoryType);
        },
        error: function() {
            alert("Error loading web api data");
        }
    });
}

function appendToList(vehicleData, inventoryType) {
    var div = $('#searchResultsSection');
    div.empty();
    $.each(vehicleData,
        function(index, data) {
            var divData =
                '<div class="row"><div class="col-12"><div class="card mt-1" style="width: 100%;"><div class="card-body"><div class="row">';
            divData += '<div class="col-3">';
            divData += '<p class="ml-4">' +
                data.Vehicle.Year +
                " " +
                data.Make.MakeName +
                " " +
                data.Model.ModelName +
                "</p>";
            divData += "<img src=\"" + data.Vehicle.PicturePath + "\" style=\"width: 65%; height: 65%;\"/></div>";
            divData += '<div class="col-3">';
            divData += "<p class=\"mt - 3\"><b>Body Style: </b>" + data.BodyStyle.Style;
            + "</p>";
            divData += "<p><b>Transmission: </b>" + data.Vehicle.Transmission + "</p>";
            divData += "<p><b>Color: </b> " + data.Vehicle.Color + "</p></div>";
            divData += "<div class=\"col-3\">";
            divData += "<p class=\"mt - 3\"><b>Interior: </b> " + data.Interior.InteriorName + "</p>";
            divData += "<p><b>Mileage: </b> " + data.Vehicle.Mileage + "</p>";
            divData += "<p><b>VIN #: </b>" + data.Vehicle.VIN + "</p></div>";
            divData += "<div class=\"col-3\">";
            divData += "<p class=\"mt - 3\"><b>Sale Price: </b> $" + data.Vehicle.SalePrice + "</p>";
            divData += "<p><b>MSRP: </b> $" + data.Vehicle.MSRP + "</p>";
            var method = inventoryType.toLowerCase() == "sales"
                ? "purchaseVehicle(" + data.Vehicle.VehicleID + ")" :
                inventoryType.toLowerCase() == "admin" ? 
                "editVehicle(" + data.Vehicle.VehicleID + ")"
                : "searchVehicleInventory(" + data.Vehicle.VehicleID + ")";
            var buttonText = inventoryType.toLowerCase() == "sales" ? "Purchase" : inventoryType.toLowerCase() == "admin" ? "Edit" : "Details";
            divData += "<button class=\"btn btn-info text-center\" onclick=\"" + method + "\">" + buttonText + "</button></div>";
            divData += "</div></div></div></div></div>";
            div.append(divData);
        });
}

function editVehicle(vehicleID) {
    window.location.href = "editvehicle/?vehicleID=" + vehicleID;
}

function purchaseVehicle(vehicleID) {
    window.location.href = "sales/purchase/?vehicleID=" + vehicleID;
}

function searchVehicleInventory(vehicleID) {
    window.location.href = "vehicle/?vehicleID=" + vehicleID;
}

function resetSearchTerms() {
    $('#searchTerm').val("");
    $('#minPrice').val("");
    $('#maxPrice').val("");
    $('#minYear').val("");
    $('#maxYear').val("");
    $('#searchResultsSection').empty();
}

function getMaxYear() {
    return parseInt($('#maxYear').val());
}

function getMinYear() {
    return parseInt($('#minYear').val());
}

function getMaxSearchPrice() {
    return parseFloat($('#maxPrice').val());
}

function getMinSearchPrice() {
    return parseFloat($('#minPrice').val());
}