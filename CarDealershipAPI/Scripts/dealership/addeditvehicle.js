$(document).ready(function() {
    setModelDropdowns($('#vehicleMakes option').filter(':selected').text());

    if ($('#modelID')) {
        setModelIDValue();
    }
    $('#vehicleMakes').on('change',
        function() {
            setModelDropdowns($('#vehicleMakes option').filter(':selected').text());
        });
    $('#deleteVehicle').on('click',
        function() {
            setModelIDValue();
            deleteVehicle();
        });
    $('#modelDropdown').on('change',
        function() {
            setModelIDValue();
        });
    $('#submit').on('click',
        function() {
            setModelIDValue();
        });
});

function checkModelID() {
    var value = $('#addEditModelID').val();
    if (value != 0) {
        $('#addEditModelID option[value="' + value + '"]').prop('selected', true);
    }
}

function setModelIDValue() {
    var modelID = getSelectedModelID();
    $('.model').val(modelID);
}

function getSelectedModelID() {
    return parseInt($('#modelDropdown option').filter(':selected').val());
}

function deleteVehicle() {
    var vehicleID = $('.vehicleID').val();

    if (confirm("Are you sure you want to delete this vehicle from the database?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:54067/inventory/vehicles/delete/' + vehicleID,
            success: function() {
                location.replace('http://localhost:54067/admin/vehicles');
            },
            error: function(xhr, status, error) {
                var err = eval("(" + xhr.responseText + ")");
                alert(err.Message);
            }
        });
    }
}

function setModelDropdowns(selectedMake) {
    $('#modelDropdown').empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:54067/inventory/models/' + selectedMake,
        success: function(modelData) {
            $.each(modelData,
                function(index, model) {
                    var value = $('#modelID').text();
                    $('#modelDropdown').append("<option value=" +
                        model.ModelID +
                        "" +
                        (model.ModelID == value ? " selected=\"selected\"" : "") +
                        ">" +
                        model.ModelName +
                        "</option>");
                });
            checkModelID();
        },
        error: function() {
        }
    });

}