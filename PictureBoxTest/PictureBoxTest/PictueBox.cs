using Xamarin.Forms;

namespace PictureBoxTest
{
    /// <summary>
    /// PictureBoxView Interface
    /// </summary>
    public class PictureBox : ContentView
    {
        public static BindableProperty ImageNameProperty = BindableProperty.Create<PictureBox, string>(view => view.ImageName, null, propertyChanged: HandleImageSourceChanged);
        public static BindableProperty BoxWidthProperty = BindableProperty.Create<PictureBox, int>(view => view.BoxWidth, 100, propertyChanged: HandleBoxWidthChanged);
        public static BindableProperty BoxHeightProperty = BindableProperty.Create<PictureBox, int>(view => view.BoxHeight, 100, propertyChanged: HandleBoxHeightChanged);
        public static BindableProperty ShowStackProperty = BindableProperty.Create<PictureBox, bool>(view => view.ShowStack, true, propertyChanged: HandleShowStackeChanged);
        public static BindableProperty ShowShadowProperty = BindableProperty.Create<PictureBox, bool>(view => view.ShowShadow, false, propertyChanged: HandleShowShadowChanged);

        public string ImageName
        {
            get { return (string)GetValue(ImageNameProperty); }
            set { SetValue(ImageNameProperty, value); }
        }

        public int BoxWidth
        {
            get { return (int)GetValue(BoxWidthProperty); }
            set { SetValue(BoxWidthProperty, value); }
        }

        public int BoxHeight
        {
            get { return (int)GetValue(BoxHeightProperty); }
            set { SetValue(BoxHeightProperty, value); }
        }
        public bool ShowStack
        {
            get { return (bool)GetValue(ShowStackProperty); }
            set { SetValue(ShowStackProperty, value); }
        }

        public bool ShowShadow
        {
            get { return (bool)GetValue(ShowShadowProperty); }
            set { SetValue(ShowShadowProperty, value); }
        }

        private Image MainImage;
        private Grid MainGrid;
        private Frame FrameImage;
        private Frame FrameBackground1;
        private Frame FrameBackground2;

        public PictureBox()
        {
            var frameStyle = BuildFrameStyle();

            MainImage = new Image
            {
                Aspect = Aspect.AspectFill,
            };

            FrameImage = new Frame
            {
                Content = MainImage,
                Style = frameStyle,
                Padding = new Thickness(5),     // BUG: Frame padding ignore in Style??
                HasShadow = ShowShadow,
            };

            MainGrid = new Grid
            {
                RowSpacing = 0,
                Padding = new Thickness(0, 0, 0, 0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(BoxHeight) });
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(BoxWidth) });

            FrameBackground1 = new Frame
            {
                Style = frameStyle,
            };

            FrameBackground2 = new Frame
            {
                Style = frameStyle,

            };

            FrameBackground1.RotateTo(3.0);
            FrameBackground2.RotateTo(6.0);

            MainGrid.Children.Add(FrameBackground2, 0, 0);
            MainGrid.Children.Add(FrameBackground1, 0, 0);

            MainGrid.Children.Add(FrameImage, 0, 0);

            Content = MainGrid;
        }

        private static void HandleImageSourceChanged(BindableObject bindable, string oldValue, string newValue)
        {
            var view = (PictureBox)bindable;

            view.MainImage.Source = newValue;
        }

        private static void HandleShowShadowChanged(BindableObject bindable, bool oldValue, bool newValue)
        {
            var view = (PictureBox)bindable;

            view.FrameImage.HasShadow = newValue;
        }

        private static void HandleShowStackeChanged(BindableObject bindable, bool oldValue, bool newValue)
        {
            var view = (PictureBox)bindable;

            view.FrameBackground1.IsVisible = newValue;
            view.FrameBackground2.IsVisible = newValue;
        }

        private static void HandleBoxWidthChanged(BindableObject bindable, int oldValue, int newValue)
        {
            var view = (PictureBox)bindable;

            view.MainGrid.ColumnDefinitions[0].Width = newValue;
        }

        private static void HandleBoxHeightChanged(BindableObject bindable, int oldValue, int newValue)
        {
            var view = (PictureBox)bindable;

            view.MainGrid.RowDefinitions[0].Height = newValue;
        }

        private Style BuildFrameStyle()
        {
            var frameStyle = new Style(typeof(Frame))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = PaddingProperty,
                        Value = new Thickness(5)
                    },
                    new Setter
                    {
                        Property = Frame.HasShadowProperty,
                        Value = false
                    },
                    new Setter
                    {
                        Property = Frame.OutlineColorProperty,
                        Value = Color.Black
                    },
                    new Setter
                    {
                        Property = HeightRequestProperty,
                        Value = BoxHeight
                    },
                    new Setter
                    {
                        Property = MinimumHeightRequestProperty,
                        Value = BoxHeight
                    },
                    new Setter
                    {
                        Property = WidthRequestProperty,
                        Value = BoxWidth
                    },
                    new Setter
                    {
                        Property = MinimumWidthRequestProperty,
                        Value = BoxWidth
                    },
                    new Setter
                    {
                        Property = BackgroundColorProperty,
                        Value = Color.White
                    },
                }
            };

            return frameStyle;
        }
    }
}
