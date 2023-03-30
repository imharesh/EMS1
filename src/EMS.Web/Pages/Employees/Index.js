$(function () {
    var l = abp.localization.getResource('EMS');
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employees/EditModal');


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
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('EMS.Employees.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('EMS.Employees.Delete'),
                                    confirmMessage: function (data) {
                                        return l('EmployeeDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        eMS.employees.employee
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                },
                            ]
                    }
                },
                
            

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

    // var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
