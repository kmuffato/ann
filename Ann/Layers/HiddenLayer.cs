﻿using Gdo;
using System.Linq;
using Activator = Ann.Activators.Activator;
using System;
using MathNet.Numerics.LinearAlgebra.Double;
using Ann.Utils;
using Ann.Activators;
using Gdo.Optimizers;
using Ann.Persistence.LayerConfig;
using Ann.Persistence;

namespace Ann.Layers
{
    public class HiddenLayer : NeuronLayer
    {
        private readonly Activator _activator;
        private readonly ActivatorType _activatorType;
        private readonly double[] _cache;

        internal HiddenLayer(HiddenLayerConfiguration config)
            : base(config.NumberOfNeurons, config.MessageShape, new Flat(0.1))
        {
            _activatorType = config.ActivatorType;
            _activator = ActivatorFactory.Produce(_activatorType);
            _cache = new double[config.NumberOfNeurons];
        }

        public HiddenLayer(
            int numberOfNeurons,
            ActivatorType activatorType,
            Optimizer optimizer,
            MessageShape inputMessageShape) 
            : base(numberOfNeurons, inputMessageShape, optimizer)
        {
            _activatorType = activatorType;
            _activator = ActivatorFactory.Produce(activatorType);
            _cache = new double[numberOfNeurons];
        }

        public override Array PassForward(Array input)
        {
            PrevLayerOutput = input;

            var X = Matrix.Build.Dense(1, input.Length, input.OfType<double>().ToArray());
            var W = GetWeightMatrix();
            var B = new DenseVector(Neurons.Select(q => q.Bias.Value).ToArray());

            var actInput = X.Multiply(W).Row(0).Add(B);

            actInput.AsArray().ForEach((q, i) => _cache[i] = q);

            var res = actInput.Map(q => _activator.CalculateValue(q)).ToArray();
            Neurons.ForEach((q, i) => q.Output = res[i]);

            return Neurons.Select(q => q.Output).ToArray();
        }

        public override Array PassBackward(Array error)
        {
            var W = GetWeightMatrix();
            Neurons.ForEach((q, i) => q.Delta = (double)error.GetValue(i) * _activator.CalculateDeriviative(_cache[i]));
            var dEdX = Neurons.Select(q => q.Delta).ToArray();
            var dEdO = Matrix.Build.Dense(1, dEdX.Length, dEdX);
            return dEdO.TransposeAndMultiply(W).Row(0).ToArray();
        }

        public override LayerConfiguration GetLayerConfiguration()
        {
            return new HiddenLayerConfiguration(
                InputMessageShape,
                Neurons.Count,
                GetWeights(),
                GetBiases(),
                _activatorType);

        }
    }
}