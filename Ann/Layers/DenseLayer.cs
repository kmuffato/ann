﻿using System;
using Ann.Persistence;
using Ann.Persistence.LayerConfig;
using Ann.Utils;
using Gdo;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Ann.Layers
{
    internal class DenseLayer : Layer, ILearnable
    {
        private readonly Matrix<double> _weights;
        private readonly Vector<double> _biases;
        private readonly Optimizer[,] _weightOptimizers;
        private readonly Optimizer[] _biasOptimizers;
        private readonly Vector<double> _dedx;
        private readonly Vector<double> _cache;

        public DenseLayer(DenseLayerConfiguration config)
            : base(config.MessageShape, new MessageShape(config.NumberOfNeurons))
        {
            _weightOptimizers = new Optimizer[config.NumberOfNeurons, config.MessageShape.Size];
            _weightOptimizers.UpdateForEach<Optimizer>((q, i) => config.Optimizer.Clone() as Optimizer);
            _biasOptimizers = new Optimizer[config.NumberOfNeurons];
            _biasOptimizers.UpdateForEach<Optimizer>((q, i) => config.Optimizer.Clone() as Optimizer);
            _weights = Matrix.Build.Dense(config.NumberOfNeurons, config.MessageShape.Size);
            _biases = Vector.Build.Dense(config.NumberOfNeurons);
            _dedx = Vector.Build.Dense(config.NumberOfNeurons);
            _cache = Vector.Build.Dense(config.MessageShape.Size);
        }

        public override LayerConfiguration GetLayerConfiguration()
        {
            return new DenseLayerConfiguration(InputMessageShape, OutputMessageShape.Size, GetWeights(), GetBiases());
        }

        public override Array PassBackward(Array input)
        {
            _dedx.SetValues(input);
            return _weights.TransposeThisAndMultiply(_dedx).ToArray();
        }

        public override Array PassForward(Array input)
        {
            _cache.SetValues(input);
            var X = Vector.Build.Dense(input as double[]);
            return _weights.Multiply(X).Add(_biases).ToArray();
        }

        public void RandomizeWeights(double stddev)
        {
            var dist = new Normal(0, stddev);
            _weights.MapInplace(q => dist.Sample());
        }

        public void SetBiases(Array array)
        {
            _biases.SetValues(array);
            _biases.ToArray().ForEach((q, i) => _biasOptimizers[i].SetValue(q));
        }

        public void SetWeights(Array array)
        {
            _weights.SetValues(array);
            _weights.ToArray().ForEach((q, i, j) => _weightOptimizers[i, j].SetValue(q));
        }

        public void UpdateBiases()
        {
            _biases.MapIndexedInplace((i, q) =>
            {
                var opt = _biasOptimizers[i];
                opt.Update(_dedx[i]);
                return opt.Value;
            });
        }

        public void UpdateWeights()
        {
            var m1 = Matrix.Build.DenseOfRowVectors(_cache);
            var m2 = Matrix.Build.DenseOfColumnVectors(_dedx);
            var m3 = m1.KroneckerProduct(m2);

            _weights.MapIndexedInplace((i, j, q) =>
            {
                var opt = _weightOptimizers[i, j];
                opt.Update(m3[i, j]);
                return opt.Value;
            });
        }

        public double[,] GetWeights()
        {
            return _weights.ToArray();
        }

        public double[] GetBiases()
        {
            return _biases.ToArray();
        }
    }
}