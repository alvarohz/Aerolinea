using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea.Modelos;
using Aerolinea.Conexion;

namespace Aerolinea.Controladores
{
    class ControladorPaises
    {
        public List<paises> ListarPaises() {
            List<paises> p;
            try { 
                Model model = new Conexion.Model();
                p = model.Entidades.paises.ToList();
                model.cerrarConexion();
            }catch(Exception ex){
                return null;
            }

            return p;
        }

        public List<paises> ListarPaises(string criterio)
        {
            List<paises> p;
            try
            {
                Model model = new Conexion.Model();
                p = model.Entidades.paises.Where(e=>e.pais.Contains(criterio)).ToList();
                model.cerrarConexion();
            }
            catch (Exception ex)
            {
                return null;
            }

            return p;
        }

        public Boolean InsertarPais(paises p) {
            try
            {
                Model model = new Model();
                model.Entidades.paises.Add(p);
                model.Entidades.SaveChanges();
                model.cerrarConexion();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Boolean ModificarPais(int id, paises p)
        {
            try
            {
                Model model = new Model();
                paises original = model.Entidades.paises.Find(id);
                original.pais = p.pais;
                model.Entidades.SaveChanges();
                model.cerrarConexion();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Boolean EliminarPais(int id)
        {
            try
            {
                Model model = new Model();
                paises original = model.Entidades.paises.Find(id);
                model.Entidades.paises.Remove(original);
                model.Entidades.SaveChanges();
                model.cerrarConexion();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
