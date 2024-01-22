namespace EntelechySystem.ComplexIntelligenceSystem;

/// <summary>
/// 逻辑门抽象类 #TODO 需要适配
/// </summary>
public abstract class LogicGateDevice
{
    public abstract bool ComputeOutput();
    public abstract void ComputeInput(bool input1, bool input2);
}

/// <summary>
/// 与逻辑门
/// </summary>
public class AndGateDevice : LogicGateDevice
{
    private bool _input1;
    private bool _input2;

    public override bool ComputeOutput()
    {
        return _input1 && _input2;
    }

    public override void ComputeInput(bool input1, bool input2)
    {
        _input1 = input1;
        _input2 = input2;
    }
}
