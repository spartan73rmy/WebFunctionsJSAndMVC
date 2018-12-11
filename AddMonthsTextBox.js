//Suma meses a la fecha en TextBox

$('#mes_contrato').on('keyup', function (event) {
                let box = $('#mes_contrato');
                let cantMonth = parseInt(box.val());

                if (box.length == 1 && !isNaN(cantMonth)) {
                    let fechaActual = new Date();
                    let registerDate = parseDate($('#Empleado_fecha_registro').val(), $('#Empleado_fecha_registro').val());

                    //alert($('#Empleado_fecha_registro').val());
                    //alert(registerDate);
                    //alert(registerDate.getDay());

                    //Se iguala a la fecha de Ingreso
                    fechaActual = registerDate;

                    //TODO tiene un bug, suma meses pero agrega mas dias 31/02 + 1Mes = 1/04
                    fechaActual.setMonth(registerDate.getMonth() + cantMonth);

                    let day = ("0" + fechaActual.getDate()).slice(-2);
                    let month = ("0" + (fechaActual.getMonth() + 1)).slice(-2);
                    let today = fechaActual.getFullYear() + "-" + (month) + "-" + (day);
                    // alert(today);
                    $('#Contrato_vigencia').val(today);
                }
            });
