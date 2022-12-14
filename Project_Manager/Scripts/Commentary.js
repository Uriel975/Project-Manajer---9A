var Commentary = {
    init: function () {
        $("#formcommentary").on("submit", function (e) {
            e.preventDefault()

            var Mensaje = $("#mensaje").val();
            var Tarea = $("#tarea").val();
            var Folio = $("#proyecto").val();

            if (Mensaje.trim() == "") {
                Dialog.show("Nada que enviar", Dialog.type.error);
                return;
            } if (Tarea.trim() == "") {
                Dialog.show("Error Fatal, recargue la pagina", Dialog.type.error);
                return;
            } if (Folio.trim() == "") {
                Dialog.show("Error Fatal, recargue la pagina", Dialog.type.error);
                return;
            }
            $.ajax({
                url: Root + "Proyectos/NewCom",
                type: "POST",
                data: { comentario: Mensaje, tarea:Tarea, proyecto:Folio},
                beforeSend: function () {
                },
                success: function (response) {
                    if (response > 0) {
                        location.reload(true);
                    }
                    else {
                        Dialog.show("Fallo Fatal", Dialog.type.error);
                    }
                }
            });
        });
    },
}