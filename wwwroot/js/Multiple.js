 let contador = 0;

    function agregarProveedor() {
        const container = document.getElementById('proveedores-container');
        const div = document.createElement('div');
        div.className = 'client-row';
        div.id = `proveedor-${contador}`;
        div.innerHTML = `
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label fw-bold">Nombre</label>
                    <input name="proveedores[${contador}].Nombre" class="form-control" required />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Apellido</label>
                    <input name="proveedores[${contador}].Apellido" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">telefono</label>
                    <input name="proveedores[${contador}].telefono" type="tel" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="form-label fw-bold">Direccion</label>
                    <input name="proveedores[${contador}].direccion" type="text" class="form-control" />
                </div>
                 <div class="col-md-2">
                    <label class="form-label fw-bold">FechaRegistro</label>
                    <input name="proveedores[${contador}].FechaRegistro" type="date" class="form-control" />
                </div>
                <div class="col-md-1">
                    <button type="button" class="btn btn-danger remove-row" onclick="eliminarProveedor(${contador})">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        `;
        container.appendChild(div);
        contador++;
    }

    function eliminarProveedor(id) {
        const elemento = document.getElementById(`proveedor-${id}`);
        if (elemento) {
            elemento.remove();
        }
    }

    // Agregar un proveedor por defecto al cargar la página
    window.onload = function() {
        agregarProveedor();
    };