using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EasyPayPaquetes
{
    class dbconx
    {
        SqlConnection conx = new SqlConnection("Data Source=DESKTOP-AUAIEV6;Initial Catalog=easypay_paquetes;Integrated Security=True;");
        public string cunsultaDB(string codPaquete)
        {
            string verifOrden= "select * from ordenes where cod_paquete_orden ='" + codPaquete + "'";
            string paquete = "select * from inventario_paquetes where cod_paquete ='" + codPaquete + "'";
            
            string respuesta;
            try
            {
                conx.Open();
                DataTable dataTableOrdenes = genSel(verifOrden, conx);            
                if(dataTableOrdenes.Rows.Count == 0)
                {
                    DataTable dataTablePaq= genSel(paquete, conx);
                    if (dataTablePaq.Rows.Count > 0)
                    {
                        string insercionOrden = consultaOrden(codPaquete);
                        if (insercionOrden == "true")
                        {
                            respuesta = "exito";                             
                        }
                        else
                        {
                            respuesta = "errorIns" + insercionOrden;
                        }                        
                    }
                    else
                    {
                        respuesta = "noValido";
                    }
                }
                else
                {   
                    respuesta= "retirado";
                }

                conx.Close();
            }
            catch (Exception e)
            {
                respuesta = "errorSel"+e.Message ;
            }
            return respuesta;
        }
        public DataTable creaFormularios(string codigoFormulario)
        {
            string consultaXformulario = "select * from inventario_paquetes where cod_paquete = '" + codigoFormulario + "'";
            DataTable dataTableFormulario = genSel(consultaXformulario, conx);
            return dataTableFormulario;
        }
        public int genTurno()
        {
            string cc = "select * from ordenes where convert(date,fecha_hora_orden) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            int turno = genSel(cc, conx).Rows.Count + 1;
            return turno;
        }
        private string consultaOrden(string cod)
        {
            string s;
            try
            {
                int turno = genTurno();
                string fechaH = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");             
                SqlCommand bscPaquetexcod = new SqlCommand("insert into ordenes(cod_paquete_orden,fecha_hora_orden,turno_orden) values (@cod_paq_orden,@fec_ho_orden,@turno_orden)", conx);
                bscPaquetexcod.Parameters.AddWithValue("@cod_paq_orden",cod);
                bscPaquetexcod.Parameters.AddWithValue("@fec_ho_orden",fechaH);
                bscPaquetexcod.Parameters.AddWithValue("@turno_orden", turno);
                bscPaquetexcod.ExecuteNonQuery();
                
                s = "true";
            }catch(Exception e)
            {
                
                s = e.Message;
            }
            return s;
        }
        private DataTable genSel(string consulta, SqlConnection c)
        {
            SqlCommand cmd = new SqlCommand(consulta, c);
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            adap.Fill(dataTable);
            return dataTable;
        }
        public string dtString(DataTable dt)
        {
            StringBuilder cadena = new StringBuilder();
            dt.Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
            {
                dt.Columns.Cast<DataColumn>().ToList().ForEach(column =>
                {
                    cadena.AppendFormat("{0}  = {1} \n ", column.ColumnName, dataRow[column]);
                });
                cadena.Append(Environment.NewLine);
            });
            return cadena.ToString();
        }
        public string llamadaTurno(string cpaq)
        {
            String res;
            try
            {
            conx.Open();
            string consultllamadoturno = "select * from ordenes where cod_paquete_orden ='" + cpaq + "'";
            DataTable dtllamado = genSel(consultllamadoturno,conx);
                string ordenll = dtString(dtllamado);
                string clave = "turno_orden";
                string valor = string.Empty;
                int pos = ordenll.IndexOf(clave);
                string temp = ordenll.Substring(pos + clave.Length + 3);                               
                res = temp; 
                conx.Close();
            }catch(Exception e)
            {                
                res=e.Message;
            }

            return res;
        }
          
    }
}
