using EntelechySystem.CIS.ShaderExample;

namespace EntelechySystem.CIS.Core.simpleECS
{
    using EntelechySystem.CIS.Examples.simpleECS;
    using System.Collections.Generic;
    using UnityEngine;

    public class AgentsSystem
    {
    }


    public class SystemBase
    {
        public GameController gameController;
    }


    public class Entity
    {
        public int id;
        public string name;
        public string type;
        public ColorComponent color;
        public PositionComponent position;
        public SizeComponent size;
        public NodeComponent node;
        public ProcessComponent process;
        public ContentComponent content;
        public ContainerComponent container;
        public ExecuteComponent execute;
        public MoveableComponent isMoveable;
        public Dictionary<string, object> other;
    }

    public class BaseComponent
    {
        public Entity entity;
    }

    public class IdComponent : BaseComponent
    {
        public int id;
    }

    public class NameComponent : BaseComponent
    {
        public string name;
    }

    public class TypeComponent : BaseComponent
    {
        public string type;
    }

    public class ColorComponent : BaseComponent
    {
        public Color color;
    }

    public class PositionComponent : BaseComponent
    {
        public Vector2 position;
    }


    public class SizeComponent : BaseComponent
    {
        public Vector2 size;
    }


    public class NodeComponent : BaseComponent
    {
        public object node;
    }

    public class ProcessComponent : BaseComponent
    {
        public object process;
    }

    public class ContentComponent : BaseComponent
    {
        public object content;
    }

    public class ContainerComponent : BaseComponent
    {
        public object container;
    }

    public class ExecuteComponent : BaseComponent
    {
        public object execute;
    }

    public class MoveableComponent : BaseComponent
    {
        public bool isMoveable;
    }
}