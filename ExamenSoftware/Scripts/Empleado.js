

listar();
llenarComboPopup();
function listar() {

    $.get("Empleado/listarEmpleado", function (data) {

        crearListado(["ID EMPLEADO","NOMBRE","APELLIDO PATERNO","EMAIL", "AREA"],data);
    });

}

function llenarComboPopup() {

    $.get("Empleado/listarArea", function (data) {

        //se manda llamar la funcion con el json "data" y el control "document.getelementbyid
        //llenarCombo(data, document.getElementById("cboSexo"), true);
        llenarCombo(data, document.getElementById("cboAreaPopup"), true);
    })

}

function llenarCombo(data, control, primerElemento) {

    var contenido = "";

    if (primerElemento == true) {

        contenido += "<option value=''>";
        contenido += "--Seleccione--";
        contenido += "</option>";
    }
    for (var i = 0; i < data.length; i++) {

        contenido += "<option value='" + data[i].IID + "'>";
        contenido += data[i].nombre;
        contenido += "</option>";
    }

    control.innerHTML = contenido;


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
    var llaves = Object.keys(data[0]);//array con las propiedades idalumnos, nombre,etc
    
    contenido += "<tbody>";

    for (var i = 0; i < data.length; i++) {

        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {
            var valorLLaves = llaves[j];
            contenido += "<td>";
            contenido += data[i][valorLLaves];
            contenido += "</td>";
        }
        contenido += "<td>";
        contenido += "<button class='btn btn-primary' data-toggle='modal' data-target='#myModal'><i class='glyphicon glyphicon-edit'></i></button> "
        contenido += "<button class='btn btn-danger'><i class='glyphicon glyphicon-trash'></i></button>"
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