 let contador = 0;

    function agregarCliente() {
        const container = document.getElementById('clientes-container');
        const div = document.createElement('div');
        div.className = 'client-row';
        div.id = `cliente-${contador}`;
        div.innerHTML = `
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label fw-bold">Nombre</label>
                    <input name="clientes[${contador}].Nombre" class="form-control" required />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Teléfono</label>
                    <input name="clientes[${contador}].Telefono" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Email</label>
                    <input name="clientes[${contador}].email" type="email" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="form-label fw-bold">Fecha Registro</label>
                    <input name="clientes[${contador}].fecha_registro" type="date" class="form-control" />
                </div>
                <div class="col-md-1">
                    <button type="button" class="btn btn-danger remove-row" onclick="eliminarCliente(${contador})">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        `;
        container.appendChild(div);
        contador++;
    }

    function eliminarCliente(id) {
        const elemento = document.getElementById(`cliente-${id}`);
        if (elemento) {
            elemento.remove();
        }
    }

    // Agregar un cliente por defecto al cargar la página
    window.onload = function() {
        agregarCliente();
    };