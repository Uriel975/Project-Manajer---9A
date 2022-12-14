var GlobalClientes = {
    Objects: {
        IDEmpleado: 0
    },
    init: function () {
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()

            if (GlobalClientes.Objects.IDEmpleado == 0) {
                var E_PATERNALSURNAME = $("#txtNombrePro").val();
                var E_MATERNALSURNAME = $("#mensaje").val();

                if (E_PATERNALSURNAME.trim() == "") {
                    Dialog.show("El campo 'Titulo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (E_MATERNALSURNAME.trim() == "") {
                    Dialog.show("El campo 'Mensaje' es obligatorio", Dialog.type.error);
                    return;
                }
                $.ajax({
                    url: Root + "RolCliente/New",
                    type: "POST",
                    data: {
                        CorreoEmpleado: E_PATERNALSURNAME,
                        ContraEmpleado: E_MATERNALSURNAME
                    },
                    beforeSend: function () {
                        Dialog.show("Guardando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Datos registrados", Dialog.type.success);
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
        });
        $(".input-number").on("input", function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    }
    
}