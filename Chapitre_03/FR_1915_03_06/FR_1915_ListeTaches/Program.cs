using System;
using System.Globalization;
using System.IO;

namespace FR_1915_ListeTaches
{
    class Program
    {
        static void Main(string[] args)
        {
            Tache tacheA = new Tache("Tâche A", DateTime.Now - TimeSpan.FromDays(2), TimeSpan.FromDays(3));
            Tache tacheB = new Tache("Tâche B", DateTime.Now - TimeSpan.FromDays(3), TimeSpan.FromDays(5));

            tacheA.Effectuer(TimeSpan.FromDays(2));
            tacheB.Effectuer(TimeSpan.FromDays(3));

            using(var stream = new FileStream("taches.csv", FileMode.Create, FileAccess.Write))
            {
                foreach (Tache t in new Tache[] { tacheA, tacheB })
                {
                    Console.WriteLine($"La tâche '{ t.Titre }'");
                    Console.WriteLine($"- A faire/Total : { t.ResteAFaire } / { t.Duree }");
                    Console.WriteLine($"- Début/fin     : { t.Debut } - { t.FinEstimee }");
                    t.ExporterCSV(stream, CultureInfo.CurrentCulture);
                }
            }
        }
    }
}
