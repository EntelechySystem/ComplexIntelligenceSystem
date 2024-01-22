using UnityEngine;

namespace EntelechySystem.CIS
{

    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class CIS_settings : ScriptableObject
    {
        [Header("CIS Simulation Settings")] [Min(1)]
        public int stepsPerFrame = 1;

        public int width = 1000;
        public int height = 1000;

        public int numAgents = 100;
        // public Simulation.SpawnMode spawnMode;
        //
        // [Header("Trail Settings")] public float trailWeight = 1;
        //
        // /// 拖尾宽度
        // public float decayRate = 1;
        //
        // /// 延迟率（秒）
        // public float diffuseRate = 1;
        //
        // /// 散射率
        //
        // public SpeciesSettings[] speciesSettings;
        //
        // /// 设置几种不同的种群
        //
        // [System.Serializable]
        // public struct SpeciesSettings
        // {
        //     [Header("Movement Settings")] public float moveSpeed;
        //
        //     /// 移动速度
        //     public float turnSpeed;
        //
        //     /// 转向速度
        //
        //     [Header("Sensor Settings")] public float sensorAngleSpacing;
        //
        //     /// 感知角度间距
        //     public float sensorOffsetDst;
        //
        //     /// 感知偏移距离
        //     [Min(1)] public int sensorSize;
        //
        //     /// 感知大小
        //
        //     [Header("Display settings")] public Color colour;
        // }
    }
}