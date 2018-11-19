﻿using Ann.Persistence;
using Ann.Persistence.LayerConfig;
using System;

namespace Ann.Layers
{
    public class InputLayer : Layer
    {
        public InputLayer(MessageShape inputMessageShape) 
            : base(inputMessageShape, inputMessageShape) {}

        internal InputLayer(InputLayerConfiguration config)
            : base(config.MessageShape, config.MessageShape) { }

        public override Array PassBackward(Array input)
        {
            return input;
        }

        public override Array PassForward(Array input)
        {
            return input;
        }

        public override void ValidateForwardInput(Array input) {}

        public override void ValidateBackwardInput(Array input) {}

        public override LayerConfiguration GetLayerConfiguration()
        {
            return new InputLayerConfiguration(InputMessageShape);
        }
    }
}