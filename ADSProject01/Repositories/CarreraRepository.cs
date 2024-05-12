using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProjec.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*
        private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera{IdCarrera = 1, Codigo="I04", Nombre = "Ingenieria en Sistemas"}
        };
        */

        private readonly ApplicationDbContext applicationDbContext;

        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                /*
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                lstCarrera[indice] = carrera;
                */
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                return idCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                /*
                if (lstCarrera.Count > 0)
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera + 1;
                }
                lstCarrera.Add(carrera);
                */

                applicationDbContext.Carreras.Add(carrera);
                applicationDbContext.SaveChanges();
                return carrera.IdCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                /*
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                lstCarrera.RemoveAt(indice);
                */

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Carreras.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        public Carrera ObtenerCarreraPorID(int idCarrera)
        {
            throw new NotImplementedException();
        }
        */

        public Carrera ObtenerCarreraPorId(int idCarrera)
        {
            try
            {
                //Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == idCarrera);
                var carrera = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                return carrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerTodasLasCarreras()
        {
            try
            {
                //return lstCarrera
                return applicationDbContext.Carreras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
