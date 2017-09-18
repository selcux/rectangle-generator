using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RectangleGenerator.Models {
    public class Intersection {
        public Rectangle Rect { get; set; }
        public HashSet<int> Indices { get; } = new HashSet<int>();

        public override string ToString() {
            var indexArr = Indices.Select(x => (x + 1).ToString()).OrderBy(x => x).ToArray();

            var indexListStr = string.Join(", ", indexArr, 0, indexArr.Length - 1) +
                               $" and {indexArr[indexArr.Length - 1]}";

            return $"Between rectangle {indexListStr} at {Rect}";
        }
    }
}