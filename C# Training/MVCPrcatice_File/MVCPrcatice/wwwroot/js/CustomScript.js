
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


    //export csv file 
    $('#export-btn').click(function (e) {
        e.preventDefault();
        var url = '@Url.Action("Create", "Customer", new { downloadCSV = true })';
        window.location.href = url;
    });




    //reset button 
    $(document).on('click', '#resetButton', function () {

        document.cookie.split(';').forEach(c => {
            document.cookie = c.replace(/^ +/, '').replace(/=.*/, '=;expires=' + new Date().toUTCString() + ';path=/');
        });

        document.getElementById("searchTextbox").value = "";

        window.location.href = 'search';
    });


    //document.getElementById("resetButton").addEventListener("click", function () {

    //    document.cookie.split(';').forEach(c => {
    //        document.cookie = c.replace(/^ +/, '').replace(/=.*/, '=;expires=' + new Date().toUTCString() + ';path=/');
    //    });

    //    document.getElementById("searchTextbox").value = "";

    //    window.location.href = 'search';
    //});




    //delete model popup
    $(document).on('click', '.delete-btn', function (e) {
        e.preventDefault();
        var customerId = $(this).data('id');
        console.log('customer ID :' + customerId);
        Swal.fire({
            title: 'Are you sure?',
            text: 'You will not be able to recover this record!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                console.log(result)
                $.ajax({
                    url: '/Customer/Delete',
                    type: 'POST',
                    data: { id: customerId },
                    success: function (result) {
                        $('#' + customerId).remove();
                    },
                    error: function (xhr, status, error) {
                        console.log(xhr.responseText);
                    }
                });
            }
        });
    });




    //user dropdown role

    $('.select-action').change(function () {
        var itemId = $(this).data('id');
        var selectedAction = $(this).val();

        $.ajax({
            url: '/Account/UpdateRole',
            type: 'POST',
            data: {
                id: itemId,
                role: selectedAction
            },
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Role changed successfully!',
                    showConfirmButton: false,
                    timer: 1800
                });
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });





    $(document).on('click', '.Delete-Btn', function (e) {
        e.preventDefault();
        var customerId = $(this).data('id');
        console.log('customer ID :' + customerId);
        Swal.fire({
            title: 'Are you sure?',
            text: 'You will not be able to recover this record!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                console.log(result)
                $.ajax({
                    url: '/Account/DeleteRole',
                    type: 'POST',
                    data: { id: customerId },
                    success: function (result) {
                        $('#' + customerId).remove();

                    },
                    error: function (xhr, status, error) {
                        console.log(xhr.responseText);
                    }
                });
            }
        });
    });


});




