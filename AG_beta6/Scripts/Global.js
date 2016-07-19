            $('.valida-rut').Rut({
                digito_verificador: '.valida-digito',
                on_error: function () { alert('Rut incorrecto'); }
            });