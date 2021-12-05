using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApp_SQLZapateria.Models
{
    public class MantenimientoCalzado
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        //GET
        public List<Calzado> RecuperarTodos()
        {
            Conectar();
            List<Calzado> zapatos = new List<Calzado>();

            SqlCommand com = new SqlCommand("select codigo,marca,precio from calzado", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Calzado cal = new Calzado
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Marca = registros["marca"].ToString(),
                    Precio = float.Parse(registros["precio"].ToString())
                };
                zapatos.Add(cal);
            }
            con.Close();
            return zapatos;
        }

        //GET By ID
        public Calzado Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select codigo,marca,precio from calzado where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Calzado zapato = new Calzado();
            if (registros.Read())
            {
                zapato.Codigo = int.Parse(registros["codigo"].ToString());
                zapato.Marca = registros["marca"].ToString();
                zapato.Precio = float.Parse(registros["precio"].ToString());
            }
            con.Close();
            return zapato;
        }


        //POST
        public int Alta(Calzado cal)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into calzado(codigo,marca,precio) values (@codigo,@marca,@precio)", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters.Add("@marca", SqlDbType.VarChar);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@codigo"].Value = cal.Codigo;
            comando.Parameters["@marca"].Value = cal.Marca;
            comando.Parameters["@precio"].Value = cal.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        //PUT
        public int Modificar(Calzado cal)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update calzado set marca=@marca,precio=@precio where codigo=@codigo", con);
            comando.Parameters.Add("@marca", SqlDbType.VarChar);
            comando.Parameters["@marca"].Value = cal.Marca;
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@precio"].Value = cal.Precio;
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = cal.Codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        //DELETE
        public int Borrar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from calzado where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


    }
}