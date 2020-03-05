namespace HotelLandon.Models
{
    public class Room
    {
        #region Mes propriétés
        /* portée type     Nom         get/set */
        public int      Number      { get; set; }
        public int      Floor       { get; set; }
        public object   Standing    { get; set; }
        public bool     IsCleaned   { get; set; }
        public bool     IsBooked    { get; set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Contruit une chambre à l'aide du numéro d'étage et de son numéro
        /// </summary>
        /// <param name="floor">Numéro d'étage</param>
        /// <param name="number">Numéro de chambre</param>
        public Room(int floor, int number)
        {
            Floor = floor;
            Number = number;
        }

        /// <summary>
        /// Construit une chambre à l'aide du numéro d'étage, de son numéro, du standing et défini si elle est propre ou réservée
        /// </summary>
        /// <param name="floor">Numéro d'étage</param>
        /// <param name="number">Numéro de chambre</param>
        /// <param name="standing">Gamme de la chambre</param>
        /// <param name="isCleaned">Est-ce que la chambre est propre ?</param>
        /// <param name="isBooked">Est-ce que la chambre est réservée ?</param>
        public Room(int floor, int number, object standing, bool isCleaned, bool isBooked)
            : this(floor, number)
        {
            Standing = standing;
            IsCleaned = isCleaned;
            IsBooked = isBooked;
        }
        #endregion

        /// <summary>
        /// Représenter la classe <see cref="Room"/> en toutes lettres
        /// </summary>
        /// <returns>une chaîne de caractères</returns>
        public override string ToString()
        {
            return $"{base.ToString()} Etage: {Floor} Chambre {Number}";
        }
    }
}
