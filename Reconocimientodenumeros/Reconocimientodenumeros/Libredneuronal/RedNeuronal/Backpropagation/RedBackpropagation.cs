using System;
using System.Runtime.Serialization;

namespace Libredneuronal.RedNeuronal.Backpropagation
{
    [Serializable]
    public class RedBackpropagation : Network
    {
        private double meanSquaredError;
        private bool isValidMSE;

        public double MeanSquaredError
        {
            get { return isValidMSE ? meanSquaredError : 0d; }
        }

        public RedBackpropagation(ActivationLayer inputLayer, ActivationLayer outputLayer)
            : base(inputLayer, outputLayer, TrainingMethod.Supervised)
        {
            this.meanSquaredError = 0d;
            this.isValidMSE = false;
        }
        public RedBackpropagation(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

 
        public override void Learn(Entrenamiento trainingSample, int currentIteration, int trainingEpochs)
        {
            meanSquaredError = 0d;
            isValidMSE = true;
            base.Learn(trainingSample, currentIteration, trainingEpochs);
        }
        protected override void OnBeginEpoch(int currentIteration, Ajusteentrenamiento trainingSet)
        {
            meanSquaredError = 0d;
            isValidMSE = false;
            base.OnBeginEpoch(currentIteration, trainingSet);
        }

        protected override void OnEndEpoch(int currentIteration, Ajusteentrenamiento trainingSet)
        {
            meanSquaredError /= trainingSet.TrainingSampleCount;
            isValidMSE = true;
            base.OnEndEpoch(currentIteration, trainingSet);
        }

        protected override void LearnSample(Entrenamiento trainingSample, int currentIteration, int trainingEpochs)
        {
            // No validation here
            int layerCount = layers.Count;

            // Set input vector
            inputLayer.SetInput(trainingSample.InputVector);

            for (int i = 0; i < layerCount; i++)
            {
                layers[i].Run();
            }

            // Set Errors
            meanSquaredError += (outputLayer as ActivationLayer).SetErrors(trainingSample.OutputVector);

            // Backpropagate errors
            for (int i = layerCount; i > 0; )
            {
                ActivationLayer layer = layers[--i] as ActivationLayer;
                if (layer != null)
                {
                    layer.EvaluateErrors();
                }
            }

            // Optimize synapse weights and neuron bias values
            for (int i = 0; i < layerCount; i++)
            {
                layers[i].Learn(currentIteration, trainingEpochs);
            }
        }
    }
}