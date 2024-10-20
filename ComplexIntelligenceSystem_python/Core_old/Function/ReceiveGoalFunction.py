"""
@File   : ReceiveGoalFunction.py
@Author : Yee Cube
@Date   : 2022/08/13
@Desc   : 接收目标功能
"""

from PyComplexIntelligenceSystem.Core.Function import *
from PyComplexIntelligenceSystem.Core.Machine import ReceiveMachine
from PyComplexIntelligenceSystem.Core.Device import GoalDevice


@dataclass
class ReceiveGoalFunction(BaseFunction):
    """
    接受目标功能
    """
    # TODO 接受目标功能
    receiveMachine:ReceiveMachine
    goalDevice:GoalDevice
    pass  # class
