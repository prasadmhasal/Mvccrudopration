$(document).ready(function () {
    getEmpData();
});

$('#btn1').click(function () {
    $('#exampleModal').modal('show');
    $('#updatebtn').hide()
    $("#idemp").hide()
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
                obj += "<td><input type='button' class='btn btn-danger' onclick='delEmp(" + item.id + ")' name='name' value='Delete' />||<input type='button' class='btn btn-success' id='btn2' onclick='EditEmp(" + item.id + ")' name='name' value='Edit' /></td>";
               
                obj += "</tr>";
            });
            $('#tabledata').html(obj);

        },
        error: function () {
            alert("Data not Found");
        }

    });

}

function delEmp(id)
{
    if (confirm("Do you want to delete this recorde?")) {
        $.ajax({
            url: '/Ajax/DeleteEmp?eid=' + id,
            success: function ()
            {
                alert("Emp Delete Recored Successfully !!");
                getEmpData();

            },
            error: function () {
                alert('Emp Not Found');
            }
        })


    }


}

function EditEmp(id)
{
    $.ajax({
        url: '/Ajax/EditEmp?eid=' + id,
        type: 'Get',
        dataType: 'Json',
        contentType:'application/Json;charset=utf8;',
        success: function (response) {
            $('#exampleModal').modal('show');
            $("#EmpId").val(response.id)
            $("#Name").val(response.name);
            $("#Email").val(response.email);
            $("#Salary").val(response.salary);
            $('#updatebtn').show();
            $('#savebtn').hide();
            $('#idemp').show();
            
        },
        error: function () {
            alert('Emp Not Found');
        }
    });
}

$('#updatebtn').click(function () {
  
    var obj2 = $('#myform').serialize();
    

    $.ajax({
        url: '/Ajax/updateEmp',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        data: obj2,
        success: function () {
            alert("Emp Edit Successfully");
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
