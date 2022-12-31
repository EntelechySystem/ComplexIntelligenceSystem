namespace EntelechySystem.ComplexIntelligenceSystem.Functions;

using System;
using System.ComponentModel;

[DataContract]
public class ReceiveGoalFunction : BaseFunction
{
    [DataMember] public ReceiveMachine ReceiveMachine { get; set; }
    [DataMember] public GoalDevice GoalDevice { get; set; }
}