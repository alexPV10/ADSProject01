using ADSProject.Models;
using ADSProject.Interfaces;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor="Carlos", ApellidosProfesor = "Hernandez", Email="carlos@usonsonate.sv"}
        };

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                lstProfesor[indice] = profesor;

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
                if (lstProfesor.Count > 0)
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(profesor);

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
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                lstProfesor.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            throw new NotImplementedException();
        }

        public Profesor ObtenerProfesorPorId(int idProfesor)
        {
            try
            {
                Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);

                return profesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodasLosProfesores()
        {
            try
            {
                return lstProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            throw new NotImplementedException();
        }

        Carrera IProfesor.ObtenerProfesorPorId(int idProfesor)
        {
            throw new NotImplementedException();
        }
    }
}