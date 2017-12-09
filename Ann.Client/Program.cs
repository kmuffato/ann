﻿using Ann.Configuration;
using System;

namespace Ann.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var layerConfig = new LayerConfiguration();

            layerConfig
                .AddInputLayer(10)
                .AddHiddenLayer(10, ActivatorType.LogisticActivator)
                .AddHiddenLayer(20, ActivatorType.LogisticActivator)
                .AddHiddenLayer(20, ActivatorType.LogisticActivator)
                .AddOutputLayer(5, ActivatorType.LogisticActivator);

            var config = new NetworkConfiguration(layerConfig, 0.1, 0.95);

            var network = new Network(config);
        }
    }
}
