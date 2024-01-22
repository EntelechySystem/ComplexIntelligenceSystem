namespace EntelechySystem.CIS.Core.Entity
{
    using UnityEngine;
    using System.Collections.Generic;
    using Unity.Entities;

    public partial struct AttributeComponent : IComponentData
    {
        public int Id;
        public string EntityName;
        public string TextName;
        public string ContentType;
        public string ContentName;

        public int OtherCount;

        // 将Other属性转换为动态缓冲区
        public DynamicBuffer<OtherBufferElement> OtherBuffer;
    }

    public partial struct OtherBufferElement
    {
        public string Key;
        public object Value;
    }

    public partial struct ContentComponent : IComponentData
    {
        public object content;
    }

    public partial struct ContainerComponent : IComponentData
    {
        public object container;
    }

    public partial struct ProcessComponent : IComponentData
    {
        public object process;
    }

    public partial struct ExecuteComponent : IComponentData
    {
        public object execute;
    }

    public partial struct NodeComponent : IComponentData
    {
        public object node;
    }

    public struct EntityData : IComponentData
    {
        // 将所有的组件添加到实体数据中
        public AttributeComponent Attribute;
        public ContentComponent Content;
        public ContainerComponent Container;
        public ProcessComponent Process;
        public ExecuteComponent Execute;
        public NodeComponent Node;
    }

    public class EntityAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public dynamic entityData;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            // 添加实体数据组件
            dstManager.AddComponentData(entity, new EntityData
            {
                Attribute = new AttributeComponent
                {
                    Id = entityData.attribute.id,
                    EntityName = entityData.attribute.entity_name,
                    TextName = entityData.attribute.text_name,
                    ContentType = entityData.attribute.content_type,
                    ContentName = null,
                    OtherCount = (entityData.attribute as IDictionary<string, object>).Count - 5,
                    OtherBuffer = new DynamicBuffer<OtherBufferElement>((entityData.attribute as IDictionary<string, object>).Count - 5)
                },
                Content = new ContentComponent
                {
                    content = entityData.content
                },
                Container = new ContainerComponent
                {
                    container = entityData.container
                },
                Process = new ProcessComponent
                {
                    process = entityData.process
                },
                Execute = new ExecuteComponent
                {
                    execute = entityData.execute
                },
                Node = new NodeComponent
                {
                    node = entityData.node
                }
            });

            // 将Other属性添加到动态缓冲区中
            var otherBuffer = dstManager.GetBuffer<OtherBufferElement>(entity, dstManager.GetComponentData<AttributeComponent>(entity).OtherBuffer);
            foreach (KeyValuePair<string, object> kvp in entityData.attribute)
            {
                if (kvp.Key != "id" && kvp.Key != "entity_name" && kvp.Key != "text_name" && kvp.Key != "node_type" && kvp.Key != "content_type")
                {
                    otherBuffer.Add(new OtherBufferElement
                    {
                        Key = kvp.Key,
                        Value = kvp.Value
                    });
                }
            }
        }
    }

    public interface IConvertGameObjectToEntity
    {
    }
}