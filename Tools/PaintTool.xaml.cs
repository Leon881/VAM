using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;


namespace Multiplector.Tools
{
    /// <summary>
    /// Логика взаимодействия для PaintTool.xaml
    /// </summary>
    public partial class PaintTool : UserControl
    {
        Color SelectedColor = Colors.Black;

        public PaintTool()
        {
            //InitializeComponent();
        }

        private void BlackColor_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Black;
            SelectedColor = Colors.Black;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }       

        private void WhiteColor_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.White;
            SelectedColor = Colors.White;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void GrayLight_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.LightGray;
            SelectedColor = Colors.LightGray;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void GrayDark_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.DarkGray;
            SelectedColor = Colors.DarkGray;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Brown_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Brown;
            SelectedColor = Colors.Brown;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void RosyBrown_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.RosyBrown;
            SelectedColor = Colors.RosyBrown;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Red;
            SelectedColor = Colors.Red;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
            
        }

        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Pink;
            SelectedColor = Colors.Pink;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Orange;
            SelectedColor = Colors.Orange;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Yellow;
            SelectedColor = Colors.Yellow;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Green;
            SelectedColor = Colors.Green;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void LightGreen_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.LightGreen;
            SelectedColor = Colors.LightGreen;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
            SelectedColor = Colors.Blue;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void LightBlue_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = Colors.DarkBlue;
            SelectedColor = Colors.DarkBlue;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void CbxThickness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxThickness.SelectedIndex == 0)
            {
                PaintCanvas.DefaultDrawingAttributes.Width = 1;
                PaintCanvas.DefaultDrawingAttributes.Height = 1;
            }
            else if (cbxThickness.SelectedIndex == 1)
            {
                PaintCanvas.DefaultDrawingAttributes.Width = 3;
                PaintCanvas.DefaultDrawingAttributes.Height = 3;
            }
            else if (cbxThickness.SelectedIndex == 2)
            {
                PaintCanvas.DefaultDrawingAttributes.Width = 5;
                PaintCanvas.DefaultDrawingAttributes.Height = 5;
            }
            else if (cbxThickness.SelectedIndex == 3)
            {
                PaintCanvas.DefaultDrawingAttributes.Width = 7;
                PaintCanvas.DefaultDrawingAttributes.Height = 7;
            }
        }

        private void Pen_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.DefaultDrawingAttributes.Color = SelectedColor;
            PaintCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Eraser_Click(object sender, RoutedEventArgs e)
        {            
            PaintCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var openImage = new OpenFileDialog
            {
                Filter = "jpg files |*.jpg",
                FileName = "image"
            };

            var resultDialog = openImage.ShowDialog();

            if (resultDialog == true)
            {
                //Здесь должен быть код Открытия файла
                //Пока его нет :(
            }
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlgSave = new Microsoft.Win32.SaveFileDialog();
            dlgSave.FileName = "MultitoolPaintImage"; // Default file name
            dlgSave.DefaultExt = ".jpg"; // Default file extension
            dlgSave.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlgSave.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlgSave.FileName;
                //get the dimensions of the ink control       
                int margin = (int)this.PaintCanvas.Margin.Left;
                int width = (int)this.PaintCanvas.Width -margin;
                int height = (int)this.PaintCanvas.Height-margin;
                //render ink to bitmap
                RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                DrawingVisual drawingVisual = new DrawingVisual();
                using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                {
                    VisualBrush visualBrush = new VisualBrush(PaintCanvas);
                    drawingContext.DrawRectangle(visualBrush, null,
                        new Rect(new Point(0, 0), new Size(width, height)));
                }
                rtb.Render(drawingVisual);
                //saving bitmap
                using (FileStream savestream = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(savestream);
                }
            }
        }

        private void Cleaning_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.Strokes.Clear();
        }
    }
}
