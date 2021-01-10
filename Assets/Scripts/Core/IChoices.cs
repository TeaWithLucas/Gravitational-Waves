using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core {
    public interface IChoices {
        string Name { get; }
        string ID { get; }
        string Description { get; }
    }
}