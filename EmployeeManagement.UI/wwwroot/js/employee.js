$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
    hideInsertForm();
});

function bindEvents() {
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h1>${result.name}</h1>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard);
                showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });

    });

        $(".employeeDelete").on("click", function (event) {
            var employeeId = event.currentTarget.getAttribute("data-id");
            var result = confirm("Are you sure you want to delete?");
            if (result) {
                alert("Deleted successfully! ")
                $.ajax({
                    url: 'https://localhost:44383/api/internal/employee/delete/' + employeeId,
                    type: 'DELETE',
                    contentType: "application/json; charset=utf-8",
                    success: function () {
                        location.reload();

                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
            }
            else {
                alert("Process cancelled..");
            }
        });


    $(".employeeInsert").on("click", function (event) {
        $("#createNewEmployee").show();

    });







        $("#createNewEmployee").submit(function (event) {
            var insertEmployee = {};



            insertEmployee.Name = $("#name").val();
            insertEmployee.Department = $("#department").val();
            insertEmployee.Age = Number($("#age").val());
            insertEmployee.Address = $("#address").val();



            var data = JSON.stringify(insertEmployee);



            $.ajax({
                url: ' https://localhost:44383/api/internal/employee/insert',
                type: 'POST',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                data: data,
                async: false,
                success: function () {
                    alert("User added successfully! ");
                    location.reload();
                },
                
                error: function (error) {
                    console.log(error);
                }

            });
        });

    /*$("#updateform").submit(function (event) {

        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Id = Number($("#empId").val());
        employeeDetailedViewModel.Name = $("#empName").val();
        employeeDetailedViewModel.Department = $("#empDept").val();
        employeeDetailedViewModel.Age = Number($("#empAge").val());
        employeeDetailedViewModel.Address = $("#empAddress").val();



        var data = JSON.stringify(employeeDetailedViewModel);



        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/update',
            type: 'PUT',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function () {
                alert("Updated successfully! ");
                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });*/

    $(".employeeEdit").on("click", function (event) {
        console.log("clicked");
        var employeeId = event.currentTarget.getAttribute("data-id");



        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $("#empId").val(result.id)
                $("#empName").val(result.name)
                $("#empDept").val(result.department)
                $("#empAge").val(result.age)
                $("#empAddress").val(result.address)
            },
            error: function (error) {
                console.log(error);
            }
        });
        $("#updateform").submit(function (event) {
            console.log("clicked");
            var idUpdate = $("#empId").val();
            var nameUpdate = $("#empName").val();
            var departmentUpdate = $("#empDept").val();
            var ageUpdate = $("#empAge").val();
            var addressUpdate = $("#empAddress").val();



            let employees = {
                id: parseInt(idUpdate),
                name: nameUpdate,
                department: departmentUpdate,
                age: parseInt(ageUpdate),
                address: addressUpdate
            };
            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                url: 'https://localhost:44383/api/internal/employee/update',
                type: 'PUT',
                data: JSON.stringify(employees),
                dataType: 'json',
                async: false,
                success: function (result) {

                    alert("Updated Successfully! ");
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });

    

 
}

 
function hideEmployeeDetailCard() {
    $("#EmployeeCard").hide();
}

function showEmployeeDetailCard() {
    $("#EmployeeCard").show();

}

function hideInsertForm() {
    $("#createNewEmployee").hide();
}

function showInsertForm() {
    $("#createNewEmployee").show();
}
