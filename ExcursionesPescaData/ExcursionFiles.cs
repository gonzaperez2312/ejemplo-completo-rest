using ExcursionesPescaEntities;
using Newtonsoft.Json;

namespace ExcursionesPescaData
{
    public class ExcursionFiles
    {
        private static string lagoFileName = Path.GetFullPath("Lago.json");
        private static string marFileName = Path.GetFullPath("Mar.json");

        // Método para escribir un usuario a un archivo JSON
        public static void EscribirExcursion(Excursion excursion)
        {
            if (excursion is ExcursionLago)
            {
                EscribirExcursionLago(excursion as ExcursionLago);
            }

            if (excursion is ExcursionMar)
            {
                EscribirExcursionMar(excursion as ExcursionMar);
            }
        }

        private static void EscribirExcursionLago(ExcursionLago excursionLago)
        {
            List<Excursion> excursiones = LeerExcursiones();

            if (excursionLago.Codigo == 0)
            {
                excursionLago.Codigo = excursiones.Count();
            }
            else
            {
                excursiones.RemoveAll(x => x.Codigo == excursionLago.Codigo);
            }


            excursiones.Add(excursionLago);

            var json = JsonConvert.SerializeObject(excursiones.Where(x => x is ExcursionLago).ToList(), Formatting.Indented);
            File.WriteAllText($"{lagoFileName}", json);
        }

        private static void EscribirExcursionMar(ExcursionMar excursionMar)
        {
            List<Excursion> excursiones = LeerExcursiones();

            if (excursionMar.Codigo == 0)
            {
                excursionMar.Codigo = excursiones.Count() + 1;
            }
            else
            {
                excursiones.RemoveAll(x => x.Codigo == excursionMar.Codigo);
            }


            excursiones.Add(excursionMar);

            var json = JsonConvert.SerializeObject(excursiones.Where(x => x is ExcursionMar).ToList(), Formatting.Indented);
            File.WriteAllText($"{marFileName}", json);
        }

        public static List<Excursion> LeerExcursiones()
        {
            List<Excursion> excursiones = new List<Excursion>();
            excursiones.AddRange(LeerExcursionesMarDesdeJson());
            excursiones.AddRange(LeerExcursionesLagoDesdeJson());

            return excursiones;
        }

        private static List<ExcursionLago> LeerExcursionesLagoDesdeJson()
        {
            if (File.Exists($"{lagoFileName}"))
            {
                var json = File.ReadAllText($"{lagoFileName}");
                return JsonConvert.DeserializeObject<List<ExcursionLago>>(json);
            }
            else
            {
                return new List<ExcursionLago>();
            }
        }

        private static List<ExcursionMar> LeerExcursionesMarDesdeJson()
        {
            if (File.Exists($"{marFileName}"))
            { 
                var json = File.ReadAllText($"{marFileName}");
                return JsonConvert.DeserializeObject<List<ExcursionMar>>(json);
            }
            else
            {
                return new List<ExcursionMar>();
            }
        }
    }
}
