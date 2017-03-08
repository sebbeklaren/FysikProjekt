using Microsoft.Xna.Framework;


class Constants
{
    //16m wide, 9.6 high
    static public Vector2 screenSize = new Vector2(800, 480);
    static public Vector2 scale = new Vector2(50, -50);    //pixels per meter
    static public Vector2 mScreenSize = screenSize / scale;
    //Vi antar att meter skalan är höger = x postitiv, uppåt = y positivt.
    //vilket gör att x blir positiv och y blir negativ i skalan

    //Anta att 0,0 är nedre vänstra hörnet
    static public Vector2 TopLeft = new Vector2(screenSize.X * scale.X, 0);   //position av över vänstra hörnet i meter
    static public Vector2 PosToPixel(Vector2 vec)
    {
        Vector2 temp = new Vector2(
            vec.X * scale.X,
            vec.Y * scale.Y + screenSize.Y);
        return temp;
    }
}
