using System;
using System.Collections.Generic;
using System.IO;

namespace BillOfMaterials
{
    public class SummaryWriter
    {
        const string lineBreak = "----------------------------------------------------------------\n";

        public static string GetSummaryText(string filePath)
        {
            try
            {
                DebugWriter.WriteInfo("Opening a streamreader at location " + filePath);
                var streamReader = new StreamReader(filePath);

                DebugWriter.WriteInfo("Converting text file to IEnumerable<IShape>");
                var shapes = ShapeFactory.TextFileToShapes(streamReader);

                return GetSummaryText(shapes);
            }
            catch (Exception err)
            {
                DebugWriter.WriteException(err);
                return "+++++Abort+++++";
            }
        }

        public static string GetSummaryText(IList<IShape> shapes)
        {
            try
            {
                DebugWriter.WriteInfo($"Creating output text for { shapes.Count } shapes");
                var result = lineBreak + "Bill of Materials\n" + lineBreak;

                foreach (var shape in shapes)
                {
                    result += shape.GetOutput();
                }

                result += lineBreak;

                return result;
            }
            catch (Exception err)
            {
                DebugWriter.WriteException(err);
                return "+++++Abort+++++";
            }
        }
    }
}
