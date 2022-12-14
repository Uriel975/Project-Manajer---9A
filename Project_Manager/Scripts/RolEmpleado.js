var Rol = {
    Objects: {
        IDJunta: 0
    },
    init: function () {
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()

            var J_HORA = $("#txthora").val();
            var J_FECHA = $("#txtfecha").val();


            if (Rol.Objects.IDJunta == 0) {
                var J_NOMRE = $("#txtNombre").val();
                var J_MOTIVO = $("#mensaje").val();
                var J_PROYECTO = $("#cmbEmpresa").val();

                if (J_NOMRE.trim() == "") {
                    Dialog.show("El campo 'Titulo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (J_MOTIVO.trim() == "") {
                    Dialog.show("El campo 'Motivo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (J_PROYECTO.trim() == 0) {
                    Dialog.show("El campo 'Proyecto' es obligatorio", Dialog.type.error);
                    return;
                }
                if (J_HORA.trim() == "") {
                    Dialog.show("El campo 'Hora' es obligatorio", Dialog.type.error);
                    return;
                }
                if (J_FECHA.trim() == "") {
                    Dialog.show("El campo 'Fecha' es obligatorio", Dialog.type.error);
                    return;
                }
                var objJunta = {
                    NombreJuntas: J_NOMRE,
                    Motivo: J_MOTIVO,
                    FKProyecto: J_PROYECTO,
                    HoraJunta: J_HORA,
                    FechaJunta: J_FECHA
                };
                $.ajax({
                    url: Root + "RolEmpleado/Sugerencia",
                    type: "POST",
                    data: {
                        dataJunta: JSON.stringify(objJunta),
                    },
                    beforeSend: function () {
                        Dialog.show("Buscando y enviando datos al remitente", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("La sugerencia se ha enviado correctamente, espere confirmacion del cliente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al enviar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }
            else {
                $.ajax({
                    url: Root + "RolCliente/Updatedate",
                    type: "POST",
                    data: { Fecha: J_FECHA, hora: J_HORA, id: Rol.Objects.IDJunta },
                    beforeSend: function () {
                        Dialog.show("Mandando nueva fecha", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Fecha enviada, espere confirmacion del empleado", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                                //location.href = '/HumanResources/Persons';
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al enviar, inténtelo de nuevo", Dialog.type.error);
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
        OpenModalTime: function (id) {
            Rol.Objects.IDJunta = id;
            $("#mdlDetail").modal("show");
            Dialog.hide();
        },
        confirm: function (ID) {
            Dialog.show("¿Esta seguro que quiere confirmar Esta fecha?", Dialog.type.question);

            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "RolCliente/Confirmar",
                    type: "POST",
                    data: { id: ID },
                    beforeSend: function () {
                        Dialog.show("Mandando confirmacion de datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            location.reload(true);
                        }
                        else {
                            Dialog.show("Ocurrió un error al enviar mensaje, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        }
    }
}