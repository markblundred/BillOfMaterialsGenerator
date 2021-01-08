namespace BillOfMaterials.Model
{
    class Ellipse : IShape
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;
        public int HorizontalDiameter { get; set; } = 0;
        public int VerticalDiameter { get; set; } = 0;

        public string GetOutput()
        {
            return $"Ellipse ({ PositionX },{ PositionY }) diameterH = { HorizontalDiameter } diameterV = { VerticalDiameter }\n";
        }
    }
}
