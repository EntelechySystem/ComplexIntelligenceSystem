"""
@File   : SceneBuilder.py
@Author : Yee Cube
@Date   : 2022/09/20
@Desc   : 大脑工厂构建工具，用于构建整个场景，暨工厂厂房。工厂厂房包括生产区、仓储区、进出口区、管理区等。
"""

from PyComplexIntelligenceSystem import np, dataclass
from PyComplexIntelligenceSystem.Core.Base import *
from PyComplexIntelligenceSystem.Core.Machine import *


@dataclass()
class SceneBuilder:
    """
    大脑工厂构建工具，用于构建整个场景，暨工厂厂房。
    """

    @staticmethod
    def buildMachinesArray():
        """构建机阵列"""
        Machines = np.full((5, 5), BaseMachine)
        # TODO阵列之间初始化随机位置，初始化随机连接
        return Machines

    @staticmethod
    def buildDevicesArray():
        """构建器阵列"""
        Devices = np.full((5, 5), BaseDevice)
        return Devices


if __name__ == '__main__':
    print(SceneBuilder.Machines)
    print(SceneBuilder.Devices)
