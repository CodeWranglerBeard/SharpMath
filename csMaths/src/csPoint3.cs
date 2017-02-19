﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tools.Maths.Point3
{
    /// <summary>
    /// Represents a collection of three coordinates, for use in three dimensional space. 
    /// </summary>
    [DebuggerDisplay("\\{X = {X} Y = {Y} Z = {Z}\\}")]
    public struct csPoint3
    {
        public int X;
        public int Y;
        public int Z;

        public csPoint3(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    /// <summary>
    /// Represents a collection of three coordinates, for use in three dimensional space. 
    /// </summary>
    [DebuggerDisplay("\\{X = {X} Y = {Y} Z = {Z}\\}")]
    public struct csPoint3F
    {
        public float X;
        public float Y;
        public float Z;

        public csPoint3F(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    /// <summary>
    /// Represents a collection of three coordinates, for use in three dimensional space. 
    /// </summary>
    [DebuggerDisplay("\\{X = {X} Y = {Y} Z = {Z}\\}")]
    public struct csPoint3D
    {
        public double X;
        public double Y;
        public double Z;

        public csPoint3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
