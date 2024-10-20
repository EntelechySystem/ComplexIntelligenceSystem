"""
@File   : NeedMachine.py
@Author : Yee Cube
@Date   : 2022/06/19
@Desc   : 
"""

from PyComplexIntelligenceSystem.Core.Machine import *
# from PyComplexIntelligenceSystem.Core_old.Unit.Units import *
# from PyComplexIntelligenceSystem.Core_old.Content.Content import Content


@dataclass
class NeedMachine(BaseMachine):
    """
    需求机
    """

    # NOW
    receiverUnit: ReceiverUnit = ReceiverUnit
    senderUnit: SenderUnit = SenderUnit;


    content: Content = Content(type_name='content type')

    def receive_want_to_need_sign(self):
        """

        Returns:

        """
        self.content, self.receiverUnit.feedback_sign = self.receiverUnit.receive_content(content=self.content)
        pass

    # 发送需求
    def send_need(self):
        """

        Returns:

        """
        self.content, self.senderUnit.send_content()
        pass

    pass  # class
