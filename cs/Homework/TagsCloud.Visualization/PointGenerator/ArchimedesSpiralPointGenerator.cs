﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Visualization.PointGenerator
{
    public class ArchimedesSpiralPointGenerator : IPointGenerator
    {
        private readonly double angleDelta;
        private readonly Point center;
        private readonly double xAxisCompression;
        private readonly double yAxisCompression;
        private double angle;

        public ArchimedesSpiralPointGenerator(
            Point center,
            double angleDelta = Math.PI / 360,
            double xAxisCompression = 1,
            double yAxisCompression = 1)
        {
            this.center = center;
            this.angleDelta = angleDelta;
            this.xAxisCompression = xAxisCompression;
            this.yAxisCompression = yAxisCompression;
        }

        public IEnumerable<Point> GenerateNextPoint()
        {
            while (true)
            {
                var x = Convert.ToInt32(xAxisCompression * Math.Cos(angle) * angle + center.X);
                var y = Convert.ToInt32(yAxisCompression * Math.Sin(angle) * angle + center.Y);

                angle += angleDelta;

                yield return new Point(x, y);
            }

            // ReSharper disable once IteratorNeverReturns
        }
    }
}