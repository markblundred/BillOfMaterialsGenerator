namespace BillOfMaterials.Model
{
    class Square : IShape
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;
        public int Width { get; set; } = 0;

        public string GetOutput()
        {
            return $"Square ({ PositionX },{ PositionY }) size={ Width }\n";
        }
    }
}
