using System;
using System.Drawing;
using static grafikprogramm.Triangle;

namespace grafikprogramm
{
  class VarRectangle : Shape
  {
    private Point P1, P2, P3, P4;

    public VarRectangle(Point p1, Point p2, Point p3, Point p4, Color color) : base(color)
    {
      P1 = p1;
      P2 = p2;
      P3 = p3;
      P4 = p4;
      // umsortieren der Punkte, damit Punkt innerhalb des Vierecks immer rechts der Geraden ist.
      if (!IsRightToLine(P1, P2, P3.X, P3.Y))
      {
        var tmp = P2;
        P2 = P3;
        P3 = tmp;
      }
      if (!IsRightToLine(P1, P2, P4.X, P4.Y))
      {
        var tmp = P2;
        P2 = P4;
        P4 = tmp;
      }
      if (!IsRightToLine(P2, P3, P4.X, P4.Y))
      {
        var tmp = P3;
        P3 = P4;
        P4 = tmp;
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
      bool rightToP3P4 = IsRightToLine(P3, P4, x, y);
      bool rightToP4P1 = IsRightToLine(P4, P1, x, y);
      if (rightToP1P2 && rightToP2P3 && rightToP3P4 && rightToP4P1)
      {
        return FillColor;
      }
      return Color.Empty;
    }




  }
}
