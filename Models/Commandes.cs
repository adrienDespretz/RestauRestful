namespace RestauRestful.Models
{
    public class Commandes
    {
        // id fonctionne comme clé unique en bdd
        public long id { get; set; }
        public string? entree { get; set; }
        public string? plat { get; set; }
        public string? dessert { get; set; }
        public bool boisson { get; set; }
    }
}
