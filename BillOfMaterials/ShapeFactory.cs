using BillOfMaterials.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace BillOfMaterials
{
    public class ShapeFactory
    {
        public static IList<IShape> TextFileToShapes(StreamReader fileStreamReader)
        {
            var peekableStreamReader = new PeekableStreamReaderAdapter(fileStreamReader);
            string nextLine;
            var result = new List<IShape>();

            while ((nextLine = peekableStreamReader.ReadLine()) != null)
            {
                if (!nextLine.StartsWith("•	"))
                {
                    throw new Exception($"Input file not correctly formatted, new shapes must be marked with a black bullet point \" { nextLine }\"");
                }

                // Get the quantity and string word representing the name of the shape (after removing the bullet point and white space)
                var splitInput = nextLine.Substring(2, nextLine.Length - 2).Split(" x ");

                if (splitInput.Length != 2)
                {
                    throw new Exception("Item properties must be submitted in the form of \"{number} x {name of shape}\"");
                }

                int quantity;
                var shapeText = splitInput[1];
                try
                {
                    quantity = Convert.ToInt32(splitInput[0]);
                }
                catch
                {
                    throw new Exception($"\"{splitInput[0]}\" is not a valid quantity for shape \"{ shapeText }\"");
                }

                IShape nextShape;
                IDictionary<string, object> properties;

                switch(shapeText)
                {
                    case "Rectangle":
                        var rectangle = new Rectangle();
                        properties = ParseProperties(peekableStreamReader);
                        if (properties.ContainsKey("Position X")) rectangle.PositionX = Convert.ToInt32(properties["Position X"]);
                        if (properties.ContainsKey("Position Y")) rectangle.PositionY = Convert.ToInt32(properties["Position Y"]);
                        if (properties.ContainsKey("Width")) rectangle.Width = Convert.ToInt32(properties["Width"]);
                        if (properties.ContainsKey("Height")) rectangle.Height = Convert.ToInt32(properties["Height"]);
                        nextShape = rectangle;
                        break;
                    case "Square":
                        var square = new Square();
                        properties = ParseProperties(peekableStreamReader);
                        if (properties.ContainsKey("Position X")) square.PositionX = Convert.ToInt32(properties["Position X"]);
                        if (properties.ContainsKey("Position Y")) square.PositionY = Convert.ToInt32(properties["Position Y"]);
                        if (properties.ContainsKey("Width")) square.Width = Convert.ToInt32(properties["Width"]);
                        nextShape = square;
                        break;
                    case "Ellipse":
                        var ellipse = new Ellipse();
                        properties = ParseProperties(peekableStreamReader);
                        if (properties.ContainsKey("Position X")) ellipse.PositionX = Convert.ToInt32(properties["Position X"]);
                        if (properties.ContainsKey("Position Y")) ellipse.PositionY = Convert.ToInt32(properties["Position Y"]);
                        if (properties.ContainsKey("Horizontal Diameter")) ellipse.HorizontalDiameter = Convert.ToInt32(properties["Horizontal Diameter"]);
                        if (properties.ContainsKey("Vertical Diameter")) ellipse.VerticalDiameter = Convert.ToInt32(properties["Vertical Diameter"]);
                        nextShape = ellipse;
                        break;
                    case "Circle":
                        var circle = new Circle();
                        properties = ParseProperties(peekableStreamReader);
                        if (properties.ContainsKey("Position X")) circle.PositionX = Convert.ToInt32(properties["Position X"]);
                        if (properties.ContainsKey("Position Y")) circle.PositionY = Convert.ToInt32(properties["Position Y"]);
                        if (properties.ContainsKey("Diameter")) circle.Diameter = Convert.ToInt32(properties["Diameter"]);
                        nextShape = circle;
                        break;
                    case "Textbox":
                        var textBox = new Textbox();
                        properties = ParseProperties(peekableStreamReader);
                        if (properties.ContainsKey("Position X")) textBox.PositionX = Convert.ToInt32(properties["Position X"]);
                        if (properties.ContainsKey("Position Y")) textBox.PositionY = Convert.ToInt32(properties["Position Y"]);
                        if (properties.ContainsKey("Width")) textBox.Width = Convert.ToInt32(properties["Width"]);
                        if (properties.ContainsKey("Height")) textBox.Height = Convert.ToInt32(properties["Height"]);
                        if (properties.ContainsKey("Text")) textBox.Text = (string)properties["Text"];
                        nextShape = textBox;
                        break;
                    default:
                        throw new Exception($"The string \"{ shapeText }\" cannot be parsed into a new shape object");
                }

                for (var i = 0; i < quantity; i++)
                {
                    result.Add(nextShape);
                }
            }

            return result;
        }

        private static IDictionary<string, object> ParseProperties(PeekableStreamReaderAdapter peekableStreamReader)
        {
            var result = new Dictionary<string, object>();
            string nextLine;

            while((nextLine = peekableStreamReader.PeekLine())?.StartsWith("o	") ?? false)
            {
                nextLine = nextLine.Substring(2, nextLine.Length - 2);      // Remove the white bullet point and tabulated white space
                var splitInput = nextLine.Split(" - ");

                if (splitInput.Length != 2)
                {
                    throw new Exception("Item properties must be submitted in the form of \"key - value\"");
                }

                result.Add(splitInput[0], splitInput[1]);
                peekableStreamReader.ReadLine();        // Advance the streamreader's position
            }

            return result;
        }
    }
}