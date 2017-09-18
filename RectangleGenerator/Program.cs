using System;
using System.Drawing;
using System.IO;
using System.Linq;
using RectangleGenerator.Extensions;

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
                
                var intersections = RectGenerator.Intersections(rectangles);
                Console.Out.WriteLine(intersections.FormatToString());
            }
            catch (Exception e) {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}