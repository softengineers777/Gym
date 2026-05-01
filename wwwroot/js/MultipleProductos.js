 let contador = 0;

    function agregarEmpleado() {
        const container = document.getElementById('producto-container');
        const div = document.createElement('div');
        div.className = 'client-row';
        div.id = `producto-${contador}`;
        div.innerHTML = `
            <div class="row">
              
                <div class="col-md-3">
                    <label class="form-label fw-bold">Nombre</label>
                    <input name="productos[${contador}].nombre" class="form-control" placeholder="Nombre del Producto" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Categoria</label>
                    <input name="productos[${contador}].categoria" type="tel" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="form-label fw-bold">Fecha Registro</label>
                    <input name="productos[${contador}].fecha_registro" type="date" class="form-control" />
                </div>
                
                
            </div>
        `;
        container.appendChild(div);
        contador++;
    }

    function eliminarEmpleado(id) {
        const elemento = document.getElementById(`productos-${id}`);
        if (elemento) {
            elemento.remove();
        }
    }

    // Agregar un proveedor por defecto al cargar la página
    window.onload = function() {
        agregarEmpleado();
    };