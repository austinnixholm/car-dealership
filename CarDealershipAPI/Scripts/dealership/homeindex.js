$(document).ready(function() {
    $('.vehicleCard').on('click',
        function() {
            var id = parseInt(this.id.toString());
            location.replace('http://localhost:54067/Inventory/vehicle/?vehicleID=' + id)
        });;
});
