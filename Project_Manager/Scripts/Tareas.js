var PropTask = {
    Objects: {
        Folio: 0
    },
    evts: {
        openModal: function (id) {
            PropTask.Objects.Folio = id;
            $("#mdlDetail").modal("show");
            Dialog.hide();
        },
        SaveTask: function () {
            var T_NAME = $("#txtTitulo").val();
            var T_DESCRIPTION = $("#mensaje").val();
            if (T_NAME.trim() != "" && T_DESCRIPTION.trim() != "") {
                Dialog.show("¿Estas seguro de agregar esta tarea?", Dialog.type.question);

                $(".sem-dialog").on("done", function () {
                    $.ajax({
                        url: Root + "Proyectos/NewTask",
                        type: "POST",
                        data: { Nombre: T_NAME, DESCRI: T_DESCRIPTION, fkproyecto: PropTask.Objects.Folio },
                        beforeSend: function () {
                            Dialog.show("Guardando tarea", Dialog.type.progress);
                        },
                        success: function (response) {
                            if (response > 0) {
                                location.reload(true);
                            }
                            else {
                                Dialog.show("Titulo demasiado largo, Intente de nuevo", Dialog.type.error);
                            }
                        }
                    });
                });
            }
            else {
                Dialog.show("Es necesario llenar todos los campos", Dialog.type.error);
                return;
            }

           
        },
        DeleteTask: function (id, estatus) {
            if (estatus == 0) {
                Dialog.show("¿Estas seguro de elimnar esta tarea? NO PODRAS RECUPERARLO", Dialog.type.question);

                $(".sem-dialog").on("done", function () {
                    $.ajax({
                        url: Root + "Proyectos/NewTask",
                        type: "POST",
                        data: { IdTarea: id },
                        beforeSend: function () {
                            Dialog.show("Elimando la tarea", Dialog.type.progress);
                        },
                        success: function (response) {
                            if (response > 0) {
                                location.reload(true);
                            }
                            else {
                                Dialog.show("Ocurrió un error al intentar guardar, inténtelo de nuevo", Dialog.type.error);
                            }
                        }
                    });
                });
            }
            else {
                Dialog.show("No puedes eliminar esta tarea porqué esta sinedo trabajada por algun empleado ", Dialog.type.error);
                return;
            }
            
        },
        TakeTask: function (tarea) {
            Dialog.show("¿Deseas agregar esta tarea a tu lista de tareas?", Dialog.type.question);
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Proyectos/TakeTask",
                    type: "POST",
                    data: { Id: tarea},
                    beforeSend: function () {
                        Dialog.show("Mandando datos a tu perfil", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            location.reload(true);
                        }
                        else {
                            Dialog.show("Ocurrió un error al intentar guardar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        },
        DetailsTask: function (folio, id) {
            Dialog.show("¿Desea ver?", Dialog.type.question);
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Proyectos/DetallesTask",
                    type: "POST",
                    data: { folio: folio, id: id },
                    beforeSend: function () { },
                    success: function (response) {
                        if (response > 0) {
                            document.location.href = '../Proyectos/DetallesTask';
                        } else {
                            Dialog.show("Algo A Fallado", Dialog.type.error);
                        }
                    }
                });
            });
        },
    }
}