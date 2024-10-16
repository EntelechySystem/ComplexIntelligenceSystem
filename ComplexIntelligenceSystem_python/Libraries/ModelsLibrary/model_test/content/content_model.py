"""
模型
"""

# from ComplexIntelligenceSystem_python.Core.define_units import define_neurons_units, define_op_units
from ComplexIntelligenceSystem_python.Core.define_units import DefineUnits
from ComplexIntelligenceSystem_python.Core.tools import Tools
import logging


def content_model(para: dict, globals: dict):
    logging.info("模型内容")

    ## 设置项
    # 神经元数量 = globals['神经元数量']

    # ## 定义神经元件
    # neurons_units = define_neurons_units(globals['神经元件总数量'])
    #
    # ## 打印初始化的神经元件
    # print(neurons_units)
    # print(neurons_units.dtype)
    # print(neurons_units.shape)

    # ## 初始化运作单元
    # units = define_units(globals['运作单元总数量'])
    #
    # ## 打印初始化的运作单元
    # print(units)
    # # print(units.dtype)
    # # print(units.shape)

    ## 初始化运作单元
    op_units_Uid, op_units_UnitsType = DefineUnits.define_units(globals['运作单元总数量'])

    ## 打印初始化的运作单元
    print(op_units_Uid)
    print(Tools.decode_string_array(op_units_UnitsType))
    # print(op_units_InputUnits)

    # # 初始化运作单元
    # units = define_units(globals['运作单元总数量'])
    #
    # # 打印初始化的运作单元
    # for unit in units:
    #     print(f"UID: {unit.uid}, Input_Units: {unit.input_units}, "
    #           f"Output_Units: {unit.output_units}, Units_Type: {unit.units_type}, Contents_Obj: {unit.contents_obj}, "
    #           f"Containers_Obj: {unit.containers_obj}, Nodes_Obj: {unit.nodes_obj}")

# import numpy as np
# from numba import njit
#
# @njit
# def define_units_with_adjacency(n_units: int, max_neighbors: int):
#     op_units_Uid = np.arange(n_units)
#     adjacency_matrix = np.full((n_units, max_neighbors), -1, dtype=np.int32)  # -1 表示没有邻接
#
#     # 为节点 0 添加邻接节点 1 和 2
#     adjacency_matrix[0, 0] = 1
#     adjacency_matrix[0, 1] = 2
#
#     return op_units_Uid, adjacency_matrix
#
# uids, adj_matrix = define_units_with_adjacency(5, 3)
# print("邻接矩阵:\n", adj_matrix)
