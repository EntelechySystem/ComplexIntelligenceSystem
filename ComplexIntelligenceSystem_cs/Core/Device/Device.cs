using System.Collections;
using EntelechySystem.ComplexIntelligenceSystem.Core.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

public class Device : BaseDevice
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