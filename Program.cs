using System.Text;
const int WIDTH = 600;
const int HEIGHT = 600;
const int ITERATION_LIMIT = 200;
const double LIMIT = 1500.0;
var constant = (0.236, 0.529);
int[,] buffer = new int[HEIGHT, WIDTH];

for (int y = 0; y < HEIGHT; y++) {
    for (int x = 0; x < WIDTH; x++) {
        buffer[y, x] = getMandelbrotValue(2.0*((double)x/WIDTH)-1.0, -(2.0*((double)y/HEIGHT)-1.0));
    }
}
printMandelbrot();

void printMandelbrot() {
    StringBuilder builder = new(WIDTH*HEIGHT+HEIGHT);
    for (int y = 0; y < buffer.GetLength(0); y++) {
        for (int x = 0; x < buffer.GetLength(1); x++) {
            builder.Append(buffer[y,x] == -1 ? "@" : " ");
        }
        builder.Append('\n');
    }
    Console.Write(builder.ToString());
}

int getMandelbrotValue(double x, double y) {
    for (int z = 0; z < ITERATION_LIMIT; z++) {
        if (length(x, y) >= LIMIT) {
            return z;
        }
        (x, y) = (x*x - y*y + constant.Item1, 2*x*y + constant.Item2);
    }
    return -1;
}

double length(double x, double y) => Math.Sqrt(x*x+y*y);
