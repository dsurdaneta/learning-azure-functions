namespace FunctionApp1.Model;

public class StarterPokemon
{
    internal const string ASSIGNED_STARTER_URL = "http://test.com";
    public string PlayerName { get; set; }
    public string Name => Pokemon.Name;
    public string NickName { get; set;}
    public string Item { get; set; }
    public BasicPokemon Pokemon { get; set; }
    public int FriendshipLevel { get; set; }

    public StarterPokemon(BasicPokemon pokemon, string nickName = null, string item = null, string playerName = null)
    {
        NickName = nickName;
        Item = item;
        Pokemon = pokemon;
        FriendshipLevel = 7;
        Pokemon.Capture();
        PlayerName = playerName;
    }
}
