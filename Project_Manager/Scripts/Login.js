var ValidadLogin = {
    init: function () {
        $("#formularioInicio").on("submit", function (e) {
            e.preventDefault()

            var L_USER = $("#username").val();
            var L_PASS = $("#pass").val();

            if (L_USER.trim() == "") {
                Dialog.show("El campo 'Usuario' es obligatorio", Dialog.type.error);
                return;
            }
            if (L_PASS.trim() == "") {
                Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                return;
            }
            $.ajax({
                url: Root + "Login/Validar",
                type: "POST",
                data: { usuario: L_USER, contraseña: L_PASS },
                beforeSend: function () {
                },
                success: function (response) {
                    if (response > 0) {
                        document.location.href = '../Admin/Index';
                    }
                    else {
                        Dialog.show("Usuario y/o Contraseña Invalida", Dialog.type.error);
                    }
                }
            });

        });
    },
}