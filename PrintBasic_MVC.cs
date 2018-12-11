//Vista principal retorna las opciones a imprimir
 public ActionResult Print(Empleado Modelo)
        {
            return View(Modelo);
        }

//Verifica que opcion es necesaria imprimir 
        [HttpPost, ActionName("Print")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PrintConfirmed(Empleado empleado, string contrato, string convenio)
        {
            try
            {
                if (empleado == null)
                    return HttpNotFound();

                empleado = await db.Empleado.Where(m => m.id_empleado == empleado.id_empleado).Include(m => m.Centro_Acopio.Zonas).FirstOrDefaultAsync();

                if (empleado == null)
                    return HttpNotFound();

                if (!string.IsNullOrEmpty(convenio))
                    printContratoConfidecialidad(empleado);

                //Join con empleados para obtener sueldo,puesto
                if (!string.IsNullOrEmpty(contrato))
                {
                    switch (empleado.Empleado_Contrato.id_contrato)
                    {
                        case Determinado:
                            printDeterminatedContract(empleado);
                            break;
                        case Indeterminado:
                            //El formato es el mismo, se cambia la fecha de finalizacion
                            printIndeterminatedContract(empleado);
                            break;
                        case Temporada:
                            printSeasonalContract(empleado);
                            break;
                        default:
                            Log.Write("No se encuentra el contrato", "Error");
                            return HttpNotFound();
                    }
                }
                //Solo flush
                return null;
            }
            catch (Exception e)
            {
                Log.Write(e.Message, "Error");
                return RedirectToAction("Index", "Empleado");
            }
        }

        //Obtiene la vista y la hace flush
        private ActionResult printBaja(EmpleadoDeleteViewModel Modelo)
        {
            Motivo_Despido motivo = db.Motivo_Despido.Find(Modelo.Empleado_Historial.id_motivo);

            PrintBajaEmpleadoViewModel printBajaEmpleado = new PrintBajaEmpleadoViewModel()
            {
                fecha_registro = Modelo.Empleado.fecha_registro.ToLongDateString(),
                fecha_salida = Modelo.Empleado_Historial.fecha_salida.ToShortDateString(),
                motivo_baja = motivo.nombre_motivo,
                id_empleado = Modelo.Empleado.id_empleado,
                nombre_completo_empleado = Modelo.Empleado.nombre + " " + Modelo.Empleado.apellido_paterno + " " + Modelo.Empleado.apellido_materno,
                empresa = Modelo.Empleado.Empresa.nombre_empresa,
                puesto = Modelo.Empleado.Puesto.nombre_puesto,
                departamento = Modelo.Empleado.Puesto.Departamentos.nombre_departamentos,
                recontratacion = Modelo.Empleado_Historial.puede_recontratarse,
                comentario = Modelo.Empleado_Historial.comentario_recontratado
            };

            HtmlToPdf converter = new HtmlToPdf();

            //Seguridad
            //converter.Options.HttpCookies.Add(FormsAuthentication.FormsCookieName,Request.Cookies[FormsAuthentication.FormsCookieName].Value);        
            converter.Options.PdfCompressionLevel = PdfCompressionLevel.Normal;
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginBottom = 10;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;
            converter.Options.MarginTop = 10;

            //Obtener el html puro, llama al controlador y pasa el modelo
            string HTML = ViewToString("PrintDelete", printBajaEmpleado);

            //Inicializar Ruta base para deducir CSS e inicializa nombre de PDF
            var baseUrl = "http://localhost:55129/";
            string nombre = "Contrato_Confidencialidad_" + printBajaEmpleado.nombre_completo_empleado + ".pdf";

            //Se crea el Pdf del html y usa la url base para deducir CSS 
            PdfDocument doc = converter.ConvertHtmlString(HTML, baseUrl);
            doc.Save(System.Web.HttpContext.Current.Response, true, nombre);

            // flush del stream
            doc.Close();

            return null;
        }

//Retorna la vista
        public ActionResult PrintDelete(PrintBajaEmpleadoViewModel Modelo)
        {
            return View(Modelo);
        }