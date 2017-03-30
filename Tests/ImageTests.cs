﻿using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace SiftSharp.Tests
{
    [TestFixture()]
    public class ImageTests
    {
        [Test()]
        public void marioExist()
        {
            Assert.IsTrue(File.Exists(@"images\mario.png"));
        }

        [Test()]
        public void readImageTest()
        {
            Image testImage = new Image();
            int[,] expected = {
                { 91, 91, 91, 139, 139, 139, 139, 139, 139 },
                { 91, 91, 91, 139, 139, 139, 139, 139, 139 },
                { 91, 91, 91, 139, 139, 139, 139, 139, 139 },
                { 139, 139, 139, 130, 130, 130, 130, 130, 130 },
                { 139, 139, 139, 130, 130, 130, 130, 130, 130 },
                { 139, 139, 139, 130, 130, 130, 130, 130, 130 },
                { 139, 139, 139, 130, 130, 130, 130, 130, 130 },
                { 139, 139, 139, 130, 130, 130, 130, 130, 130 },
                { 139, 139, 139, 130, 130, 130, 130, 130, 130 }
            };

            int[,] result = testImage.readImage(new Bitmap(@"images\mario.png"));

            Assert.AreEqual(result, expected);
        }
    }
}