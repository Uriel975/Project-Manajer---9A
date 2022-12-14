var Administrador = {
    Objects: {
        IDAdministrador: 0
    },
    init: function () {
        $("#formCreate").on("submit", function (e) {
            e.preventDefault()

            var A_NAMEADM = $("#txtNombreAdm").val();
            var A_EMAIL = $("#txtCorreoAdm").val();
            var A_UNAME = $("#txtUsuarioAdm").val();

            if (Administrador.Objects.IDAdministrador == 0) {
                var A_PFNAME = $("#txtApellidoPAdm").val();
                var A_PMNAME = $("#txtApellidoMAdm").val();
                var A_PREPASS = $("#txtPreContraseñaAdm").val();
                var A_PASS = $("#txtContraseñaAdm").val();

                if (A_NAMEADM.trim() == "") {
                    Dialog.show("El campo 'Nombre' es obligatorio", Dialog.type.error);
                    return;
                }
                if (A_PFNAME.trim() == "") {
                    Dialog.show("El campo 'Apellido paterno' es obligatorio", Dialog.type.error);
                    return;
                }
                if (A_PMNAME.trim() == "") {
                    Dialog.show("El campo 'Apellido materno es obligatorio' es obligatorio", Dialog.type.error);
                    return;
                }
                if (A_EMAIL.trim() == "") {
                    Dialog.show("El campo 'Correo electronico' es obligatorio", Dialog.type.error);
                    return;
                }
                if (A_UNAME.trim() == "") {
                    Dialog.show("El campo 'Usuario' es obligatorio", Dialog.type.error);
                    return;
                }
                if (A_PREPASS.trim() == "") {
                    Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                    return;
                }
                if (A_PREPASS.trim() != A_PASS.trim()) {
                    Dialog.show("La contraseña no coincide", Dialog.type.error);
                    return;
                }
                $.ajax({
                    url: Root + "Administrador/New",
                    type: "POST",
                    data: { nombre: A_NAMEADM, apellidop: A_PFNAME, apellidom: A_PMNAME, correo: A_EMAIL, contraseña: A_PREPASS, usuario: A_UNAME },
                    beforeSend: function () {
                        Dialog.show("Guardando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nuevo Administrador Creado Con Exito", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);

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
                    url: Root + "Administrador/Update",
                    type: "POST",
                    data: { nombre: A_NAMEADM, correo: A_EMAIL, usuario: A_UNAME, id: Administrador.Objects.IDAdministrador },
                    beforeSend: function () {
                        Dialog.show("Actualizando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Administrador actualizado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al actualizar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }
        });
    },
    evts: {
        getAdministradorInfo: function (id, nombre, correo, usuario) {
            Administrador.Objects.IDAdministrador = id;
            $("#txtNombreAdm").val(nombre);
            $("#txtCorreoAdm").val(correo);
            $("#txtUsuarioAdm").val(usuario);
            $("#mdlDetail").modal("show");
            $("#employeeStr").text("Actualizar Empleado");
            Dialog.hide();
        },
        updateStatus: function (id, status) {
            if (status == "0") {
                Dialog.show("¿Estás seguro que quiere Eliminar este Administrador?", Dialog.type.question);
            }
            else {
                Dialog.show("¿Reactivar este Usuario?", Dialog.type.question);
            }
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Administrador/UpdateStatus",
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
                            Dialog.show("A Ocurrido Un Error, Intente De Nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        }
    },

}