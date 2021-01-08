namespace BillOfMaterials.Model
{
    class Textbox : IShape
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public string Text { get; set; } = string.Empty;

        public string GetOutput()
        {
            return $"Textbox ({ PositionX },{ PositionY }) width={ Width } height={ Height } text=\"{ Text }\"\n";
        }
    }
}
