namespace Overerving
{
    public class Dier
    {
        public string Naam { get; set; }

        public Dier(string naam)
        { 
            Naam = naam;
        }

        public virtual string Geluid()
        {
            return $"{Naam} is een {this.GetType()} ";
        }
    }

    public class Kat : Dier
    {
        public Kat(string naam) : base(naam)
        {
        }

        public override string Geluid()
        {
            return $"{Naam} is een {this.GetType()} en zegt miauw";
        }
    }

    public class Hond : Dier
    {
        public Hond(string naam) : base(naam)
        {
            Naam = naam;
        }

        public override string Geluid()
        {
            return $"{Naam} is een {this.GetType()} en zegt Woef";
        }
    }
}
