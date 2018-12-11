//Retornan el reder de una vista en MVC como html puro, es necesario hacer referencia a los CSS

   /// <summary>
        /// Crea un controlador y un request falso
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns>HTML puro de una vista si existe, de lo contrario error</returns>
        protected string ViewToString(string viewName, object model = null)
        {
            ControllerContext controllerContext = new ControllerContext(Request.RequestContext, this);

            return ViewToString(controllerContext, ViewEngines.Engines.FindView(controllerContext, viewName, null)
                ?? throw new FileNotFoundException("View cannot be found."), model);
        }

        /// <summary>
        /// Hace un request falso y renderiza la vista + model
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="viewEngineResult"></param>
        /// <param name="model"></param>
        /// <returns>Retorna la vista renderizada</returns>
        private string ViewToString(ControllerContext controllerContext, ViewEngineResult viewEngineResult, object model)
        {
            using (StringWriter writer = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewEngineResult.View,
                    new ViewDataDictionary(model),
                    new TempDataDictionary(),
                    writer
                );

                viewEngineResult.View.Render(viewContext, writer);

                return writer.ToString();
            }
        }