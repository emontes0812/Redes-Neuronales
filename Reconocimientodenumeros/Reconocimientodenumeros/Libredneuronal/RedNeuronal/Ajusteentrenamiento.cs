using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Libredneuronal.RedNeuronal
{

    [Serializable]
    public sealed class Ajusteentrenamiento : ISerializable
    {
        private readonly int inputVectorLength;
        private readonly int outputVectorLength;
        private readonly IList<Entrenamiento> trainingSamples;

        public int TrainingSampleCount
        {
            get { return trainingSamples.Count; }
        }


        public int InputVectorLength
        {
            get { return inputVectorLength; }
        }

        public int OutputVectorLength
        {
            get { return outputVectorLength; }
        }

        public IEnumerable<Entrenamiento> TrainingSamples
        {
            get
            {
                for (int i = 0; i < trainingSamples.Count; i++)
                {
                    yield return trainingSamples[i];
                }
            }
        }


        public Entrenamiento this[int index]
        {
            get { return trainingSamples[index]; }
        }


        public Ajusteentrenamiento(int vectorSize)
            : this(vectorSize, 0)
        {
        }

        public Ajusteentrenamiento(int inputVectorLength, int outputVectorLength)
        {
            // Validation
            Helper.ValidatePositive(inputVectorLength, "inputVectorLength");
            Helper.ValidateNotNegative(outputVectorLength, "outputVectorLength");

            // Initialize instance variables
            this.inputVectorLength = inputVectorLength;
            this.outputVectorLength = outputVectorLength;
            this.trainingSamples = new List<Entrenamiento>();
        }

        public Ajusteentrenamiento(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            this.inputVectorLength = info.GetInt32("inputVectorLength");
            this.outputVectorLength = info.GetInt32("outputVectorLength");
            this.trainingSamples = info.GetValue("trainingSamples", typeof(IList<Entrenamiento>)) as IList<Entrenamiento>;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            info.AddValue("inputVectorLength", inputVectorLength);
            info.AddValue("outputVectorLength", outputVectorLength);
            info.AddValue("trainingSamples", trainingSamples, typeof(IList<Entrenamiento>));
        }

        public void Add(Entrenamiento sample)
        {
            // Validation
            Helper.ValidateNotNull(sample, "sample");
            if (sample.InputVector.Length != inputVectorLength)
            {
                throw new ArgumentException
                    ("Input vector must be of size " + inputVectorLength, "sample");
            }
            if (sample.OutputVector.Length != outputVectorLength)
            {
                throw new ArgumentException
                    ("Output vector must be of size " + outputVectorLength, "sample");
            }

            // Note that the reference is being added. (Sample is immutable)
            trainingSamples.Add(sample);
        }

        public bool Remove(double[] inputVector)
        {
            return Remove(new Entrenamiento(inputVector));
        }

        public bool Remove(Entrenamiento sample)
        {
            return trainingSamples.Remove(sample);
        }

        public bool Contains(double[] inputVector)
        {
            return Contains(new Entrenamiento(inputVector));
        }

        public bool Contains(Entrenamiento sample)
        {
            return trainingSamples.Contains(sample);
        }

        public void Clear()
        {
            trainingSamples.Clear();
        }
    }
}