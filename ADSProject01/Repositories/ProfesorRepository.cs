using ADSProject.Models;
using ADSProject.Interfaces;
using ADSProject.DB;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        /*
        private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor="Dimas", ApellidosProfesor = "Carabantes", Email="cg16i04002@usonsonate.edu.sv"}
        };
        */

        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                /*
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesor[indice] = profesor;
                */

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);
                applicationDbContext.SaveChanges();
                return idProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                /*
                if (lstProfesor.Count > 0)
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(profesor);
                */
                applicationDbContext.Profesores.Add(profesor);
                applicationDbContext.SaveChanges();
                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                /*
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesor.RemoveAt(indice);
                */

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Profesores.Remove(item);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Profesor ObtenerProfesorPorId(int idProfesor)
        {
            try
            {
                //Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);
                var profesor = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                return profesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                //return lstProfesor;
                return applicationDbContext.Profesores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        public List<Profesor> ObtenerTodosLosProfesores()
        {
            throw new NotImplementedException();
        }

        Carrera IProfesor.ObtenerProfesorPorId(int idProfesor)
        {
            throw new NotImplementedException();
        }
        */
    }
}