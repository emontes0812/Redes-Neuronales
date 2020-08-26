using System;

namespace Libredneuronal.RedNeuronal
{

    internal static class Helper
    {
        private static readonly Random random = new Random();

        internal static void ValidateNotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }


        internal static void ValidateEnum(Type enumType, object value, string name)
        {
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentException("The argument should be a valid enumerator", name);
            }
        }


        internal static void ValidateNotNegative(double value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentException("The argument should be non-negative", name);
            }
        }


        internal static void ValidatePositive(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The argument should be non-zero positive", name);
            }
        }


        internal static void ValidateWithinRange(double value, double min, double max, string name)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }


        internal static double GetRandom()
        {
            return random.NextDouble();
        }


        internal static double GetRandom(double min, double max)
        {
            if (min > max)
            {
                return GetRandom(max, min);
            }
            return (min + (max - min) * random.NextDouble());
        }


        internal static int[] GetRandomOrder(int size)
        {
            int[] randomOrder = new int[size];

            
            for (int i = 0; i < size; i++)
            {
                randomOrder[i] = i;
            }

            
            for (int i = 0; i < size; i++)
            {
                int randomPosition = random.Next(size);
                int temp = randomOrder[i];
                randomOrder[i] = randomOrder[randomPosition];
                randomOrder[randomPosition] = temp;
            }
            return randomOrder;
        }


        internal static double[] Normalize(double[] vector)
        {
            return Normalize(vector, 1d);
        }

 
        internal static double[] Normalize(double[] vector, double magnitude)
        {
    
            double factor = 0d;
            for (int i = 0; i < vector.Length; i++)
            {
                factor += vector[i] * vector[i];
            }

            double[] normalizedVector = new double[vector.Length];
            if (factor != 0)
            {
                factor = Math.Sqrt(magnitude / factor);
                for (int i = 0; i < normalizedVector.Length; i++)
                {
                    normalizedVector[i] = vector[i] * factor;
                }
            }
            return normalizedVector;
        }


        internal static double[] GetRandomVector(int count, double magnitude)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Helper.GetRandom();
            }
            return Normalize(result, magnitude);
        }
    }
}