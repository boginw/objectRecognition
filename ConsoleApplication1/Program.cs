﻿using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApplication1{
    class Program{

        private static Bitmap img;
        private static string file = "../../../cup.png";

        static void Main(string[] args){
            Console.WriteLine("Loading image...");
            try{
                img = new Bitmap(file);
            } catch (ArgumentException e){
                Console.WriteLine(
                    "{0}: {1}, probable cause is that the file wasn't found", 
                    e.GetType().Name, 
                    e.Message
                );

                return;
            }

            img = new ImageProccessing(img)
                .resize(500,500)
                .convertToBlackAndWhite()
                .Gaussian(1.5, 5)
                .SobelSupression()
                .Limit(60, 60, 60)
                .nonMaximumSurrpression()
                .build();

            img.Save("cup_result.png", ImageFormat.Png);

            Bitmap merged = resultMerge(new ImageProccessing(new Bitmap(file)).resize(500,500).build(), img);

            merged.Save("beforeAndAfter.png",ImageFormat.Png);

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
       

        static Bitmap resultMerge(Bitmap image1, Bitmap image2) {

            Bitmap bitmap = new Bitmap(
                image1.Width + image2.Width, 
                Math.Max(image1.Height, image2.Height)
            );

            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.DrawImage(image1, 0, 0);
                g.DrawImage(image2, image1.Width, 0);
            }

            return bitmap;
        }
    }
}