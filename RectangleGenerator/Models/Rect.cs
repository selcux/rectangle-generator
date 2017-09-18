using System.Security.Cryptography.X509Certificates;

namespace RectangleGenerator.Models {
    public class Rect {
        public int x, y, w, h;

        public Rect() {
        }

        public Rect(int x, int y, int w, int h) {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
    }
}