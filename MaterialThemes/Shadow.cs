using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MaterialThemes
{
    [TemplatePart(Name = CanvasControlPartName, Type = typeof(CanvasControl))]
    [TemplatePart(Name = ContentPresenterPartName, Type = typeof(ContentPresenter))]
    public sealed class Shadow : ContentControl
    {
        private CanvasControl _canvasControl;
        private ContentPresenter _contentPresenter;
        private const string ContentPresenterPartName = "PART_ContentPresenter";
        private const string CanvasControlPartName = "PART_CanvasControl";

        public Shadow()
        {
            DefaultStyleKey = typeof(Shadow);
            Unloaded += OnUnloaded;
        }

        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (_canvasControl == null)
            {
                return;
            }

            _canvasControl.RemoveFromVisualTree();
            _canvasControl = null;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvasControl = GetTemplateChild(CanvasControlPartName) as CanvasControl;
            if (_canvasControl != null)
            {
                _canvasControl.Draw += Draw;
            }

            _contentPresenter = GetTemplateChild(ContentPresenterPartName) as ContentPresenter;
        }

        private void Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            if (_contentPresenter == null)
            {
                return;
            }

            Border border = VisualTreeHelper.GetChild(_contentPresenter, 0) as Border;
            if (border == null)
            {
                return;
            }

            Point borderPoint = border.TransformToVisual(this).TransformPoint(new Point(0, 0));

            CanvasCommandList cl = new CanvasCommandList(sender);
            using (CanvasDrawingSession clds = cl.CreateDrawingSession())
            {
                clds.FillRoundedRectangle(new Rect(borderPoint.X, borderPoint.Y, border.ActualWidth, border.ActualHeight), (float)border.CornerRadius.TopLeft, (float)border.CornerRadius.TopLeft, Color.FromArgb(128, 0, 0, 0));
            }

            Transform2DEffect shadowEffect = new Transform2DEffect
            {
                Source =
                    new Transform2DEffect
                    {
                        Source = new ShadowEffect
                        {
                            BlurAmount = 2,
                            ShadowColor = Color.FromArgb(160, 0, 0, 0),
                            Source = cl
                        },
                        TransformMatrix = Matrix3x2.CreateScale(1.0f, new Vector2((float)(border.ActualWidth / 2), ((float)border.ActualHeight / 2)))

                    },
                TransformMatrix = Matrix3x2.CreateTranslation(0, 1)
            };

            args.DrawingSession.DrawImage(shadowEffect);
        }
    }
}
