namespace BillOfMaterials.Model
{
    class Circle : IShape
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;
        public int Diameter { get; set; } = 0;

        public string GetOutput()
        {
            return $"Circle ({ PositionX },{ PositionY }) size={ Diameter }\n";
        }
    }
}
