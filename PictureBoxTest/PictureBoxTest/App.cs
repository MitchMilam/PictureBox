using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PictureBoxView.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace PictureBoxTest
{
    public class App
    {
        public static Page GetMainPage()
        {
                var pictueBox = new PictureBox
                {
                    BoxHeight = 150,
                    BoxWidth = 100,
                    ImageName = "sample1.png",
                    ShowStack = true,
                    ShowShadow = true,
                };

                //pictueBox.SetBinding(PictureBox.ImageNameProperty, "sample1.png");
                //pictueBox.SetBinding(PictureBox.BoxHeightProperty, new GridLengthTypeConverter();
                //pictueBox.SetBinding(PictureBox.BoxWidthProperty, 100);

            return new ContentPage
            {
                Content = pictueBox
            };
        }
    }
}
