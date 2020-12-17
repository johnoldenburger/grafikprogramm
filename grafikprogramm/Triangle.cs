using System;
using System.Drawing;

namespace grafikprogramm
{
  public class Triangle : Shape
  {
    private Point P1, P2, P3;

    public Triangle(Point p1, Point p2, Point p3, Color color) : base(color)
    {
      P1 = p1;
      P2 = p2;
      P3 = p3;
      // umsortieren der Punkte, damit Punkt innerhalb des Dreiecks immer rechts der geraden ist.
      if (!IsRightToLine(P1, P2, P3.X, P3.Y))
      {
        P3 = p2;
        P2 = p3;
      }
    }
    public override Shape Clone()
    {
      throw new NotImplementedException();
    }

    public override Color GetColor(int x, int y)
    {
      bool rightToP1P2 = IsRightToLine(P1, P2, x, y);
      bool rightToP2P3 = IsRightToLine(P2, P3, x, y);
      bool rightToP3P1 = IsRightToLine(P3, P1, x, y);
      if (rightToP1P2 && rightToP2P3 && rightToP3P1)
      {
        return FillColor;
      }
      return Color.Empty;
    }


    /// <summary>
    /// Methode berechnet mithilfe des Kreuzprodukts, ob sich ein Punkt (x,y) rechts oder links der
    /// Gerade von p1 zu p2 befindet.
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool IsRightToLine(Point p1, Point p2, int x, int y)
    {
      int v1X = p2.X - p1.X;
      int v1Y = p2.Y - p1.Y;
      int v2X = p2.X - x;
      int v2Y = p2.Y - y;
      int xp = (v1X * v2Y) - (v1Y * v2X);
      return xp <= 0;
    }

  }
}
