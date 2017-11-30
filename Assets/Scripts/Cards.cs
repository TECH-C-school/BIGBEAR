public class Card
{
    private string face;
    private string type;

    public Card(string cardFace, string cardType)
    {
        face = cardFace;
        type = cardType;
    }

    public override string ToString()
    {
        return face + "of" +type;
    }

}