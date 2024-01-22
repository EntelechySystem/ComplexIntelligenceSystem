using System;
using EntelechySystem.ComplexIntelligenceSystem.Core;

namespace CIS_scripts
{
    class Program
    {
        static void Main(string[] args)
        {
            /// 准备阶段：
            Console.WriteLine(SceneBuilder.BuildContentArray());

            /// 开始程序阶段：

            // 设置：总步数
            int totalStep = 1000;
            // 设置阶段步数
            int deltaStep = 100;
            int startStep = 0;
            int finishStep = startStep + totalStep;

            // 定时开始
            DateTime startTime = DateTime.Now;

            // TODO 初始化模型 ==========
            // read_unit = ReadUnit();
            // content = Content();

            // Console.WriteLine("type_name: " + read_unit.type_name);
            // Console.WriteLine("id: " + read_unit.uid);
            // Console.WriteLine("id_string: " + read_unit.uid_string);
            // Console.WriteLine("content type_name: " + read_unit.content.type_name);
            // Console.WriteLine("content head " + read_unit.content.head);
            // Console.WriteLine("content body " + read_unit.content.body);
            // Console.WriteLine("feedback_sign: " + read_unit.feedback_sign);
            // =========================

            // 运行程序，一直到设定的停时为止
            for (int currentStep = 0; currentStep < finishStep; currentStep++)
            {
                if (currentStep % deltaStep == 0)
                {
                    Console.WriteLine("步：" + currentStep);
                }

                // TODO 运行系统模型 ==========

                // =========================
            }

            // 定时结束
            DateTime finishTime = DateTime.Now;

            TimeSpan elapsed = finishTime - startTime;
            Console.WriteLine("耗时：" + elapsed.TotalSeconds + " seconds");
        }
    }
}