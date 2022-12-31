namespace EntelechySystem.ComplexIntelligenceSystem;

using System;
using System.Collections.Generic;
using System.ComponentModel;

[DataContract]
public class Neure : BaseObject
{
    [DataMember] public string TypeName { get; set; } = "neure type";

    [DataMember] public Neure Axon { get; set; } = null;

    [DataMember] public List<Neure> Dendrite { get; set; } = new List<Neure>();

    [DataMember] public List<int> Synapse { get; set; } = new List<int>();

    [DataMember] public Tuple<float, float, float> IndexPos { get; set; } = (0.0f, 0.0f, 0.0f);

    public void InitPosition(Tuple<float, float, float> spaceRange)
    {
        // TODO: 初始化位置
    }

    public void SetNeureId()
    {
        // TODO: 设置神经元ID
    }

    public void SetNeureType()
    {
        // TODO: 设置神经元类型
    }

    public void SetAxonId()
    {
        // TODO: 设置轴突ID
    }

    public void SetDendrite()
    {
        // TODO: 设置树突
    }