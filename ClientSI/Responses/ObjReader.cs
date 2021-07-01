using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Library.ObjReader
{
    public class ObjReader
    {
        public string Path { get; set; }

        public List<double> X;
        public List<double> Y;
        public List<double> Z;

        public double MaxX { get; private set; }
        public double MaxY { get; private set; }
        public double MaxZ { get; private set; }
        public double MinX { get; private set; }
        public double MinY { get; private set; }
        public double MinZ { get; private set; }
        public double Height { get { return MaxY - MinY; } }
        public double Width { get { return MaxX - MinX; } }
        public double Depth { get { return MaxZ - MinZ; } }

        protected string[] lines;
        protected virtual void ReadLines()
        {
           lines = System.IO.File.ReadAllLines(Path);
        }
        public void ReadFile()
        {
            MaxX = double.MinValue;
            MaxY = double.MinValue;
            MaxZ = double.MinValue;
            MinX = double.MaxValue;
            MinY = double.MaxValue;
            MinZ = double.MaxValue;
            X = new List<double>(10000);
            Y = new List<double>(10000);
            Z = new List<double>(10000);
            ReadLines();
            if (lines != null)
            {
                foreach (string line in lines)
                {

                    if (line.StartsWith("#"))
                        continue;
                    string[] lineArr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lineArr.Length == 4)
                    {
                        if (lineArr[0].Equals("v"))
                        {
                            double valX = double.Parse(lineArr[1], CultureInfo.InvariantCulture);
                            double valY = double.Parse(lineArr[2], CultureInfo.InvariantCulture);
                            double valZ = double.Parse(lineArr[3], CultureInfo.InvariantCulture);
                            MaxX = valX > MaxX ? valX : MaxX;
                            MaxY = valY > MaxY ? valY : MaxY;
                            MaxZ = valZ > MaxZ ? valZ : MaxZ;
                            MinX = valX < MinX ? valX : MinX;
                            MinY = valY < MinY ? valY : MinY;
                            MinZ = valZ < MinZ ? valZ : MinZ;

                            X.Add(valX);
                            Y.Add(valY);
                            Z.Add(valZ);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Error: no lines found");
            }

        }
    }
}