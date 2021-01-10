using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Core {
    public interface IChoice {
        string Name { get; }
        string ID { get; }
        string Description { get; }
        string Thumbnail { get; }
    }
}