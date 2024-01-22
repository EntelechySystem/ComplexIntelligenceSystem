
namespace EntelechySystem.CIS.Core.Components
{
// using UnityEngine;
    using Unity.Entities;
    using Unity.Collections;
    using Unity.Mathematics;

    public partial struct AttributeComponent : IComponentData
    {
        public int Id;
        public string EntityName;
        public string TextName;
        public string ContentType;
        public string ContentName;
        public int OtherCount;
        public BlobArray<OtherBufferElement> OtherBuffer;
    }

    public partial struct OtherBufferElement
    {
        public string Key;
        public object Value;
    }

    public partial struct ContentComponent : IComponentData
    {
        public object Content;
    }

    public class ContentComponentAuthoring : MonoBehaviour
    {
        public class ContentComponentBaker : Baker<ContentComponentAuthoring>
        {
            public override void Bake(ContentComponentAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new ContentComponent());
            }
        }
    }

    public partial struct ContainerComponent : IComponentData
    {
        public object Container;
    }

    public partial struct ProcessComponent : IComponentData
    {
        public object Process;
    }

    public partial struct ExecuteComponent : IComponentData
    {
        public object Execute;
    }

    public partial struct NodeComponent : IComponentData
    {
        public object Node;
    }

    public struct SceneInfoComponent : IComponentData
    {
        public float3 PlayerPosition;
        public float3 EnemyPosition;
        public float3 GoalPosition;
    }

    public struct TaskComponent : IComponentData
    {
        public int Priority;
        public int State;
    }

    public struct TaskExecutionComponent : IComponentData
    {
    }
}