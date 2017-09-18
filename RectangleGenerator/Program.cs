using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RectangleGenerator.Extensions;
using RectangleGenerator.Models;

namespace RectangleGenerator {
    internal static class Program {
        private static void Main(string[] args) {
            try {
                if (args == null || args.Length == 0) {
                    throw new InvalidDataException(
                        "The program cannot take no arguments. Use --help for more details.");
                }

                var parser = new ArgumentParser(args);

                if (parser.GetHelp(out var helpMessage)) {
                    Console.Out.WriteLine(helpMessage);
                }

                if (!parser.GetCount(out var count)) return;

                var generator = new RectGenerator();
                var rects = generator.Generate(count);

                var rectangles = rects as Rectangle[] ?? rects.ToArray();
                Console.Out.WriteLine(rectangles.FormatToString());

                var intersections = IntersectionOperations.Intersections(rectangles);
                Console.Out.WriteLine(intersections.FormatToString());

                if (parser.GetFilePath(out var filePath)) {
                    var rectangleContainer = new Rectangles {
                        Rects = rectangles.Select(x => x.ToRect())
                    };

                    var rectanglesJson = JsonConvert.SerializeObject(rectangleContainer, Formatting.Indented);
                    File.WriteAllText(filePath, rectanglesJson);
                }
            }
            catch (Exception e) {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}