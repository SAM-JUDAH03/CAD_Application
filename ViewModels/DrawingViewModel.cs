using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using CAD_Application.Helpers;
using CAD_Application.Models;

namespace CAD_Application.ViewModels
{
    /// <summary>
    /// ViewModel for managing drawing canvas operations, shapes, and drawing state.
    /// Handles all drawing, undo/redo, zoom, and canvas interactions.
    /// </summary>
    public class DrawingViewModel : ViewModelBase
    {
        private Canvas _drawingCanvas;
        private double _strokeWidth;
        private double _zoomFactor;
        private string _statusMessage;
        private SolidColorBrush _strokeBrush;
        private SolidColorBrush _fillBrush;
        private SolidColorBrush _canvasBackground;

        public Canvas DrawingCanvas
        {
            get => _drawingCanvas;
            set => SetProperty(ref _drawingCanvas, value);
        }

        public double StrokeWidth
        {
            get => _strokeWidth;
            set => SetProperty(ref _strokeWidth, Math.Max(DrawingState.MinWidth, Math.Min(DrawingState.MaxWidth, value)));
        }

        public double ZoomFactor
        {
            get => _zoomFactor;
            set => SetProperty(ref _zoomFactor, Math.Max(DrawingState.ZoomMin, Math.Min(DrawingState.ZoomMax, value)));
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public SolidColorBrush StrokeBrush
        {
            get => _strokeBrush;
            set => SetProperty(ref _strokeBrush, value);
        }

        public SolidColorBrush FillBrush
        {
            get => _fillBrush;
            set => SetProperty(ref _fillBrush, value);
        }

        public SolidColorBrush CanvasBackground
        {
            get => _canvasBackground;
            set => SetProperty(ref _canvasBackground, value);
        }

        public ObservableCollection<UIElement> ShapeCollection { get; }

        public DrawingViewModel()
        {
            ShapeCollection = new ObservableCollection<UIElement>();
            _strokeWidth = 2.0;
            _zoomFactor = 1.0;
            _statusMessage = "Ready";
            _strokeBrush = new SolidColorBrush(Colors.Black);
            _fillBrush = new SolidColorBrush(Colors.Transparent);
            _canvasBackground = new SolidColorBrush(Colors.White);
        }

        public void IncreaseStrokeWidth()
        {
            if (StrokeWidth < DrawingState.MaxWidth)
                StrokeWidth++;
        }

        public void DecreaseStrokeWidth()
        {
            if (StrokeWidth > DrawingState.MinWidth)
                StrokeWidth--;
        }

        public void ZoomIn()
        {
            ZoomFactor = Math.Min(DrawingState.ZoomMax, ZoomFactor + DrawingState.ZoomStep);
            StatusMessage = $"Zoom: {(int)(ZoomFactor * 100)}%";
        }

        public void ZoomOut()
        {
            ZoomFactor = Math.Max(DrawingState.ZoomMin, ZoomFactor - DrawingState.ZoomStep);
            StatusMessage = $"Zoom: {(int)(ZoomFactor * 100)}%";
        }

        public void ZoomReset()
        {
            ZoomFactor = 1.0;
            StatusMessage = "Zoom: 100%";
        }

        public void ClearCanvas()
        {
            if (DrawingCanvas != null)
            {
                DrawingCanvas.Children.Clear();
                ShapeCollection.Clear();
                StatusMessage = "Canvas cleared";
            }
        }

        public void AddShape(UIElement shape)
        {
            if (DrawingCanvas != null && shape != null)
            {
                DrawingCanvas.Children.Add(shape);
                ShapeCollection.Add(shape);
            }
        }

        public void RemoveShape(UIElement shape)
        {
            if (DrawingCanvas != null && shape != null && DrawingCanvas.Children.Contains(shape))
            {
                DrawingCanvas.Children.Remove(shape);
                ShapeCollection.Remove(shape);
            }
        }

        public void SetStrokeColor(Color color)
        {
            StrokeBrush = new SolidColorBrush(color);
        }

        public void SetFillColor(Color color)
        {
            FillBrush = new SolidColorBrush(color);
        }

        public void SetCanvasBackground(Color color)
        {
            CanvasBackground = new SolidColorBrush(color);
            if (DrawingCanvas != null)
                DrawingCanvas.Background = CanvasBackground;
        }

        public void UpdateStatus(string message)
        {
            StatusMessage = message;
        }
    }
}
