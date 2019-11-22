using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNCliente
    {
        public IEnumerable<CECliente> listarCliente()
        {
            CDCliente obj = new CDCliente();

            return obj.listarCliente();
        }

        public IEnumerable<CECliente> insCliente(string xml)
        {
            CDCliente obj = new CDCliente();

            return obj.insCliente(xml);
        }
    }
}
