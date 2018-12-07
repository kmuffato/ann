﻿using Ann.Utils;
using Gdo;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;

namespace Ann.Layers.Dense
{
    class DenseFullLayer : DenseForwardLayer, IFullLayer, ILearnable
    {
        private readonly Optimizer[,] _weightOptimizers;
        private readonly Optimizer[] _biasOptimizers;
        private readonly Vector<double> _cache;

        public DenseFullLayer(
            MessageShape inputMessageShape, 
            int numberOfNeurons,
            Optimizer optimizer) 
            : base(inputMessageShape, numberOfNeurons)
        {
            _weightOptimizers = new Optimizer[inputMessageShape.Size, numberOfNeurons];
            _weightOptimizers.UpdateForEach<Optimizer>((q, i) => optimizer.Clone() as Optimizer);
            _biasOptimizers = new Optimizer[numberOfNeurons];
            _biasOptimizers.UpdateForEach<Optimizer>((q, i) => optimizer.Clone() as Optimizer);
            _cache = Vector.Build.Dense(inputMessageShape.Size);
        }

        public Array PassBackward(Array error)
        {
            var dedx = Vector.Build.Dense(error as double[]);

            var m1 = Matrix.Build.DenseOfColumnVectors(_cache);
            var m2 = Matrix.Build.DenseOfRowVectors(dedx);

            _biasOptimizers.ForEach((q, i) => q.SetGradient(dedx[i]));

            m1.KroneckerProduct(m2)
                .ToArray()
                .ForEach((q, i, j) => _weightOptimizers[i, j].SetGradient(q));

            return Weights.Multiply(dedx).ToArray();
        }

        public new Array PassForward(Array input)
        {
            _cache.SetValues(input);
            return base.PassForward(input);
        }

        public void RandomizeWeights(double stddev)
        {
            var dist = new Normal(0, stddev);
            Weights.MapInplace(q => dist.TruncatedNormalSample());
            _weightOptimizers.ForEach((q, i, j) => q.SetValue(Weights[i, j]));
        }

        public void SetBiases(double[] array)
        {
            Biases.SetValues(array);
            Biases.ToArray().ForEach((q, i) => _biasOptimizers[i].SetValue(q));
        }

        public void SetWeights(Array array)
        {
            Weights.SetValues(array);
            Weights.ToArray().ForEach((q, i, j) => _weightOptimizers[i, j].SetValue(q));
        }

        public void UpdateBiases()
        {
            Biases.MapIndexedInplace((i, q) => _biasOptimizers[i].Update());
        }

        public void UpdateWeights()
        {
            Weights.MapIndexedInplace((i, j, q) => _weightOptimizers[i, j].Update());
        }
    }
}
