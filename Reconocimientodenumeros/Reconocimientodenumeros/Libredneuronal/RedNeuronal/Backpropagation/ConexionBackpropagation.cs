using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Libredneuronal.RedNeuronal.Backpropagation
{
    [Serializable]
    public class ConexionBackpropagation
        : Connector<ActivationLayer, ActivationLayer,BackpropagationSynapse>
    {
        internal double momentum = 0.07d;

        public double Momentum
        {
            get { return momentum; }
            set { momentum = value; }
        }

        public ConexionBackpropagation(ActivationLayer sourceLayer, ActivationLayer targetLayer)
            : this(sourceLayer, targetLayer, ConnectionMode.Complete)
        {
        }

        public ConexionBackpropagation(ActivationLayer sourceLayer, ActivationLayer targetLayer, ConnectionMode connectionMode)
            : base(sourceLayer, targetLayer, connectionMode)
        {
            ConstructSynapses();
        }

        public ConexionBackpropagation(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ConstructSynapses();

            this.momentum = info.GetDouble("momentum");
            double[] weights = (double[])info.GetValue("weights", typeof(double[]));

            for (int i = 0; i < synapses.Length; i++)
            {
                synapses[i].Weight = weights[i];
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("momentum", momentum);

            double[] weights = new double[synapses.Length];
            for (int i = 0; i < synapses.Length; i++)
            {
                weights[i] = synapses[i].Weight;
            }

            info.AddValue("weights", weights, typeof(double[]));
        }

        public override void Initialize()
        {
            if (initializer != null)
            {
                initializer.Initialize(this);
            }
        }

        private void ConstructSynapses()
        {
            int i = 0;
            if (connectionMode == ConnectionMode.Complete)
            {
                foreach (ActivationNeuron targetNeuron in targetLayer.Neurons)
                {
                    foreach (ActivationNeuron sourceNeuron in sourceLayer.Neurons)
                    {
                        synapses[i++] = new BackpropagationSynapse(sourceNeuron, targetNeuron, this);
                    }
                }
            }
            else
            {
                IEnumerator<ActivationNeuron> sourceEnumerator = sourceLayer.Neurons.GetEnumerator();
                IEnumerator<ActivationNeuron> targetEnumerator = targetLayer.Neurons.GetEnumerator();
                while (sourceEnumerator.MoveNext() && targetEnumerator.MoveNext())
                {
                    synapses[i++] = new BackpropagationSynapse(
                        sourceEnumerator.Current, targetEnumerator.Current, this);
                }
            }
        }
    }
}