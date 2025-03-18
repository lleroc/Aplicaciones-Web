class DetalleFactura {

    constructor() {
    }

    listaClientes() {
        var html = "<option value=0>Seleccione un opcion</option>"
        $.get("../../clientes/ListaClientes", (listaclientes) => {
            console.log(listaclientes)
            $.each(listaclientes, (index, valor) => {
                html += `<option value=${valor.id}>${valor.nombre}</option>` 
            })
            $("#listaClientes").html(html)
        })
    }

}