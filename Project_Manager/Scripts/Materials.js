var Materials = {
    Pagination: null,
    PaginateFromView: function (Records, Pages, Limit) {
        if (Pages > 0) {
            Materials.Pagination.LimitPerPage = Limit;
            Materials.Pagination.TotalRecords = Records;
            Materials.Pagination.DisplayPages = 5;
            Materials.Pagination.Pages = Pages;
            Materials.Pagination.Create();
            Materials.Pagination.InsertAt("pagination-box");
            Materials.Pagination.StartListener();
        }
        else {
            Materials.Pagination.Dispose();
        }
    },
    Objects:
    {
        MATID: 0
    },
    Events: {
        parseFileFromElement: function (Element, Callback) {
            if (Element.files && Element.files[0]) {
                var FR = new FileReader();
                FR.addEventListener("load", function (e) {
                    //document.getElementById("img").src = e.target.result;
                    Callback(e);
                });
                FR.readAsDataURL(Element.files[0]);
            }
        },
        Remove: function (id) {
            Dialog.show("¿Está seguro(a) que quiere eliminar este material?", Dialog.type.question);
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Materiales/Remove",
                    type: "POST",
                    data: { idMaterial: id },
                    beforeSend: function () {
                        Dialog.show("Eliminando material", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Eliminado correctamente");
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al eliminar el material, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        },
        SowInfoMaterial: function (MATID) {
            Materials.Objects.MATID = MATID;
            $.ajax({
                url: Root + "Materiales/GetMaterialesEdit",
                type: "GET",
                data: { idMaterials: MATID },
                beforeSend: function () {
                    Dialog.show("Cargando Datos", Dialog.type.progress);
                },
                success: function (response) {
                    if (response.id > 0) {
                        $("#txtNombre").val(response.nombre);
                        $("#txtPrecio").val(response.precio);
                        $("#face-box").html("<img src=\"" + Root + "Materiales/ImagenThumb?idMat=" + response.id + "\" class=\"img-fluid\">");
                        Dialog.hide();
                    }
                }
            });

            $("#mdlMateriales").modal({
                show: true,
                backdrop: 'static',
                keyboard: false
            });
        },
    },
    init: function () {
        Materials.Pagination = new Pagination();
        $(document).on("Pagination.PageChange", function (e) {
            Materials.Filter(e.Page);
        });
        $("[data-toggle=biometric-select]").on("change", function () {
            var TargetResult = $(this).data("target");
            var Element = this;
            if (Element.value.toString().toLowerCase().includes("jpg") || Element.value.toString().toLowerCase().includes("jpeg")) {
                Materials.Events.parseFileFromElement(Element, function (e) {
                    $(TargetResult).html("<img src=\"" + e.target.result + "\" class=\"img-fluid\">");
                });
            }
            //this.value = null;
        });
        $("[data-toggle=biometric-clear]").on("click", function () {
            var Target = $(this).data("target");
            var Button = this;
            if ($(Target).find("img").length) {
                $(Target).html(null);
                $(Button).parent().find("input[type=file]").val(null);
            }
        });
        $("#frmMateriales").on("submit", function (e) {
            e.preventDefault();
            debugger
            var ImgAct = false;
            var thumb = $("#face-box").find("img").length > 0 ? $("#face-box").find("img").attr("src") : null;
            if (thumb != null) {
                if (thumb.toString().includes("base64")) {
                    var SplitSrc = thumb.toString().split("base64,");
                    thumb = SplitSrc[1];
                    ImgAct = true;
                }
            }

            var R_Nombre = $("#txtNombre").val();
            var R_Precio = $("#txtPrecio").val();

            if (R_Nombre.trim() == "") {
                Dialog.show("El Campo 'Nombre' es obligatorio", Dialog.type.error);
                return;
            }
            if (R_Precio.trim() == "") {
                Dialog.show("El Campo 'Precio' es obligatorio", Dialog.type.error);
                return;
            }

            if (thumb != null) {
                if (ImgAct == false) {
                    thumb = null;
                }
                var SearchRequest = {
                    id: Materials.Objects.MATID,
                    nombre: R_Nombre,
                    precio: R_Precio,
                    thumb: thumb
                };
                if (Materials.Objects.MATID != "0") {
                    $.ajax({
                        url: Root + "Materiales/Edit",
                        type: "POST",
                        data: JSON.stringify(SearchRequest),
                        beforeSend: function () {
                            Dialog.show("Actualizando", Dialog.type.progress);
                        },
                        success: function (response) {
                            console.log(response);
                            if (response == 1) {
                                Dialog.show("Actualizado correctamente", Dialog.type.success);
                                $(".sem-dialog").on("done", function () {
                                    location.reload(true);
                                });
                            }
                            else {
                                Dialog.show("Ocurrió un error al actualizar los datos, inténtelo de nuevo", Dialog.type.error);
                            }
                        }
                    });
                }
                else {
                    $.ajax({
                        url: Root + "Materiales/SaveMaterial",
                        type: "POST",
                        data: JSON.stringify(SearchRequest),
                        beforeSend: function () {
                            Dialog.show("Registrando", Dialog.type.progress);
                        },
                        success: function (response) {
                            console.log(response);
                            if (response == 1) {
                                Dialog.show("Guardado correctamente", Dialog.type.success);
                                $(".sem-dialog").on("done", function () {
                                    location.reload(true);
                                });
                            }
                            else {
                                Dialog.show("Ocurrió un error al guardar los datos, inténtelo de nuevo", Dialog.type.error);
                            }
                        }
                    });
                }
            }
            else {
                Dialog.show("Por favor seleccione una imagen de referencia", Dialog.type.error);
            }
        });
        $("#mdlMateriales").on("hidden.bs.modal", function () {
            $("#frmMateriales")[0].reset();
            $("#face-box").html(null);
        });
    },
    Filter: function (Page) {
        $.ajax({
            url: Root + "Materials/PaginateMaterials",
            type: "GET",
            data: { Page: Page },
            beforeSend: function () {
                Dialog.show("Obteniendo registros", Dialog.type.progress);
            },
            success: function (response) {
                if (response.Records > 0) {
                    $("#products_result").find("table tbody").html(null);
                    $.each(response.Data, function (i, oMaterials) {
                        var edit = "<button class=\"item\" onclick=\"Materials.Events.SowInfoMaterial('" + oMaterials.Id + "')\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"\" data-original-title=\"Editar\">" +
                            "<i class=\"zmdi zmdi-edit\"></i>" +
                            "</button>";
                        var remove = "<button class=\"item\" onclick=\"Materials.Events.Remove('" + oMaterials.Id + "')\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"\" data-original-title=\"Eliminar\">" +
                            "<i class=\"zmdi zmdi-delete\"></i>" +
                            "</button>";
                        $("#products_result").find("table tbody").append("<tr>" +
                            "<td>" + oMaterials.nombre + "</td> " +
                            "<td>" + oProduct.precio + "</td> " +
                            "<td> <div class=\"table-data-feature\"> " +
                            edit +
                            remove +
                            "</div></td > " +
                            "</tr>");
                    });
                    if (response.Pages > 0) {
                        Customers.Pagination.LimitPerPage = response.Limit;
                        Customers.Pagination.TotalRecords = response.Records;
                        Customers.Pagination.DisplayPages = 5;
                        Customers.Pagination.Pages = response.Pages;
                        Customers.Pagination.Create();
                        Customers.Pagination.InsertAt("pagination-box");
                        Customers.Pagination.StartListener();
                    }
                    else {
                        Customers.Pagination.Dispose();
                    }
                    Dialog.hide();
                }
            },
            error: function () {
                Dialog.show("Ocurrió un error al obtener la respuesta del servidor, inténtelo de nuevo", "Error al obtener datos", Dialog.type.error);
            }
        });
    },
};