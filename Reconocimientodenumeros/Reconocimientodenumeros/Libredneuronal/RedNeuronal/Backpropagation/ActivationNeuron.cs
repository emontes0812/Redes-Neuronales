using System.Collections.Generic;

namespace Libredneuronal.RedNeuronal.Backpropagation
{

    public class ActivationNeuron : INeuron
    {
        internal double input;
        internal double output;
        internal double error;
        internal double bias;

        private readonly IList<ISynapse> sourceSynapses = new List<ISynapse>();
        private readonly IList<ISynapse> targetSynapses = new List<ISynapse>();

        private ActivationLayer parent;

        public double Input
        {
            get { return input; }
            set { input = value; }
        }

        public double Output
        {
            get { return output; }
        }

        public double Error
        {
            get { return error; }
        }


        public double Bias
        {
            get { return bias; }
        }

        public IList<ISynapse> SourceSynapses
        {
            get { return sourceSynapses; }
        }

        public IList<ISynapse> TargetSynapses
        {
            get { return targetSynapses; }
        }


        public ActivationLayer Parent
        {
            get { return parent; }
        }

        ILayer INeuron.Parent
        {
            get { return parent; }
        }

        public ActivationNeuron(ActivationLayer parent)
        {
            Helper.ValidateNotNull(parent, "parent");

            this.input = 0d;
            this.output = 0d;
            this.error = 0d;
            this.bias = 0d;
            this.parent = parent;
        }


        public void Run()
        {
            if (sourceSynapses.Count > 0)
            {
                input = 0d;
                for (int i = 0; i < sourceSynapses.Count; i++)
                {
                    sourceSynapses[i].Propagate();
                }
            }
            output = parent.Activate(bias + input, output);
        }

        public void EvaluateError()
        {
            if (targetSynapses.Count > 0)
            {
                error = 0d;
                foreach (BackpropagationSynapse synapse in targetSynapses)
                {
                    synapse.Backpropagate();
                }
            }
            error *= parent.Derivative(input, output);
        }

 
        public void Learn(double learningRate)
        {
            if (!parent.useFixedBiasValues)
            {
                bias += learningRate * error;
            }
            for (int i = 0; i < sourceSynapses.Count; i++)
            {
                sourceSynapses[i].OptimizeWeight(learningRate);
            }
        }
    }
}
