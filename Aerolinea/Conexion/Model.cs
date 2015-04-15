using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea.Modelos;

namespace Aerolinea.Conexion
{
    class Model
    {
        //variable de contexto para manejar la conexion del modelo con la base de datos
        private aerolineaEntities entidades;

        public Model() {
            //inicializacion de la variable que maneja el modelo
            entidades = new aerolineaEntities();
        }

        //atributo de acceso al campo
        public aerolineaEntities Entidades {
            get { return entidades; }
            set { entidades = value; }
        }

        //elimina la vinculacion del objeto
        public void cerrarConexion() {
            entidades.Dispose();
        }
    }
}
