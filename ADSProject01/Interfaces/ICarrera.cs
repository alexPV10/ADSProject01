using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface ICarrera
    {
        public int AgregarCarrera(Carrera carrera);

        public int ActualizarCarrera(int idCarrera, Carrera carrera);

        public bool EliminarCarrera(int idCarrera);

        public List<Carrera> ObtenerTodasLasCarreras();

        public Carrera ObtenerCarreraPorId(int idCarrera);
    }
}
