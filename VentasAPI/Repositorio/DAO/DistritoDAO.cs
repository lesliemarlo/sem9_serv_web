
using Microsoft.Data.SqlClient;
using System.Data;
using VentasAPI.Models;
using VentasAPI.Repositorio.Interfaces;

namespace VentasAPI.Repositorio.DAO
{
    public class DistritoDAO : IDistrito
        
    {
        //CADENA
        private readonly string? cadena;
        public DistritoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }
        //-- 
        public IEnumerable<Distrito> listadoDistritos()
        {
            List<Distrito> aDistritos = new List<Distrito>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTADODISTRITOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Distrito objD = new Distrito()
                {
                    ide_dis = int.Parse(dr[0].ToString()),

                    nom_dis = dr[1].ToString()

                };
                aDistritos.Add(objD);
            }
            cn.Close();
            return aDistritos;
        }
    }
}
