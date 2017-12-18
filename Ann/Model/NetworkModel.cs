﻿using System.Collections.Generic;
namespace Ann.Model
{
    public class NetworkModel
    {
        public NetworkModel()
        {
            Layers = new List<LayerModel>();
        }

        public List<LayerModel> Layers { get; set; }
    }
}