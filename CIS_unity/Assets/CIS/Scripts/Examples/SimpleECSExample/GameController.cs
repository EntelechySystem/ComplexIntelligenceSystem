using UnityEngine;

// using UnityEngine.ComputerShader;

namespace EntelechySystem.CIS.Examples.simpleECS
{
    // namespace EntelechySystem.CIS;
    using Random = UnityEngine.Random;

    public class GameController : MonoBehaviour
    {

        /// 设置项
        public CIS_settings settings;


        // [Header("Display Settings")]

        private void Awake()
        {
            /// 随机生成【Agent】
            for (var i = 0; i < 1000; i++) // 遍历每一类yeeType，以生成个体
            {
                float radiusSize = 100f;
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;

                // for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成个体
                // {
                //     YeeAgent a = YeeAgent.Instantiate(yeeAgent);
                //
                //     Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                //
                //     a.aset.position = pos;
                //     a.aset.velocity = Random.insideUnitCircle;
                //     a.aset.id = i.ToString();
                //     a.aset.YeeType = yeeType.YeeTypes[t];
                //     a.aset.color = yeeType.Colors[t];
                //     // a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();
                //     a.agentRuleEffector.tag = a.Tag;
                //
                //     a.Initialize(a.aset);
                //
                //     // a.agentRuleEffector = GameObject.Find("AgentRuleEffector").gameObject;
                //     // a.yeeRule = YeeTypeChooser.ChooseYeeRule(a.agentRuleEffector, gameSettings.yeeFamilyEnum);
                // }
            }
        }

        // // Start is called before the first frame update
        // void Start()
        // {
        //     Init();
        // }
        //
        // private void Init()
        // {
        //     /// 创建纹理映射
        //     int width;
        //     int height;
        //     var texture = new RenderTexture(width, height, 0);
        //     texture.graphicsFormat = format;
        //     texture.enableRandomWrite = true;
        //
        //     texture.autoGenerateMips = false;
        //     texture.Create();
        // }

        // Update is called once per frame
        void Update()
        {
        }
    }
}

// /// <summary>
// /// 本脚本可以由输入的预制 生成以本物体为中心的随机预制,支持预制打组
// /// 随机物体生成器(尤其试用于场景中静态物体随机摆放)
// /// </summary>
// // using UnityEngine;
// // using System.Collections;
// // using System.Collections.Generic;
// public class PrefabMixer : MonoBehaviour
// {
//     [Tooltip("输入预制")] public GameObject[]
//         inputPrefabs;
//
//     [Tooltip("生成多少组")] public int
//         maxGroupsNum = 3;
//
//     [Tooltip("每组最多的个数")] public int
//         maxEachGroupsNum = 5;
//
//     [Tooltip("距离中心的距离")] public float
//         distanceToSpawn = 50f;
//
//     [Tooltip("缩放范围")] public float
//         scaleToSpawn = 5f;
//
//     //一共生成多少组
//     public List<Transform> asteroidsGroupList = new List<Transform>();
//
//     //生成的陨石总数
//     private List<Transform> asteroidsList = new List<Transform>();
//
//     private Transform _cacheTransform;
//
//     void OnEnable()
//     {
//         ResetList();
//         _cacheTransform = transform;
//         Debug.Log("Cache Transform !!");
//     }
//
//     void OnDisable()
//     {
//         ResetList();
//     }
//     
//
//     public void GenerateAsteroids()
//     {
//         if (inputPrefabs == null || inputPrefabs.Length <= 0)
//         {
//             Debug.LogError("预制不能为空哦 !");
//             return;
//         }
//
//         if (_cacheTransform == null)
//         {
//             _cacheTransform = transform;
//         }
//
//         int tempMap = 0;
//         ResetList();
//         //按组数来判断
//         while (asteroidsGroupList.Count < maxGroupsNum)
//         {
//             Transform o = new GameObject("AsteroidsMap_" + tempMap++).transform;
//             o.localPosition = _cacheTransform.position;
//             o.localRotation = Quaternion.identity;
//             o.localScale = Vector3.one;
//             if (o.GetComponent<RotateSelf>() == null)
//                 o.gameObject.AddComponent<RotateSelf>();
//             o.GetComponent<RotateSelf>().speed = Random.Range(1, 5f);
//
//
//             for (int i = 0; i < Random.Range(1, maxEachGroupsNum + 1); i++)
//             {
//                 if (GetRandomPrefab() == null)
//                     continue;
//                 GameObject asteroid = Instantiate(GetRandomPrefab()) as GameObject;
//                 asteroid.transform.parent = o.transform;
//                 asteroid.name = "asteroid_" + GetRandomPrefab().name + "_" + i;
//                 asteroid.transform.localRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
//                 asteroid.transform.localPosition = Random.insideUnitSphere * distanceToSpawn;
//                 asteroid.transform.localScale = new Vector3(Random.Range(1, scaleToSpawn), Random.Range(1, scaleToSpawn), Random.Range(1, scaleToSpawn));
//             }
//
//             asteroidsGroupList.Add(o);
//         }
//     }
//
//     public void ResetList()
//     {
//         for (int i = 0; i < asteroidsGroupList.Count && asteroidsGroupList.Count > 0; i++)
//         {
//             if (asteroidsGroupList[i] == null)
//                 continue;
//             //            #if UNITY_3_5
//             //            asteroidsGroupList[i].gameObject.active = false;        
//             //            #endif
//             //            asteroidsGroupList [i].gameObject.SetActive (false);
//             DestroyImmediate(asteroidsGroupList[i].gameObject);
//         }
//
//         if (asteroidsGroupList.Count > 0)
//             asteroidsGroupList.Clear();
//     }
//
//     GameObject GetRandomPrefab()
//     {
//         if (inputPrefabs != null && inputPrefabs.Length > 0)
//             return inputPrefabs[Random.Range(0, inputPrefabs.Length)];
//         return null;
//     }
// }
//
// /// <summary>
// /// Prefab mixer editor.
// /// </summary>
// // using UnityEditor;
// // using UnityEngine;
// // using System.Collections.Generic;
// [CustomEditor(typeof(PrefabMixer))]
// public class PrefabMixerEditor : Editor
// {
//     SerializedObject myTarget;
//
//     SerializedProperty maxEachGroupsNum;
//     SerializedProperty maxGroupsNum;
//     SerializedProperty distanceToSpawn;
//     SerializedProperty scaleToSpawn;
//
//     SerializedProperty GenerateAsteroids;
//     //    SerializedProperty asteroidsGroupList;
//
//
//     PrefabMixer prefabMixer;
//     private List<Transform> asteroidsGroupList = new List<Transform>();
//
//     void OnEnable()
//     {
//         myTarget = new SerializedObject(target);
//
//         maxGroupsNum = myTarget.FindProperty("maxGroupsNum");
//         maxEachGroupsNum = myTarget.FindProperty("maxEachGroupsNum");
//         distanceToSpawn = myTarget.FindProperty("distanceToSpawn");
//         scaleToSpawn = myTarget.FindProperty("scaleToSpawn");
//         //        asteroidsGroupList = myTarget.FindProperty("asteroidsGroupList");
//
//         //获得实例
//         prefabMixer = target as PrefabMixer;
//         asteroidsGroupList = prefabMixer.asteroidsGroupList;
//     }
//
//     private bool _showPrefabs = true;
//
//     public override void OnInspectorGUI()
//     {
//         myTarget.Update();
//
//         EditorGUILayout.Separator();
//
//         _showPrefabs = EditorGUILayout.Foldout(_showPrefabs, "单个预制");
//         EditorGUIUtility.LookLikeInspector();
//         if (_showPrefabs)
//         {
//             ArrayGUI(myTarget, "inputPrefabs");
//         }
//
//         EditorGUIUtility.LookLikeControls();
//
//         EditorGUILayout.Separator();
//
//         maxGroupsNum.intValue = EditorGUILayout.IntSlider("生成多少组", maxGroupsNum.intValue, 1, 1000);
//         EditorGUILayout.Separator();
//
//         maxEachGroupsNum.intValue = EditorGUILayout.IntSlider("每组最多的个数", maxEachGroupsNum.intValue, 1, 100);
//         EditorGUILayout.Separator();
//
//         distanceToSpawn.floatValue = EditorGUILayout.Slider("距离中心的距离", distanceToSpawn.floatValue, 1f, 100f);
//         EditorGUILayout.Separator();
//
//         scaleToSpawn.floatValue = EditorGUILayout.Slider("缩放范围", scaleToSpawn.floatValue, 1f, 10f);
//         EditorGUILayout.Separator();
//
//         if (GUILayout.Button("生成"))
//         {
//             prefabMixer.GenerateAsteroids();
//         }
//
//         EditorGUILayout.Separator();
//
//         if (GUILayout.Button("清空"))
//         {
//             prefabMixer.ResetList();
//         }
//
//         EditorGUILayout.Separator();
//
//         myTarget.ApplyModifiedProperties();
//     }
//
//
//     void ArrayGUI(SerializedObject obj, string name)
//     {
//         int size = obj.FindProperty(name + ".Array.size").intValue;
//         int newSize = EditorGUILayout.IntField("数量", size);
//         if (newSize != size) obj.FindProperty(name + ".Array.size").intValue = newSize;
//         EditorGUI.indentLevel = 3;
//         for (int i = 0; i < newSize; i++)
//         {
//             var prop = obj.FindProperty(string.Format("{0}.Array.data[{1}]", name, i));
//             EditorGUILayout.PropertyField(prop);
//         }
//
//         EditorGUI.indentLevel = 0;
//     }
// }