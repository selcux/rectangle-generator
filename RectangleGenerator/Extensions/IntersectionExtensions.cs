using System.Collections.Generic;
using System.Text;
using RectangleGenerator.Models;

namespace RectangleGenerator.Extensions {
    public static class IntersectionExtensions {
        public static string FormatToString(this IEnumerable<Intersection> intersections) {
            var sb = new StringBuilder();
            sb.AppendLine("Intersections:");

            foreach (var intersection in intersections) {
                sb.AppendLine($"      {intersection}");
            }

            return sb.ToString();
        }
    }
}