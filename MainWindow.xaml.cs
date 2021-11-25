using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Laba1.Models;
using Laba1.Models.Matrix;
using Microsoft.Win32;

namespace Laba1
{
    public partial class MainWindow
    {
        private const double PiDivOn180 = Math.PI / 180;

        private ObjectInfo _info;
        private string _targetFileName;

        private Matrix4x4 _translationMatrix;
        private Matrix4x4 _scaleMatrix;

        private Matrix4x4 _rotationXMatrix;
        private Matrix4x4 _rotationYMatrix;
        private Matrix4x4 _rotationZMatrix;

        private Matrix4x4 _viewMatrix;
        private Matrix4x4 _selectedProjectionMatrix;
        private Matrix4x4 _viewportMatrix;

        private float _currentTargetRotationX;
        private float _currentTargetRotationY;
        private float _currentTargetRotationZ;

        private float _currentTranslationX;
        private float _currentTranslationY;
        private float _currentTranslationZ;

        private float _currentCameraPositionX;
        private float _currentCameraPositionY;
        private float _currentCameraPositionZ = 7;

        private float _currentScalePositionX = 5;
        private float _currentScalePositionY = 5;
        private float _currentScalePositionZ = 5;

        private float _currentTargetPositionX;
        private float _currentTargetPositionY;
        private float _currentTargetPositionZ;

        public MainWindow()
        {
            InitializeComponent();
            RenderOptions.ProcessRenderMode = RenderMode.Default;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTargetRotationX = 0;
            _currentTargetRotationY = 0;
            _currentTargetRotationZ = 0;

            _currentTranslationX = 0;
            _currentTranslationY = 0;
            _currentTranslationZ = 0;

            _currentCameraPositionX = 0;
            _currentCameraPositionY = 0;
            _currentCameraPositionZ = 7;

            _currentScalePositionX = 5;
            _currentScalePositionY = 5;
            _currentScalePositionZ = 5;

            _currentTargetPositionX = 0;
            _currentTargetPositionY = 0;
            _currentTargetPositionZ = 0;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _info = ObjFileParser.GetObjectInfo(openFileDialog.FileName);
            }
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }

            Draw();

        }

        

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Rotation
                case Key.A:
                    _currentTargetRotationY += 3;
                    Draw();
                    break;
                case Key.D:
                    _currentTargetRotationY -= 3;
                    Draw();
                    break;
                case Key.W:
                    _currentTargetRotationX -= 3;
                    Draw();
                    break;
                case Key.S:
                    _currentTargetRotationX += 3;
                    Draw();
                    break;
                case Key.Q:
                    _currentTargetRotationZ -= 3;
                    Draw();
                    break;
                case Key.E:
                    _currentTargetRotationZ += 3;
                    Draw();
                    break;
                // Transition
                case Key.F:
                    _currentTranslationY += 1;
                    Draw();
                    break;
                case Key.H:
                    _currentTranslationY -= 1;
                    Draw();
                    break;
                case Key.T:
                    _currentTranslationX -= 1;
                    Draw();
                    break;
                case Key.G:
                    _currentTranslationX += 1;
                    Draw();
                    break;
                case Key.R:
                    _currentTranslationZ -= 1;
                    Draw();
                    break;
                case Key.Y:
                    _currentTranslationZ += 1;
                    Draw();
                    break;
                // Camera
                case Key.I:
                    _currentCameraPositionY += 1;
                    Draw();
                    break;
                case Key.K:
                    _currentCameraPositionY -= 1;
                    Draw();
                    break;
                case Key.J:
                    _currentCameraPositionX -= 1;
                    Draw();
                    break;
                case Key.L:
                    _currentCameraPositionX += 1;
                    Draw();
                    break;
                case Key.U:
                    _currentCameraPositionZ -= 1;
                    Draw();
                    break;
                case Key.O:
                    _currentCameraPositionZ += 1;
                    Draw();
                    break;
                // Scale
                case Key.Up:
                    _currentScalePositionY = (float) (_currentScalePositionY + 0.1);
                    Draw();
                    break;
                case Key.Down:
                    _currentScalePositionY = (float) (_currentScalePositionY - 0.1);
                    Draw();
                    break;
                case Key.Left:
                    _currentScalePositionX = (float) (_currentScalePositionX - 0.1);
                    Draw();
                    break;
                case Key.Right:
                    _currentScalePositionX = (float) (_currentScalePositionX + 0.1);
                    Draw();
                    break;
                case Key.NumPad1:
                    _currentScalePositionZ = (float) (_currentScalePositionZ - 0.1);
                    Draw();
                    break;
                case Key.NumPad2:
                    _currentScalePositionZ = (float) (_currentScalePositionZ + 0.1);
                    Draw();
                    break;
                // Target posotion
                case Key.NumPad8:
                    _currentTargetPositionY += 1;
                    Draw();
                    break;
                case Key.NumPad5:
                    _currentTargetPositionY -= 1;
                    Draw();
                    break;
                case Key.NumPad4:
                    _currentTargetPositionX -= 1;
                    Draw();
                    break;
                case Key.NumPad6:
                    _currentTargetPositionX += 1;
                    Draw();
                    break;
                case Key.NumPad7:
                    _currentTargetPositionZ -= 1;
                    Draw();
                    break;
                case Key.NumPad9:
                    _currentTargetPositionZ += 1;
                    Draw();
                    break;
            }
        }

        private void InitializeMatrix()
        {
            _translationMatrix = Matrix4x4.CreateTranslation(new Vector3(_currentTranslationX,
                _currentTranslationY, _currentTranslationZ));

            _scaleMatrix = Matrix4x4.CreateScale(new Vector3(_currentScalePositionX,
                _currentScalePositionY, _currentScalePositionZ));

            _rotationXMatrix =
                Matrix4x4.CreateRotationX((float) (_currentTargetRotationX * PiDivOn180));
            _rotationYMatrix =
                Matrix4x4.CreateRotationY((float) (_currentTargetRotationY * PiDivOn180));
            _rotationZMatrix =
                Matrix4x4.CreateRotationZ((float) (_currentTargetRotationZ * PiDivOn180));

            _viewMatrix =
                new Vector3(_currentCameraPositionX, _currentCameraPositionY, _currentCameraPositionZ)
                    .GetViewMatri4x4(new Vector3(_currentTargetPositionX, _currentTargetPositionY,
                        _currentTargetPositionZ));

            var camAspect = float.Parse(cameraAspect.Text, CultureInfo.InvariantCulture);
            var camFov = (float) (float.Parse(cameraFOV.Text) * PiDivOn180);

            var camZFar = float.Parse(cameraZFar.Text);
            var camZNear = float.Parse(cameraZNear.Text, CultureInfo.InvariantCulture);

            _viewportMatrix =
                Matrix4x4.Transpose(ViewPortMatrix4x4.Create(int.Parse(viewWidth.Text), int.Parse(viewHeight.Text),
                    int.Parse(viewXMin.Text),
                    int.Parse(viewYMin.Text)));
            _selectedProjectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(
                camFov, camAspect, camZNear, camZFar);
        }

        private static IEnumerable<Point> GetDdaPoints(Point firstPoint,
            Point secondPoint)
        {
            var points = new List<Point>();

            var intXFirstPoint = (int) Math.Round(firstPoint.X);
            var intYFirstPoint = (int) Math.Round(firstPoint.Y);
            var intXSecondPoint = (int) Math.Round(secondPoint.X);
            var intYSecondPoint = (int) Math.Round(secondPoint.Y);

            var deltaX = Math.Abs(intXFirstPoint - intXSecondPoint);
            var deltaY = Math.Abs(intYFirstPoint - intYSecondPoint);

            var length = Math.Max(deltaX, deltaY);

            if (length == 0)
            {
                points.Add(new Point(intXFirstPoint, intYFirstPoint));

                return points;
            }

            var dX = (secondPoint.X - firstPoint.X) / length;
            var dY = (secondPoint.Y - firstPoint.Y) / length;

            var x = firstPoint.X;
            var y = firstPoint.Y;

            length++;

            while (length-- != 0)
            {
                x += dX;
                y += dY;

                points.Add(new Point(Math.Round(x), Math.Round(y)));
            }

            return points;
        }

        private void Draw()
        {
            InitializeMatrix();

            var points = new Vector4[_info.Vertices.Length];
            var worldVertices = new Vector4[_info.Vertices.Length];
            var worldNormalVectors = new Vector4[_info.NormalVectors.Length];

            _info.Vertices.CopyTo(points, 0);
            _info.NormalVectors.CopyTo(worldNormalVectors, 0);

            var length = _info.Vertices.Length;

            Parallel.For(0, length, i =>
            {
                points[i] = Vector4.Transform(points[i], _translationMatrix);
                points[i] = Vector4.Transform(points[i],
                    Matrix4x4.Multiply(Matrix4x4.Multiply(_rotationZMatrix, _rotationYMatrix), _rotationXMatrix));
                points[i] = Vector4.Transform(points[i], _scaleMatrix);
            });

            var lengthNormals = _info.NormalVectors.Length;

            Parallel.For(0, lengthNormals,
                i =>
                {
                    worldNormalVectors[i] = Vector4.Transform(worldNormalVectors[i],
                        Matrix4x4.Multiply(Matrix4x4.Multiply(_rotationZMatrix, _rotationYMatrix), _rotationXMatrix));
                });

            points.CopyTo(worldVertices, 0);

            Parallel.For(0, length, i =>
            {
                points[i] = Vector4.Transform(points[i], _viewMatrix);
                points[i] = Vector4.Transform(points[i], _selectedProjectionMatrix);
                points[i] = Vector4.Transform(points[i], _viewportMatrix);

                points[i].X /= points[i].W;
                points[i].Y /= points[i].W;
                points[i].Z /= points[i].W;
            });

            DrawAllPolygons(points);
        }

        private void DrawAllPolygons(IReadOnlyList<Vector4> points)
        {
            var polygonsCount = _info.Polygons.Length;
            var wbm = new WriteableBitmap((int) mainImage.Width, (int) mainImage.Height, 96, 96,
                PixelFormats.Bgra32, null);
            var source = new Bgra32Bitmap(wbm);

            source.Source.Lock();

            for (var i = 0; i < polygonsCount; i++)
            {
                DrawLinesInPolygon(i, points, ref source);
            }

            source.Source.AddDirtyRect(new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight));
            source.Source.Unlock();
            mainImage.Source = source.Source;
        }

        private void DrawLinesInPolygon(int index, IReadOnlyList<Vector4> points, ref Bgra32Bitmap source)
        {
            var currentPolygon = _info.Polygons[index];
            var polygonLength = currentPolygon.VertexIndices.Length;

            var blackColor = new Vector4(0, 0, 0, 255);

            for (var j = 0; j < polygonLength; j++)
            {
                var firstPointIndex = currentPolygon.VertexIndices[j] - 1;
                var secondPointIndex = currentPolygon.VertexIndices[(j + 1) % polygonLength] - 1;

                var firstPointZ = points[(int)firstPointIndex].Z;
                var secondPointZ = points[(int)secondPointIndex].Z;

                if (!(firstPointZ >= 0) || !(firstPointZ <= 1) || !(secondPointZ >= 0) ||
                    !(secondPointZ <= 1))
                {
                    continue;
                }

                var x = (int) points[(int)currentPolygon.VertexIndices[j] - 1].X;
                var y = (int) points[(int)currentPolygon.VertexIndices[j] - 1].Y;
                var firstPoint = new Point(x, y);

                x = (int) points[(int)currentPolygon.VertexIndices[(j + 1) % polygonLength] - 1].X;
                y = (int) points[(int)currentPolygon.VertexIndices[(j + 1) % polygonLength] - 1].Y;

                var secondPoint = new Point(x, y);

                var linePoints = GetDdaPoints(firstPoint, secondPoint);

                foreach (var linePoint in linePoints)
                {
                    source[(int) linePoint.X, (int) linePoint.Y] = blackColor;
                }
            }
        }
        private void cameraAspect_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void viewWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void viewHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void viewXMin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void viewYMin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void cameraZNear_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void cameraZFar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }

        private void cameraFOV_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_info?.Polygons == null || _info.Polygons.Length == 0)
            {
                return;
            }
            Draw();
        }
    }
}