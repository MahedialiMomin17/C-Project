
//model popup on search icon
$(document).ready(function () {
    $('.open-modal').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('#customerDetails').html(data);
            $('#CustomerModal').modal('show');
        });
    });

});



//export csv file 
$(document).ready(function () {
    $('#export-btn').click(function (e) {
        e.preventDefault();
        var url = '@Url.Action("Create", "Customer", new { downloadCSV = true })';
        window.location.href = url;
    });
});



//reset button 
document.getElementById("resetButton").addEventListener("click", function () {

    document.cookie.split(';').forEach(c => {
        document.cookie = c.replace(/^ +/, '').replace(/=.*/, '=;expires=' + new Date().toUTCString() + ';path=/');
    });

    document.getElementById("searchTextbox").value = "";

    window.location.href = 'search';
});

