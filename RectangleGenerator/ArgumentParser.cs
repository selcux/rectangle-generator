using System;
using System.IO;
using System.Linq;
using System.Text;
using RectangleGenerator.Models;

namespace RectangleGenerator {
    public class ArgumentParser {
        private readonly string[] _args;

        public ArgumentParser(string[] args) {
            _args = args;
        }

        public bool GetCount(out int count) {
            count = 0;
            if (!_args.Contains(ArgumentTypes.Count)) {
                return false;
            }

            var index = Array.IndexOf(_args, ArgumentTypes.Count);
            var argStr = _args[index + 1];
            if (!int.TryParse(argStr, out var c)) {
                throw new InvalidDataException("Count must be an integer.");
            }

            count = c;
            return true;
        }

        public bool GetHelp(out string helpMessage) {
            helpMessage = null;
            if (!_args.Contains(ArgumentTypes.Help)) {
                return false;
            }

            var sb = new StringBuilder();

            sb.AppendLine("--count [N] : Number of rectangles to generate");

            helpMessage = sb.ToString();
            return true;
        }

        public bool GetFilePath(out string filePath) {
            filePath = null;
            if (!_args.Contains(ArgumentTypes.File)) {
                return false;
            }

            var index = Array.IndexOf(_args, ArgumentTypes.File);
            filePath = _args[index + 1];

            return true;
        }
    }
}