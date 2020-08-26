using System;
using System.Runtime.Serialization;

namespace Libredneuronal.RedNeuronal.Backpropagation
{
    /// <summary>
    /// Capa de neuronas de activacion.
    /// </summary>
    [Serializable]
    public abstract class ActivationLayer : Layer<ActivationNeuron>
    {
        internal bool useFixedBiasValues = false;
        public bool UseFixedBiasValues
        {
            get { return useFixedBiasValues; }
            set { useFixedBiasValues = value; }
        }

        protected ActivationLayer(int neuronCount)
            : base(neuronCount)
        {
            for (int i = 0; i < neuronCount; i++)
            {
                neurons[i] = new ActivationNeuron(this);
            }
        }


        public ActivationLayer(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
            this.useFixedBiasValues = info.GetBoolean("useFixedBiasValues");

            double[] biasValues = (double[])info.GetValue("biasValues", typeof(double[]));
            for (int i = 0; i < biasValues.Length; i++)
            {
                neurons[i] = new ActivationNeuron(this);
                neurons[i].bias = biasValues[i];
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("useFixedBiasValues", useFixedBiasValues);

            double[] biasValues = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                biasValues[i] = neurons[i].bias;
            }

            info.AddValue("biasValues", biasValues, typeof(double[]));
        }

        public override void Initialize()
        {
            if (initializer != null)
            {
                initializer.Initialize(this);
            }
        }

        public double SetErrors(double[] expectedOutput)
        {
            // Validate
            Helper.ValidateNotNull(expectedOutput, "expectedOutput");
            if (expectedOutput.Length != neurons.Length)
            {
                throw new ArgumentException("Length of ouput array should be same as neuron count", "expectedOutput");
            }

            // Set errors, evaluate mean squared error
            double meanSquaredError = 0d;
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].error = expectedOutput[i] - neurons[i].output;
                meanSquaredError += neurons[i].error * neurons[i].error;
            }
            return meanSquaredError;
        }

        /// <summary>
        /// Evaluate errors at all neurons in the layer
        /// </summary>
        public void EvaluateErrors()
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].EvaluateError();
            }
        }

        public abstract double Activate(double input, double previousOutput);

        public abstract double Derivative(double input, double output);
    }
}
