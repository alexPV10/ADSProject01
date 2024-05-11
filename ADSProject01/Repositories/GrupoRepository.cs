﻿using ADSProject.Models;
using ADSProject.Interfaces;
using System.Numerics;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo{IdGrupo = 1, IdCarrera=1, IdMateria = 1,IdProfesor=1,Ciclo=01,Anio=2024}
        };


        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                lstGrupo[indice] = grupo;

                return idGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                if (lstGrupo.Count > 0)
                {
                    grupo.IdGrupo = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(grupo);

                return grupo.IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                lstGrupo.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            throw new NotImplementedException();
        }

        public Grupo ObtenerGrupoPorId(int idGrupo)
        {
            try
            {
                Grupo grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);

                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                return lstGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
