using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Personas
    {
        public static bool CRUDPersonas(ML.Personas persona)
        {
            try
            {
                using (DL.DrosasConsissContext context = new())
                {
                    int query = context.Database.ExecuteSqlRaw($"SpPersonas " +
                        $"{persona.Opcion}, {persona.IdPersona}, '{persona.Nombre}'," +
                        $"'{persona.Direccion}', {persona.Edad}, '{persona.Correo}'," +
                        $"'{persona.Habilidades}'");

                    if ( query > 0 )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}