//TextBox con retorno a 1 cuando se excede el valor maximo

$('#mes_contrato').on('keypress', function (event) {
                let box = $('#mes_contrato')

                if (box.length >= 1) {
                    box.val("");
                }
                if (!isInRange(event, 49, 54)) {
                    initDateContrato();
                    event.preventDefault();
                }
            });
