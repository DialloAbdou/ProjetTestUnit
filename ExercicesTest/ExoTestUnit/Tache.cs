using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoTestUnit
{
    public class Tache
    {
        public string _Titre { get; private set; }
        public DateTime _Debut { get; private set; }
        public TimeSpan _Duree { get; private set; }
        public TimeSpan _ResteAfaire { get; private set; }
        public bool EstTerminee { get=>_ResteAfaire==TimeSpan.Zero; }

        public Tache(string titre, DateTime debut, TimeSpan resteAfaire )
        {
            _Titre = titre;
            _Debut = debut;
            _ResteAfaire = resteAfaire;
        }

        public void effectuer(TimeSpan duree)
        {
            if(duree > _ResteAfaire || duree < TimeSpan.Zero)
            {

                throw new ArgumentOutOfRangeException(nameof(duree), "la duree ne doit pas depasser le nbre de temps à faire aussi le temps doit pas être negatif !");

            }
            _ResteAfaire-=duree;
        }
        public IEnumerable<Tache> FiltrerTacheTerminer(IEnumerable<Tache> ListeTaches)
        {
            return from tache in ListeTaches
                   where tache.EstTerminee
                   select tache;
        }
    }
}
