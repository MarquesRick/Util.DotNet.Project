namespace DelegatesEvents
{
    public delegate void Calculation(double height, double width, double depth);
    public class GeometricFigure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

        public event Calculation Calculate;

        public void EventHandler()
        {
            Calculate(this.Height, this.Width, this.Depth);
        }
    }
}
