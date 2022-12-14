var Project = {
    Objects: {
        IDProyecto: 0
    },
    init: function () {
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()

            var P_PROJECTNAME = $("#txtNombrePro").val();
            var P_COMPANYNAME = $("#cmbEmpresa").val();
            var P_DATEOFDELIVERY = $("#txtFechaEntrega").val();
            var P_PRIORITY = $("#cmdPrioridad").val();
            var P_DESCRIPTION = $("#mensaje").val();
            var P_MAXIMUMEMPLOYEES = $("#cmdmaxEm").val();

            if (Project.Objects.IDProyecto == 0) {
                

                if (P_PROJECTNAME.trim() == "") {
                    Dialog.show("El campo 'nombre del proyecto' es obligatorio", Dialog.type.error);
                    return;
                }
                if (P_COMPANYNAME.trim() == "") {
                    Dialog.show("El campo 'Nombre de la empresa' es obligatorio", Dialog.type.error);
                    return;
                }
                if (P_DATEOFDELIVERY.trim() == "") {
                    Dialog.show("El campo 'Fecha de entrega' es obligatorio", Dialog.type.error);
                    return;
                }
                if (P_PRIORITY.trim() == "") {
                    Dialog.show("El campo 'Prioridad' es obligatorio", Dialog.type.error);
                    return;
                }
                if (P_DESCRIPTION.trim() == "") {
                    Dialog.show("El campo 'Descripcion del proyecto' es obligatorio", Dialog.type.error);
                    return;
                }
                if (P_MAXIMUMEMPLOYEES.trim() == "") {
                    Dialog.show("El campo 'Maximo de empleados' es obligatorio", Dialog.type.error);
                    return;
                }
                var objProyecto = {
                    NombreProyecto: P_PROJECTNAME,
                    FKCliente: P_COMPANYNAME,
                    FechaLimite: P_DATEOFDELIVERY,
                    Prioridad: P_PRIORITY,
                    Descripcion: P_DESCRIPTION,
                    Limite: P_MAXIMUMEMPLOYEES
                };
                $.ajax({
                    url: Root + "Proyectos/New",
                    type: "POST",
                    data: {
                        dataproyecto: JSON.stringify(objProyecto),
                    },
                    beforeSend: function () {
                        Dialog.show("Guardando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Se agrego un nuevo proyecto", Dialog.type.success);
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
                    url: Root + "Proyectos/Update",
                    type: "POST",
                    data: { nombre: P_PROJECTNAME, descripcion: P_DESCRIPTION, prioridad: P_PRIORITY, limite: P_MAXIMUMEMPLOYEES, folio: Project.Objects.IDProyecto },
                    beforeSend: function () {
                        Dialog.show("Actualizando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Proyecto actualizado correctamente", Dialog.type.success);
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
        //$(".input-number").on("input", function () {
        //    this.value = this.value.replace(/[^0-9]/g, '');
        //});
    },
    evts: {
        getProyeInfo: function (id) {
            Project.Objects.IDProyecto = id;
            $("#mdlDetail").modal("show");
            Dialog.hide();
        },
        updateStatus: function (id, status) {
            if (status != "4") {
                Dialog.show("¿Estás seguro que quiere Deshabilitar este proyecto?", Dialog.type.question);
            }
            else {
                Dialog.show("¿Estás seguro que quiere habilitar este proyecto?", Dialog.type.question);
            }
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Proyectos/UpdateStatus",
                    type: "POST",
                    data: { id: id, estatus: status },
                    beforeSend: function () {
                        Dialog.show("Desactivando proyecto", Dialog.type.progress);
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
        } ,
        asignarProyecto: function (id, folio,proyecto, actual) {
                Dialog.show("¿Deseas asignar este empleado a este proyecto?", Dialog.type.question);
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Proyectos/AsignarProyecto",
                    type: "POST",
                    data: { IdEmpleado: id, folioproyecto: folio, projecName: proyecto, numeroActual: actual},
                    beforeSend: function () {
                        Dialog.show("Uniendo al nuevo empleado al proyecto", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("El empleado se añadio con éxito", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Este empleado ya se encuetra en el proyecto. No puedes agregarlo dos veces", Dialog.type.error);
                        }
                    }
                });
            });
        },

    }
}