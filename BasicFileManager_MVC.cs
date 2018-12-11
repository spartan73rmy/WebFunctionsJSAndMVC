//Basic FileManager use ComplexFileManager to implementate type of acept files

 public static class FilesManager
    {
        /// <summary>
        /// Busca todos los archivos por el ID de empleado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns>Vector de direcciones completas</returns>
        public static FileInfo[] findFile(int id, string path)
        {
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(path);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(id + "*_*");
            return filesInDir;
        }

        /// <summary>
        /// Elimina cualquier archivo si este existe
        /// </summary>
        /// <param name="file"></param>
        /// <returns>true si se elimino</returns>
        public static bool deleteFiles(string file)
        {
            if (System.IO.File.Exists(file)) { System.IO.File.Delete(file); return true; }

            return false;
        }

        /// <summary>
        /// Guarda archivo con algun nombre diferente al original
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path_origin"></param>
        /// <param name="file_name"></param>
        /// <returns>Direccion donde se almacena</returns>       
        public static string saveFile(HttpPostedFileBase file, string path_origin, string file_name)
        {
            if (!Directory.Exists(path_origin))
                Directory.CreateDirectory(path_origin);

            file.SaveAs(Path.Combine(path_origin, file.FileName));

            var data = new byte[file.ContentLength];
            file.InputStream.Read(data, 0, file.ContentLength);
            var path = Path.Combine(path_origin);
            var filename = Path.Combine(path, file_name + Path.GetExtension(file.FileName));
            System.IO.File.WriteAllBytes(Path.Combine(path, filename), data);
            return filename;
        }

        //public static string saveFile(HttpPostedFileBase file, string path_origin, string base_name)
        //{
        //    if (!Directory.Exists(path_origin))
        //        Directory.CreateDirectory(path_origin);

        //    file.SaveAs(Path.Combine(path_origin, base_name + "_" + Path.GetFileName(file.FileName)));

        //    var data = new byte[file.ContentLength];
        //    file.InputStream.Read(data, 0, file.ContentLength);
        //    var path = Path.Combine(path_origin);
        //    var filename = Path.Combine(path, base_name + "_" + Path.GetFileName(file.FileName));
        //    System.IO.File.WriteAllBytes(Path.Combine(path, filename), data);
        //    return filename;
        //}

        /// <summary>
        /// Guarda el archivo con el nombre original
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path_origin"></param>
        /// <returns>Direccion donde se almacena</returns>
        public static string saveFile(HttpPostedFileBase file, string path_origin)
        {
            if (!Directory.Exists(path_origin))
                Directory.CreateDirectory(path_origin);

            file.SaveAs(Path.Combine(path_origin, Path.GetFileName(file.FileName)));

            var data = new byte[file.ContentLength];
            file.InputStream.Read(data, 0, file.ContentLength);
            var path = Path.Combine(path_origin);
            var filename = Path.Combine(path, Path.GetFileName(file.FileName));
            System.IO.File.WriteAllBytes(Path.Combine(path, filename), data);
            return filename;
        }

    }