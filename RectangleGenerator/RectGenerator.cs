using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RectangleGenerator.Models;

namespace RectangleGenerator {
    public class RectGenerator {
        private readonly Random _random = new Random();

        private readonly int _maxX = 500;
        private readonly int _maxY = 500;
        private readonly int _maxWitdh = 500;
        private readonly int _maxHeight = 500;

        public RectGenerator() {
        }

        public RectGenerator(int maxX, int maxY, int maxWitdh, int maxHeight) {
            _maxX = maxX;
            _maxY = maxY;
            _maxWitdh = maxWitdh;
            _maxHeight = maxHeight;
        }

        public IEnumerable<Rectangle> Generate(int count) {
            var rectangles = new Rectangle[count];

            for (var i = 0; i < count; i++) {
                var x = _random.Next(_maxX);
                var y = _random.Next(_maxY);
                var w = _random.Next(_maxWitdh);
                var h = _random.Next(_maxHeight);

                rectangles[i] = new Rectangle(x, y, w, h);
            }

            return rectangles;
        }

        public static IEnumerable<Intersection> Intersections(IEnumerable<Rectangle> rectangles) {
            var compareList = new LinkedList<Intersection>();
            var intersections = new LinkedList<Intersection>();

            var index = 0;
            foreach (var rectangle in rectangles) {
                var intersection = new Intersection {
                    Rect = rectangle
                };
                intersection.Indices.Add(index++);

                compareList.AddLast(intersection);
            }

            while (compareList.ToList().Count > 0) {
                var compareIntersect = compareList.First();
                compareList.RemoveFirst();

                foreach (var element in compareList) {
                    var intersectionRect = Rectangle.Intersect(compareIntersect.Rect, element.Rect);

                    if (intersectionRect.IsEmpty) continue;

                    var intersection = new Intersection {
                        Rect = intersectionRect
                    };
                    intersection.Indices.UnionWith(compareIntersect.Indices);
                    intersection.Indices.UnionWith(element.Indices);

                    if (intersections.All(x => !intersection.Indices.SetEquals(x.Indices))) {
                        compareList.AddLast(intersection);
                        intersections.AddLast(intersection);
                    }
                }
            }

            return intersections;
        }
    }
}