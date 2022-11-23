//TO-DO Program Player Combat

namespace Game
{
    public class Player
    {
        public Player(string name, string pokemonType)
        {
            this.name = name;
            this.PokemonType = pokemonType;
            this.Drinks = 0;
            this.Space = 0;
            this.Status = "";
            this.Zone = "";
            this.Skips = 0;
            this.EvolvedGymSkip = false;
            this.Magikarp = false;
            this.Legendaries = 0;
        }
        public string name { get; }
        public string PokemonType { get; set; }
        public int Drinks { get; set; }
        public int Space { get; set; }
        public string Status { get; set; }
        public string Zone { get; set; }
        public int Skips { get; set; }
        public bool EvolvedGymSkip { get; set; }
        public bool Magikarp { get; set; }
        public int Legendaries { get; set; }
    }
}
