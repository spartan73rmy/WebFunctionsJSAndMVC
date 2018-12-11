//Complex file manager, MVC on server side 
//Use a basic FileManager


        /// <summary>
        /// Retorna la imagen que se encuentra en la ruta a la vista
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Imagen</returns>
        public ActionResult Preview(string file)
        {
            if (System.IO.File.Exists(Path.Combine(photo_path, file)))
            {
                return File(Path.Combine(photo_path, file), "image/jpeg");
            }
            return new HttpNotFoundResult();
        }

        /// <summary>
        /// Guarda Archivos si el checkBox es true
        /// </summary>
        /// <param name="files"></param>
        /// <param name="file_path"></param>
        /// <param name="expediente"></param>
        /// <param name="nombre_empleado"></param>
        private Expediente saveFiles(IList<HttpPostedFileWrapper> files, string file_path, Expediente expediente, string nombre_empleado)
        {
            bool[] check = { expediente.acta_nacimiento, expediente.alta_nss, expediente.carta_no_ant_penales,
                expediente.cert_medico, expediente.comprobante_estudios, expediente.constancia_retencion_infonavit,
                expediente.ine, expediente.sol_empleo};

            string[] names = { "ACTA NACIMIENTO", "ALTA NSS","CARTA DE NO ANTECENDETES PENALES",
                "CERTIFICADO MEDICO", "COMPROBANTE DE ESTUDIOS", "CONSTANCIA DE RETENCION DE INFONAVIT",
            "INE","SOLICITUD DE EMPLEO"};

            //Revisa que por cada check en true y guarda imagen o PDF
            for (int i = 0; i < check.Length; i++)
            {
                var item = files[i];
                var itemE = check[i];
                if (itemE == false)
                    continue;

                string path = FilesManager.saveFile(item, file_path, nombre_empleado + "_" + names[i]);
                switch (i)
                {
                    case 1: expediente.ruta_acta_nacimiento = path; break;
                    case 2: expediente.ruta_alta_nss = path; break;
                    case 3: expediente.ruta_carta_no_ant_penales = path; break;
                    case 4: expediente.ruta_cert_medico = path; break;
                    case 5: expediente.ruta_comprobante_estudios = path; break;
                    case 6: expediente.ruta_constancia_retencion_infonavit = path; break;
                    case 7: expediente.ruta_ine = path; break;
                    case 8: expediente.ruta_sol_empleo = path; break;
                }
            }
            return expediente;
        }

        /// <summary>
        /// Comprueba que sea imagen y la guarda
        /// </summary>
        /// <param name="file"></param>
        /// <param name="photo_path"></param>
        /// <returns>Direccion donde se guarda</returns>
        private string savePhoto(HttpPostedFileBase file, string photo_path, string nombre_empleado)
        {
            if (file != null)
            {
                string[] formats = { ".jpg", ".jpeg", ".png", ".gif" };
                string fileExt = Path.GetExtension(file.FileName);

                if (formats.Contains(fileExt))
                    return FilesManager.saveFile(file, photo_path, nombre_empleado);
            }
            return null;
        }