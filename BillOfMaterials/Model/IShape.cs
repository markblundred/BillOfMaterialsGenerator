namespace BillOfMaterials
{
    public interface IShape
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        string GetOutput();
    }
}
