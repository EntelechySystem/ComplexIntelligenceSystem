using EntelechySystem.ComplexIntelligenceSystem;

namespace CIS_scripts;


using System;
using System.ComponentModel;

public class SceneBuilder
{
    public static Content[,] BuildContentArray()
    {
        Content[,] contentArray = new Content[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                contentArray[i, j] = new Content();
            }
        }
        // TODO Initialize random positions and connections between arrays
        return contentArray;
    }

    // public static BaseDevice[,] BuildDevicesArray()
    // {
    //     BaseDevice[,] Devices = new BaseDevice[5, 5];
    //     for (int i = 0; i < 5; i++)
    //     {
    //         for (int j = 0; j < 5; j++)
    //         {
    //             Devices[i, j] = new BaseDevice();
    //         }
    //     }
    //     return Devices;
    // }


}
