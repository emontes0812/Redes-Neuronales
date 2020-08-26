namespace Libredneuronal.RedNeuronal.Backpropagation
{

    public class BackpropagationSynapse : ISynapse
    {
        private double weight;
        private double delta;
        private readonly ActivationNeuron sourceNeuron;
        private readonly ActivationNeuron targetNeuron;
        private readonly ConexionBackpropagation parent;


        public ActivationNeuron SourceNeuron
        {
            get { return sourceNeuron; }
        }

        public ActivationNeuron TargetNeuron
        {
            get { return targetNeuron; }
        }

        INeuron ISynapse.SourceNeuron
        {
            get { return sourceNeuron; }
        }

        INeuron ISynapse.TargetNeuron
        {
            get { return targetNeuron; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public ConexionBackpropagation Parent
        {
            get { return parent; }
        }

        IConnector ISynapse.Parent
        {
            get { return parent; }
        }

        public BackpropagationSynapse(
            ActivationNeuron sourceNeuron, ActivationNeuron targetNeuron, ConexionBackpropagation parent)
        {
            Helper.ValidateNotNull(sourceNeuron, "sourceNeuron");
            Helper.ValidateNotNull(targetNeuron, "targetNeuron");
            Helper.ValidateNotNull(parent, "parent");

            this.weight = 1f;
            this.delta = 0f;

            sourceNeuron.TargetSynapses.Add(this);
            targetNeuron.SourceSynapses.Add(this);

            this.sourceNeuron = sourceNeuron;
            this.targetNeuron = targetNeuron;
            this.parent = parent;
        }


        public void Propagate()
        {
            targetNeuron.input += sourceNeuron.output * this.weight;
        }


        public void OptimizeWeight(double learningFactor)
        {
            delta = delta * parent.momentum + learningFactor * targetNeuron.error * sourceNeuron.output;
            weight += delta;
        }

        public void Backpropagate()
        {
            sourceNeuron.error += targetNeuron.error * this.weight;
        }


        public void Jitter(double jitterNoiseLimit)
        {
            weight += Helper.GetRandom(-jitterNoiseLimit, jitterNoiseLimit) ;
        }
    }
}