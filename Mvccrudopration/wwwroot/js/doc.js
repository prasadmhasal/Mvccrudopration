$(document).ready(function () {

});

$('#btn1').click(function () {
    $('#exampleModal').modal('show')
});

$('#save').click(function () {

    var obj = {
        Name: $('#Name').val(),
        Email: $('#Email').val(),
        Salary: $('#Salary').val()
    }
    $.ajax({
        url: '/Ajax/AddEmp',
        type: 'POST',
        dataType: 'json',
        contentType: 'appliaction/x-www-form-urlencoded;charset=utf8',
        data: obj,
        success: function () {
            alert("Emp Added Successfully");
            $('#exampleModal').modal('hide');
        },
        error: function () {
            alert("Something wrong");
        }
    }

    )
});


