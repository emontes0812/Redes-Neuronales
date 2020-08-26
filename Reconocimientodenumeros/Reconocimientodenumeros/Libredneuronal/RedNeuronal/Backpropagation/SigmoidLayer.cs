using System;
using System.Runtime.Serialization;
using Libredneuronal.RedNeuronal.Initializers;

namespace Libredneuronal.RedNeuronal.Backpropagation
{
    [Serializable]
    public class SigmoidLayer : ActivationLayer
    {
        /// <summary>
        /// Construye una nueva capa Sigmoidal que contiene un numero especifico de neuronas
        /// </summary>
        public SigmoidLayer(int neuronCount)
            : base(neuronCount)
        {
            this.initializer = new NguyenWidrowFunction();
        }


        public override double Activate(double input, double previousOutput)
        {
            return 1d / (1 + Math.Exp(-input));
        }

        public override double Derivative(double input, double output)
        {
            return output * (1 - output);
        }

        public SigmoidLayer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}