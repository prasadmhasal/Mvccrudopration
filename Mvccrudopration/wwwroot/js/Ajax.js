﻿$(document).ready(function () {
    alert("Hello");
});

$('#btn1').click(function () {
    $('#exampleModal').modal('show');
});


$('#test').click(function () {
    alert("Hello");
});
$('#savebtn').click(function () {
    //var obj = {
    //    name: $('#Name').val(),
    //    email: $('#Email').val(),
    //   salary: $('#Salary').val()
    //}
    var obj2 = $('#myform').serialize();
   /* console.log(obj);*/
    /*console.log(obj2);*/

    $.ajax({
        url: '/Ajax/AddEmp',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        data: obj2,
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