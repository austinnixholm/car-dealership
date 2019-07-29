$(document).ready(function () {
    $('#submitSaleFilter').on('click',
        function () {
            var fromDate = getFromDate();
            var toDate = getToDate();
            if (fromDate == "") fromDate = "none";
            if (toDate == "") toDate = "none";
            submitSaleReportSearch(getUserValue(), fromDate, toDate);
        });
    $('#toDate, #fromDate').keypress(
        function (e) {
            if (e.which == 13) { //Enter key pressed
                $('#submitSaleFilter').click();
            }
        });
});

function submitSaleReportSearch(userValue, fromDate, toDate) {
    clearSalesReportTableBody();
    $.ajax({
        url: 'http://localhost:54067/sales/search/' + userValue + '/' + fromDate + '/' + toDate,
        type: 'GET',
        success: function(data) {
            $.each(data,
                function (index, sale) {
                    $('#salesResultsTableBodyContent').append('<tr>');
                    $('#salesResultsTableBodyContent').append('<td>' + sale.UserName + "</td>");
                    $('#salesResultsTableBodyContent').append('<td>$' + sale.TotalSalesAmount + "</td>");
                    $('#salesResultsTableBodyContent').append('<td>' + sale.TotalVehicles + "</td>");
                    $('#salesResultsTableBodyContent').append('</tr>');

                });
        },
        error: function() {
        }
    });
}

function clearSalesReportTableBody() {
    $('#salesResultsTableBodyContent').empty();
}

function getUserValue() {
    return $('#userDropdown option').filter(':selected').val();
}

function getFromDate() {
    return $('#fromDate').val();
}

function getToDate() {
    return $('#toDate').val();
}

function resetSaleReportsSearchTerms() {
    $('#toDate').val('');
    $('#fromDate').val('');
}