var GlobalClientes = {
    Objects: {
        IDEmpleado: 0
    },
    init: function () {
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()
            
            var E_NAME = $("#txtNombre").val();
            var E_CELLPHONE = $("#txtCelular").val();
            var E_USERNAME = $("#txtUsuario").val();
            var E_EMAIL = $("#txtCorreo").val();

            if (GlobalClientes.Objects.IDEmpleado == 0) {
                var E_PATERNALSURNAME = $("#txtApellidoP").val();
                var E_MATERNALSURNAME = $("#txtApellidoM").val();
                var E_BIRTH = $("#txtfecha").val();
                var E_GENDER = $("#txtGenero").val();
                var E_PREPASSWORD = $("#txtPreContraseña").val();
                var E_PASSWORD = $("#txtContraseña").val();

                if (E_NAME.trim() == "") {
                    Dialog.show("El campo 'Nombre' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_PATERNALSURNAME.trim() == "") {
                    Dialog.show("El campo 'Apellido paterno' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_MATERNALSURNAME.trim() == "") {
                    Dialog.show("El campo 'Apellido materno es obligatorio' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_CELLPHONE.trim() == "") {
                    Dialog.show("El campo 'Telefono' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_BIRTH.trim() == "") {
                    Dialog.show("El campo 'Fecha de nacimiento' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_GENDER.trim() == "") {
                    Dialog.show("El campo 'Genero' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_EMAIL.trim() == "") {
                    Dialog.show("El campo 'Correo electronico' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_USERNAME.trim() == "") {
                    Dialog.show("El campo 'Usuario' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_PREPASSWORD.trim() == "") {
                    Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_PREPASSWORD.trim() != E_PASSWORD.trim()) {
                    Dialog.show("La contraseña no coincide", Dialog.type.error);
                    return;
                }
                var objEmpleado = {
                    NombreEmpleado: E_NAME,
                    ApellidoPEmpleado: E_PATERNALSURNAME,
                    ApellidoMEmpleado: E_MATERNALSURNAME,
                    TelefonoEmpleado: E_CELLPHONE,
                    Nacimiento: E_BIRTH,
                    GeneroEmpleado: E_GENDER,
                    FKUsuario: E_USERNAME
                };
                $.ajax({
                    url: Root + "Empleado/New",
                    type: "POST",
                    data: {
                        dataEmpleado: JSON.stringify(objEmpleado),
                        CorreoEmpleado: E_EMAIL,
                        ContraEmpleado: E_PASSWORD
                    },
                    beforeSend: function () {
                        Dialog.show("Guardando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nuevo empleado creado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                                //location.href = '/HumanResources/Persons';
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al guardar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }
            else {
                $.ajax({
                    url: Root + "Empleado/Update",
                    type: "POST",
                    data: { nombre: E_NAME, telefono: E_CELLPHONE, correo: E_EMAIL, usuario: E_USERNAME, id: GlobalClientes.Objects.IDEmpleado },
                    beforeSend: function () {
                        Dialog.show("Actualizando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Empleado actualizado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                                //location.href = '/HumanResources/Persons';
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al actualizar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }  
        });
        $(".input-number").on("input", function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    },
    evts: {
        getEmployeesInfo: function (id, nombre, celular, gmail,user) {
            GlobalClientes.Objects.IDEmpleado = id;
            $("#txtNombre").val(nombre);
            $("#txtCelular").val(celular);
            $("#txtCorreo").val(gmail);
            $("#txtUsuario").val(user);
            $("#mdlDetail").modal("show");
            $("#employeeStr").text("Actualizar Empleado");
            Dialog.hide();
        },
        updateStatus: function (id, status) {
            if (status == "0") {
                Dialog.show("¿Estás seguro que quiere Eliminar este empleado?", Dialog.type.question);
            }
            else {
                Dialog.show("Reactivar este Empleado?", Dialog.type.question);
            }
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Empleado/UpdateStatus",
                    type: "POST",
                    data: { id: id, estatus: status },
                    beforeSend: function () {
                        Dialog.show("Eliminando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            location.reload(true);
                        }
                        else {
                            Dialog.show("Ocurrió un error al eliminar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        }
    }
}