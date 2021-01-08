namespace BillOfMaterials.Model
{
    class Rectangle : IShape
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;

        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public string GetOutput()
        {
            return $"Rectangle ({ PositionX },{ PositionY }) width={ Width } height={ Height }\n";
        }
    }
}
