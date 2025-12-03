using System;

namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;
    }

    public class Segment
    {
        public Vector Begin; // Начальная точка отрезка
        public Vector End;   // Конечная точка отрезка
    }

    public static class Geometry
    {
        // Метод для вычисления длины вектора
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        // Метод для сложения двух векторов
        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector
            {
                X = vector1.X + vector2.X,
                Y = vector1.Y + vector2.Y
            };
        }

        // Метод для вычисления длины отрезка
        public static double GetLength(Segment segment)
        {
            double deltaX = segment.End.X - segment.Begin.X;
            double deltaY = segment.End.Y - segment.Begin.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        // Метод для проверки, находится ли точка на отрезке
        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            // Создаем два вспомогательных отрезка
            Segment segment1 = new Segment { Begin = segment.Begin, End = vector };
            Segment segment2 = new Segment { Begin = vector, End = segment.End };

            // Суммируем длины вспомогательных отрезков
            double sum = GetLength(segment1) + GetLength(segment2);

            // Проверяем равенство суммы длине исходного отрезка
            return Math.Abs(sum - GetLength(segment)) < 1e-10; // Учитываем погрешность вычислений
        }
    }
}
