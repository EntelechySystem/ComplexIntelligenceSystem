using System.Collections;
using CIS.Core.Base;

namespace CIS.Core.Container;

public class Entity : BaseObject
{
    private ArrayList connections = new ArrayList();

    public Entity()
    {
        connections.Add(this);
    }

    void fun()
    {
    }
}