"""
@File   : ReceiveGoalFunction.py
@Author : Ethan Lin
@Date   : 2022/08/13
@Desc   : 接收目标功能
"""

from PyEntelechySystem.Core.Function import *
from PyEntelechySystem.Core.Machine import ReceiveMachine
from PyEntelechySystem.Core.Device import GoalDevice


@dataclass
class ReceiveGoalFunction(BaseFunction):
    """
    接受目标功能
    """
    # TODO 接受目标功能
    receiveMachine:ReceiveMachine
    goalDevice:GoalDevice
    pass  # class
