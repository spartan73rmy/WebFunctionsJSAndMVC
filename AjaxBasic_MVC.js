                //Peticion Ajax Basica
                $.ajax({
                    url: "/Empleado/GetCentro_Acopio",
                    type: "POST",
                    //Data para pasar y se recibe en lado servidor
                    data: { dato },
                    dataType: 'JSON',
                    success: function (data) {
                        $.each(data, function (index, registro) {
                            //alert(registro.Value);
                            $('#Empleado_id_centro_acopio').append('<option value=' + registro.Value + '>' + registro.Text + '</option>');
                        });
                    }, error: function (data) {
                        alert('Error al llenar centros de acopio ' + parseInt(data));
                    }
                });
                $('#Empleado_id_centro_acopio').prop("disabled", false);
            });



             [HttpPost]
        public JsonResult GetCentro_Acopio(int dato)
        {
            var result = new List<Centro_Acopio>();
            result.Clear();
            try
            {
                result = db.Centro_Acopio.Where(m => m.id_zona == dato).ToList();

                var resp = result.Select(x => new SelectListItem()
                {
                    Value = x.id_centro_acopio.ToString(),
                    Text = x.nombre_centro
                }).ToList();

                resp.Insert(0, new SelectListItem() { Value = "", Text = "Elija una opcion" });

                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Log.Write(e.Message, "Error");
                return null;
            }
        }