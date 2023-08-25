namespace FunctionApp1.Model;

public enum PokemonType
{
    Undefined = 0,
    Normal,
    Water,
    Grass,
    Fire,
    Electric,
    Flying,
    Ground,
    Rock,
    Fight,
    Bug
}

public class BasicPokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public PokemonType PokemonType { get; set; }
    public int Experience { get; set; }
}
