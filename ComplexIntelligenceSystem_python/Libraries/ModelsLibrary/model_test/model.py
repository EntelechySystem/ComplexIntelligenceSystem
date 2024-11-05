"""
模型
"""

# from ComplexIntelligenceSystem_python.Core.define_units import define_neurons_units, define_op_units
from ComplexIntelligenceSystem_python.Core.define_units import NeuronsUnits, NeuronsUnits_ForHumanRead, OperationUnits
from ComplexIntelligenceSystem_python.Core.tools import Tools
from ComplexIntelligenceSystem_python.Core.settings import Settings
import logging


class Model:
    ne_units = None
    op_units_Control = None
    op_units_Container = None
    op_units_Goal = None
    op_units_Task = None
    op_units_Conception = None
    model_function = None

    def __init__(self, gb: dict):
        if gb['is_init_model']:
            self.init_model(gb)
        else:
            self.model_content(gb)
            pass  # if
        model_function = ModelFunctions()
        pass  # function

    def model_content(self, gb: dict):
        pass  # function

    pass  # class

    def init_model(self, gb):

        ## 初始化单元众

        ### 定义神经元
        n_ne_units = gb['神经元总数量']
        n_op_units_Control = int(gb['运作单元总数量'] / 8)
        n_op_units_Container = int(gb['运作单元总数量'] / 8)
        n_op_units_Goal = int(gb['运作单元总数量'] / 8)
        n_op_units_Task = int(gb['运作单元总数量'] / 8)
        n_op_units_Conception = int(gb['运作单元总数量'] / 8)

        ## 初始化单元众

        ### 定义神经元
        ne_units = NeuronsUnits(n_ne_units, gb['单个神经元最大连接数'])

        ### 定义用于人类阅读的神经元数据
        ne_units_hr = NeuronsUnits_ForHumanRead(n_ne_units, gb['单个神经元最大连接数'])

        # 打印初始化的神经元
        logging.info("初始化的神经元")
        Tools.print_units_values(ne_units)
        Tools.print_units_values(ne_units_hr)

        ### 初始化控制运作单元
        op_units_Control = OperationUnits(
            n_op_units_Control,
            gb['单个运作单元最大连接数'],
            Settings.dict_written_type_of_Units['control']
        )
        logging.info("初始化的控制运作单元")
        Tools.print_units_values(op_units_Control)

        ### 初始化容器运作单元
        op_units_Container = OperationUnits(
            n_op_units_Container,
            gb['单个运作单元最大连接数'],
            Settings.dict_written_type_of_Units['container']
        )

        ### 初始化目标运作单元
        op_units_Goal = OperationUnits(
            n_op_units_Goal,
            gb['单个运作单元最大连接数'],
            Settings.dict_written_type_of_Units['goal']
        )
        logging.info("初始化的容器运作单元")
        Tools.print_units_values(op_units_Container)

        ### 初始化任务运作单元
        op_units_Task = OperationUnits(
            n_op_units_Task,
            gb['单个运作单元最大连接数'],
            Settings.dict_written_type_of_Units['task']
        )

        ### 初始化概念运作单元
        op_units_Conception = OperationUnits(
            n_op_units_Conception,
            gb['单个运作单元最大连接数'],
            Settings.dict_written_type_of_Units['conception']
        )

        pass  # function

    def model_content(self, gb: dict):
        # 感知模块
        # 设置基本的感知单元
        # 视觉感知单元

        pass

    pass  # class
