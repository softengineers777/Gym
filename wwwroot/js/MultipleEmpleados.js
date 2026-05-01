 let contador = 0;

    function agregarEmpleado() {
        const container = document.getElementById('empleados-container');
        const div = document.createElement('div');
        div.className = 'client-row';
        div.id = `empleados-${contador}`;
        div.innerHTML = `
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label fw-bold">Nombre</label>
                    <input name="empleados[${contador}].nombre" class="form-control" required />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Codigo</label>
                    <input name="empleados[${contador}].Codigo" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">telefono</label>
                    <input name="empleados[${contador}].telefono" type="tel" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="form-label fw-bold">Direccion</label>
                    <input name="empleados[${contador}].direccion" type="text" class="form-control" />
                </div>
                 <div class="col-md-2">
                    <label class="form-label fw-bold">FechaRegistro</label>
                    <input name="empleados[${contador}].FechaRegistro" type="date" class="form-control" />
                </div>
                <div class="col-md-1">
                    <button type="button" class="btn btn-danger remove-row" onclick="eliminarEmpleado(${contador})">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        `;
        container.appendChild(div);
        contador++;
    }

    function eliminarEmpleado(id) {
        const elemento = document.getElementById(`empleados-${id}`);
        if (elemento) {
            elemento.remove();
        }
    }

    // Agregar un proveedor por defecto al cargar la página
    window.onload = function() {
        agregarEmpleado();
    };