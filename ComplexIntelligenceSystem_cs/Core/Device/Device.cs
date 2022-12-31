using System.Collections;
using EntelechySystem.ComplexIntelligenceSystem.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

class Device : BaseDevice
{
    /// <summary>
    /// 器
    /// </summary>
    private ArrayList connections = new ArrayList();

    public Device()
    {
        connections.Add(this);
    }
    
}