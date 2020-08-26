using System;
using System.Runtime.Serialization;

namespace Libredneuronal.RedNeuronal
{

    [Serializable]
    public class Entrenamiento : ISerializable
    {
        private readonly double[] inputVector;
        private readonly double[] outputVector;
        private readonly double[] normalizedInputVector;
        private readonly double[] normalizedOutputVector;
        private readonly int hashCode;

 
        public double[] InputVector
        {
            get { return inputVector; }
        }
        public double[] OutputVector
        {
            get { return outputVector; }
        }

        public double[] NormalizedInputVector
        {
            get { return normalizedInputVector; }
        }

        public double[] NormalizedOutputVector
        {
            get { return normalizedOutputVector; }
        }

        public Entrenamiento(double[] vector)
            : this(vector, new double[0])
        {
        }


        public Entrenamiento(double[] inputVector, double[] outputVector)
        {
            // Validate
            Helper.ValidateNotNull(inputVector, "inputVector");
            Helper.ValidateNotNull(outputVector, "outputVector");

            // Clone and initialize
            this.inputVector = (double[])inputVector.Clone();
            this.outputVector = (double[])outputVector.Clone();

            // Some neural networks require inputs in normalized form.
            // As an optimization measure, we normalize and store training samples
            this.normalizedInputVector = Helper.Normalize(inputVector);
            this.normalizedOutputVector = Helper.Normalize(outputVector);

            // Calculate the hash code
            hashCode = 0;
            for (int i = 0; i < inputVector.Length; i++)
            {
                hashCode ^= inputVector[i].GetHashCode();
            }
        }

        public Entrenamiento(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            this.inputVector = (double[])info.GetValue("inputVector", typeof(double[]));
            this.outputVector = (double[])info.GetValue("outputVector", typeof(double[]));
            this.normalizedInputVector = Helper.Normalize(inputVector);
            this.normalizedOutputVector = Helper.Normalize(outputVector);

            hashCode = 0;
            for (int i = 0; i < inputVector.Length; i++)
            {
                hashCode ^= inputVector[i].GetHashCode();
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            info.AddValue("inputVector", inputVector, typeof(double[]));
            info.AddValue("outputVector", outputVector, typeof(double[]));
        }


        public override bool Equals(object obj)
        {
            if (obj is Entrenamiento)
            {
                Entrenamiento sample = (Entrenamiento)obj;
                int size;
                if ((size = sample.inputVector.Length) == inputVector.Length)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (inputVector[i] != sample.inputVector[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }


        public override int GetHashCode()
        {
            return hashCode;
        }
    }
}
