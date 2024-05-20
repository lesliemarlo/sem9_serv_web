using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using VentasAPI.Models;
using VentasAPI.Repositorio.Interfaces;
namespace VentasAPI.Repositorio.DAO
{
    public class VendedorDAO : IVendedor
    {
        //CADENA
        private readonly string? cadena;
        public VendedorDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }
        //-- 
        //--metodos
        public VendedorO buscarVendedor(int id)
        {
            throw new NotImplementedException();
        }

        //listado
        public IEnumerable<Vendedor> listadoVendedor()
        {
          List<Vendedor> aVendedores = new List<Vendedor>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADOVENDEDORES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aVendedores.Add(new Vendedor
                {
                    ide_ven = Int32.Parse(dr[0].ToString()),
                    nom_ven = dr[1].ToString(),
                    sue_ven = Double.Parse(dr[2].ToString()),
                    fec_ing = DateTime.Parse(dr[3].ToString()),
                    nom_dis = dr[4].ToString()
                }
                    ) ;
            }
            cn.Close();
            return aVendedores;
        }

        public IEnumerable<VendedorO> listadoVendedorO()
        {
            throw new NotImplementedException();
        }

        public string modificaVendedor(VendedorO objV)
        {
            throw new NotImplementedException();
        }

        //paso2
        public string nuevoVendedor(VendedorO objV)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_VENDEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", objV.ide_ven);
                cmd.Parameters.AddWithValue("@nom", objV.nom_ven);
                cmd.Parameters.AddWithValue("@ape", objV.ape_ven);
                cmd.Parameters.AddWithValue("@sue", objV.sue_ven);
                cmd.Parameters.AddWithValue("@fec", objV.fec_ing);
                cmd.Parameters.AddWithValue("@dis", objV.ide_dis);
             
                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Vendedor registrado correctamente..!!";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar..!!" + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
    }
}
