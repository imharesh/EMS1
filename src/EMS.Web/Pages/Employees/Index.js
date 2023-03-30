$(function () {
    var l = abp.localization.getResource('EMS');

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(eMS.employees.employee.getList),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Age'),
                    data: "age"
                },
               
            ]
        })
    );
});
