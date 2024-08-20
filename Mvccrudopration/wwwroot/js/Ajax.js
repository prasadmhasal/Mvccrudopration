$(document).ready(function () {
    getEmpData();
});

$('#btn1').click(function () {
    $('#exampleModal').modal('show');
});


$('#test').click(function () {    
    alert("Hello");
});

function clearform()
{
    var obj = {
        name: $('#Name').val(""),
        email: $('#Email').val(""),
       salary: $('#Salary').val("")
    }

}
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
            clearform();
            $('#exampleModal').modal('hide');
            getEmpData();
        },
        error: function () {
            alert("Something wrong");
        }
    }

    )
});


function getEmpData()
{
    $.ajax({
        url: '/Ajax/GetEmp',
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/Json;charset=utf8;',

        success: function (result, status, xhr) {
            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";
                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name +"</td>";
                obj += "<td>" + item.email +"</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "</tr>";
            });
            $('#tabledata').html(obj);

        },
        error: function () {
            alert("Data not Found");
        }

    });

}


