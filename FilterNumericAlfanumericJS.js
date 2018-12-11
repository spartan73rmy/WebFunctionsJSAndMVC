            function verTecla(e) {
                var charCode = (e.which) ? e.which : e.keyCode;
                console.log(charCode);
                return charCode;
            }


            function soloLetras(event) {
                ;
                verTecla(event);
                console.log("Dentro de Solo letras");
                if (!isValidLetterSpace(event)) {
                    console.log("No es tecla valida");
                    event.preventDefault();
                } console.log("Tecla valida");
            }

            function soloLetrasSinEspacios(event) {
                verTecla(event);
                if (!isLetterWithoutSpace(event)) {
                    event.preventDefault();
                }
            }

            function numerosLetrasSinEspacios(event) {
                verTecla(event);
                if (!isNumberOrLetter(event)) {
                    event.preventDefault();
                }
            }

            function soloNumeros(event) {
                verTecla(event);
                if (!isNumber(event)) {
                    event.preventDefault();
                }
            }
            