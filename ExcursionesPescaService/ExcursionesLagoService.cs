using ExcursionesPescaData;
using ExcursionesPescaEntities;

namespace ExcursionesPescaService
{
    public class ExcursionesLagoService
    {
        public List<ExcursionLago> ObtenerExcursiones() { 
            return ExcursionFiles.LeerExcursiones().Where(x => x is ExcursionLago).Select(x => x as ExcursionLago).ToList();
        }

        public List<ExcursionLago> ObtenerExcursionesPorId(int id)
        {
            return ObtenerExcursiones().Where(x => x.Codigo == id).Select(x => x as ExcursionLago).ToList();
        }

        public bool AgregarExcursion(ExcursionLago excursionLago) {
            ExcursionFiles.EscribirExcursion(excursionLago);

            return true;
        }

        public bool EditarExcursion(int Codigo, ExcursionLago excursionLagoTemporal)
        {
            Excursion excursion = ExcursionFiles.LeerExcursiones().FirstOrDefault(x => x.Codigo == Codigo);

            if (excursion == null || !(excursion is ExcursionLago))
            {
                return false;
            }

            ExcursionLago excursionLago = excursion as ExcursionLago;
            excursionLago.Duracion = excursionLagoTemporal.Duracion;
            excursionLago.Ubicacion = excursionLagoTemporal.Ubicacion;
            excursionLago.TieneGuia = excursionLagoTemporal.TieneGuia;
            excursionLago.EspeciePesca = excursionLagoTemporal.EspeciePesca;

            ExcursionFiles.EscribirExcursion(excursionLago);

            return true;
        }

        public bool EliminarExcursion(int Codigo)
        {
            Excursion excursion = ExcursionFiles.LeerExcursiones().FirstOrDefault(x => x.Codigo == Codigo);

            if (excursion == null || !(excursion is ExcursionLago))
            {
                return false;
            }

            ExcursionLago excursionLago = excursion as ExcursionLago;
            excursionLago.FechaEliminacion = DateTime.Now;

            ExcursionFiles.EscribirExcursion(excursionLago);

            return true;
        }
    }
}
