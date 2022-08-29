listar();

function listar() {

    $.get("Area/listarArea", function (data) {

        crearListado(["ID Area", "NOMBRE"], data);
    });

}

function crearListado(arrayColumnas, data) {

    var contenido = "";
    contenido += "<table id='tablas' class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";

    for (var i = 0; i < arrayColumnas.length; i++) {

        contenido += "<td>";
        contenido += arrayColumnas[i];
        contenido += "</td>";
    }

    //añadir columna manual "accion"
    contenido += "<td>ACCIONES</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    var llaves = Object.keys(data[0]);//array con las propiedades idarea, nombre,etc
    contenido += "<tbody>";

    for (var i = 0; i < data.length; i++) {

        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {
            var valorLLaves = llaves[j];
            contenido += "<td>";
            contenido += data[i][valorLLaves];
            contenido += "</td>";
        }
        var llaveId = llaves[0];

        contenido += "<td>";
        contenido += "<button class='btn btn-primary' onclick='abrirModal(" + data[i][llaveId] + ")' data-toggle='modal' data-target='#myModal'><i class='glyphicon glyphicon-edit'></i></button> "
        contenido += "<button class='btn btn-danger' onclick='eliminar(" + data[i][llaveId] + ")'><i class='glyphicon glyphicon-trash'></i></button>"
        contenido += "</td>";
        contenido += "</tr>";

    }

    contenido += "</tbody>";
    contenido += "</table>";
    document.getElementById("tabla").innerHTML = contenido;
    $("#tablas").dataTable({

        searching: false
    });


}

function eliminar(id) {

    var frm = new FormData();
    frm.append("id_area", id);
    if (confirm("¿Desea guardar los datos?") == 1) {

        $.ajax({
            type: "POST",
            url: "Area/eliminarArea",
            data: frm,
            contentType: false,
            processData: false,
            success: function (data) {
                if (data != 0) {

                    listar();
                    alert("Se ejecuto correctamente");
                    document.getElementById("btnCancelar").click();

                } else {

                    alert("ocurrio un error");
                }



            }
        })

    } else { }

}

function abrirModal(id) {

    var controlesObligatorio = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorio.length;
    for (var i = 0; i < ncontroles; i++) {

        controlesObligatorio[i].parentNode.classList.remove("error");
    }

    if (id == 0) {//se compara si es igual a 0, se presiono el boton agregar y abre el popup

        borrarDatos();
    } else { //si se presiona el botono editar se llenan los datos del popup

        $.get("Area/recuperarDatos/?id=" + id, function (data) {

            document.getElementById("txtIdArea").value = data[0].id_area;
            document.getElementById("txtNombre").value = data[0].nombre;
        })
    }

    //alert(id);
}

function borrarDatos() {//funcion para limpiar el los datos del popup cuando presionemos el boton agregar

    var controles = document.getElementsByClassName("borrar");
    var ncontroles = controles.length;
    for (var i = 0; i < ncontroles; i++) {

        controles[i].value = "";
    }
}

function Agregar() {

    if (datosObligatorios() == true) {

        var frm = new FormData();
        var id = document.getElementById("txtIdArea").value;
        var nombre = document.getElementById("txtNombre").value;
        frm.append("id_area", id);
        frm.append("nombre", nombre);

        if (confirm("¿Desea guardar los datos?") == 1) {

            $.ajax({
                type: "POST",
                url: "Area/guardarDatos",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {

                        listar();
                        alert("Se ejecuto correctamente");
                        document.getElementById("btnCancelar").click();

                    } else {

                        alert("ocurrio un error");
                    }



                }
            })

        } else { }


    }

}

function datosObligatorios() {

    var exito = true;
    var controlesObligatorio = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorio.length;
    for (var i = 0; i < ncontroles; i++) {
        if (controlesObligatorio[i].value == "") { //se compara el txtbox si esta vacio 

            exito = false;
            controlesObligatorio[i].parentNode.classList.add("error");
        }
        else {
            controlesObligatorio[i].parentNode.classList.remove("error");
        }

    }
    return exito;
}