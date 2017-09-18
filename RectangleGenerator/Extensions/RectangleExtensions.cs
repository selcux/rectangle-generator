using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RectangleGenerator.Extensions {
    public static class RectangleExtensions {
        public static string FormatToString(this Rectangle rectangle) {
            return $"({rectangle.X}, {rectangle.Y}), w={rectangle.Width}, h={rectangle.Height}";
        }

        public static string FormatToString(this IEnumerable<Rectangle> rects) {
            var sb = new StringBuilder();
            sb.AppendLine("Input:");

            var rectangles = rects as Rectangle[] ?? rects.ToArray();
            for (var i = 0; i < rectangles.Length; i++) {
                sb.AppendLine($"      {i + 1}. Rectangle at " + rectangles[i].FormatToString());
            }

            return sb.ToString();
        }
    }
}