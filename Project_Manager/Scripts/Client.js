var Client = {
    Objects: {
        IDClinete: 0
    },
    init: function () {
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()

            var C_NAME = $("#txtNombre").val();
            var C_CELLPHONE = $("#txtCelular").val();
            var C_EMAIL = $("#txtCorreo").val();
            var C_PATERNALSURNAME = $("#txtApellidoP").val();
            var C_MATERNALSURNAME = $("#txtApellidoM").val();
            var C_USERNAME = $("#txtUsuario").val();


            if (Client.Objects.IDClinete == 0) {

                var C_NAMEEM = $("#txtNombreEmpresa").val();
                var C_PREPASSWORD = $("#txtPreContraseña").val();
                var C_PASSWORD = $("#txtContraseña").val();

                if (C_NAME.trim() == "") {
                    Dialog.show("El campo 'Nombre del empleado' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_PATERNALSURNAME.trim() == "") {
                    Dialog.show("El campo 'Apellido paterno' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_MATERNALSURNAME.trim() == "") {
                    Dialog.show("El campo 'Apellido materno es obligatorio' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_CELLPHONE.trim() == "") {
                    Dialog.show("El campo 'Telefono' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_EMAIL.trim() == "") {
                    Dialog.show("El campo 'Correo electronico' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_NAMEEM.trim() == "") {
                    Dialog.show("El campo 'Nombre empresa' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_EMAIL.trim() == "") {
                    Dialog.show("El campo 'Correo electronico' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_USERNAME.trim() == "") {
                    Dialog.show("El campo 'Usuario' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_PREPASSWORD.trim() == "") {
                    Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                    return;
                }
                if (C_PREPASSWORD.trim() != C_PASSWORD.trim()) {
                    Dialog.show("La contraseña no coincide", Dialog.type.error);
                    return;
                }
                var objCliente = {
                    NombreRepresentante: C_NAME,
                    ApellidoPRepresentante: C_PATERNALSURNAME,
                    ApellidoMRepresentante: C_MATERNALSURNAME,
                    TelefonoRepresentante: C_CELLPHONE,
                    NombreEmpresa: C_NAMEEM,
                    FKUsuario: C_USERNAME
                };
                $.ajax({
                    url: Root + "Clientes/New",
                    type: "POST",
                    data: {
                        dataCliente: JSON.stringify(objCliente),
                        CorreoEmpleado: C_EMAIL,
                        ContraEmpleado: C_PASSWORD
                    },
                    beforeSend: function () {
                        Dialog.show("Guardando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nuevo cliente creado correctamente", Dialog.type.success);
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
                    url: Root + "Clientes/Update",
                    type: "POST",
                    data: { nombre: C_NAME, apellidop: C_PATERNALSURNAME, apellidom: C_MATERNALSURNAME, telefono: C_CELLPHONE, correo: C_EMAIL, usuario: C_USERNAME, id: Client.Objects.IDClinete },
                    beforeSend: function () {
                        Dialog.show("Actualizando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Cliente actualizado correctamente", Dialog.type.success);
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
        getClientInfo: function (id, nombre,apellidop,apellidom, celular, gmail, user) {
            Client.Objects.IDClinete = id;
            $("#txtNombre").val(nombre);
            $("#txtApellidoP").val(apellidop);
            $("#txtApellidoM").val(apellidom);
            $("#txtCelular").val(celular);
            $("#txtCorreo").val(gmail);
            $("#txtUsuario").val(user);
            $("#mdlDetail").modal("show");
            $("#employeeStr").text("Actualizar Cliente");
            Dialog.hide();
        },
        updateStatus: function (id, status) {
            if (status == "0") {
                Dialog.show("¿Esta seguro que quiere Eliminar este cliente?", Dialog.type.question);
            }
            else {
                Dialog.show("¿Desea reactivar este Empleado?", Dialog.type.question);
            }
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Clientes/UpdateStatus",
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