"""
模型
"""

# from ComplexIntelligenceSystem_python.Core.define_units import define_neurons_units, define_op_units
from ComplexIntelligenceSystem_python.Core.define_units import NeuronsUnits, NeuronsUnits_ForHumanRead, OperationUnits
from ComplexIntelligenceSystem_python.Core.tools import Tools
from ComplexIntelligenceSystem_python.Core.settings import Settings
import logging


def content_model(para: dict, globals: dict):
    n_ne_units = globals['神经元总数量']
    n_op_units_Control = int(globals['运作单元总数量'] / 8)
    n_op_units_Container = int(globals['运作单元总数量'] / 8)
    n_op_units_Goal = int(globals['运作单元总数量'] / 8)
    n_op_units_Task = int(globals['运作单元总数量'] / 8)
    n_op_units_Conception = int(globals['运作单元总数量'] / 8)

    ## 定义神经单元
    ne_units = NeuronsUnits(n_ne_units, globals['单个神经元最大连接数'])

    ## 定义用于人类阅读的神经元数据
    ne_units_hr = NeuronsUnits_ForHumanRead(n_ne_units, globals['单个神经元最大连接数'])

    ## 打印初始化的神经元件
    logging.info("初始化的神经元")
    Tools.print_units_values(ne_units)
    Tools.print_units_values(ne_units_hr)

    ## 初始化运作单元

    ### 初始化控制运作单元
    op_units_Control = OperationUnits(n_op_units_Control, globals['单个运作单元最大连接数'], Settings.dict_written_type_of_Units['control'])

    ### 初始化容器运作单元
    op_units_Container = OperationUnits(n_op_units_Container, globals['单个运作单元最大连接数'], Settings.dict_written_type_of_Units['container'])

    ### 初始化目标运作单元
    op_units_Goal = OperationUnits(n_op_units_Goal, globals['单个运作单元最大连接数'], Settings.dict_written_type_of_Units['goal'])

    ### 初始化任务运作单元
    op_units_Task = OperationUnits(n_op_units_Task, globals['单个运作单元最大连接数'], Settings.dict_written_type_of_Units['task'])

    ### 初始化概念运作单元
    op_units_Conception = OperationUnits(n_op_units_Conception, globals['单个运作单元最大连接数'], Settings.dict_written_type_of_Units['conception'])

    ## 打印初始化的运作单元
    logging.info("初始化的控制运作单元")
    Tools.print_units_values(op_units_Control)
    logging.info("初始化的容器运作单元")
    Tools.print_units_values(op_units_Container)
