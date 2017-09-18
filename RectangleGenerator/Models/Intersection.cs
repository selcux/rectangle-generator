using System.Collections.Generic;
using System.Drawing;

namespace RectangleGenerator.Models {
    public class Intersection {
        public Rectangle Rect { get; set; }
        public HashSet<int> Indices { get; } = new HashSet<int>();

        public override string ToString() {
            return "Between rectangle " + string.Join(", ", Indices) + $" at {Rect.ToString()}";
        }
    }
}