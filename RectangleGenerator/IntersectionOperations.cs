using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RectangleGenerator.Models;

namespace RectangleGenerator {
    public static class IntersectionOperations {
        public static IEnumerable<Intersection> Intersections(IEnumerable<Rectangle> rectangles) {
            var intersections = new List<Intersection>();

            var compareList = rectangles.Select(delegate(Rectangle rectangle, int i) {
                var intersection = new Intersection {
                    Rect = rectangle
                };
                intersection.Indices.Add(i);

                return intersection;
            }).ToList();

            while (compareList.Count > 0) {
                var compareIntersect = compareList.First();
                compareList.RemoveAt(0);

                var intersectionBuffer = new List<Intersection>();

                foreach (var element in compareList) {
                    var intersectionRect = Rectangle.Intersect(compareIntersect.Rect, element.Rect);

                    if (intersectionRect.IsEmpty) continue;

                    var intersection = new Intersection {
                        Rect = intersectionRect
                    };
                    intersection.Indices.UnionWith(compareIntersect.Indices);
                    intersection.Indices.UnionWith(element.Indices);

                    if (intersections.Any(x => intersection.Indices.SetEquals(x.Indices))) continue;

                    intersectionBuffer.Add(intersection);
                    intersections.Add(intersection);
                }

                compareList.AddRange(intersectionBuffer);
            }

            return intersections;
        }
    }
}