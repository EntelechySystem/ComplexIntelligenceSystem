"""
定义单元众 Units 及其相关操作
"""
from dataclasses import dataclass

import torch
import numpy as np
from numba import njit
from ComplexIntelligenceSystem_python.Core.tools import Tools


@dataclass
class NeuronsUnits():
    """
    定义神经单元之结构化数组的数据类型
    """

    uid: torch.Tensor  # 单元之 ID
    units_type: torch.Tensor  # 单元之类型
    pos_x: torch.Tensor  # 单元之物理空间之 X 坐标
    pos_y: torch.Tensor  # 单元之物理空间之 Y 坐标
    # pos_z: torch.Tensor  # 单元之物理空间之 Z 坐标 #NOTE 如果需要启用再用
    input_units: torch.Tensor  # 单元之输入
    output_units: torch.Tensor  # 单元之输出
    contents_obj: torch.Tensor  # 单元之内容
    containers_obj: torch.Tensor  # 单元之容器
    nodes_obj: torch.Tensor  # 单元之节点
    links: torch.Tensor  # 单元之连接

    def __init__(self, n_units: int, max_num_links: int):
        self.uid = torch.arange(n_units, dtype=torch.int64)
        self.units_name = torch.from_numpy(Tools.generate_unique_identifier())
        self.units_type = torch.from_numpy(np.array(Tools.encode_string_array('neurons')))
        self.pos_x = torch.zeros(n_units, dtype=torch.float64)
        self.pos_y = torch.zeros(n_units, dtype=torch.float64)
        # self.pos_z = torch.zeros(n_units, dtype=torch.float64)
        self.input_units = torch.empty((n_units), dtype=torch.float32)
        self.output_units = torch.empty((n_units), dtype=torch.float32)
        self.contents_obj = torch.empty((n_units), dtype=torch.string)
        self.containers_obj = torch.empty((n_units), dtype=torch.string)
        self.nodes_obj = torch.empty((n_units), dtype=torch.string)
        self.links = torch.empty((n_units, max_num_links), dtype=torch.int32)
        pass  # function

    pass  # class


@dataclass()
class OperationUnits():
    """
    定义运作单元（机器件）之结构化数组的数据（PyTorch 版本）
    """

    uid: torch.Tensor  # 运作单元之 ID
    units_name: torch.Tensor  # 运作单元之名称
    units_type: torch.Tensor  # 运作单元之类型
    input_units: torch.Tensor  # 运作单元之输入
    output_units: torch.Tensor  # 运作单元之输出
    links: torch.Tensor  # 运作单元之连接（N×M）

    def __init__(self, n_units: int, max_num_links: int, unit_type: str):
        self.uid = torch.arange(n_units, dtype=torch.int64)
        self.units_name = torch.from_numpy(np.array([Tools.generate_unique_identifier() for i in range(len(n_units))]))
        self.units_type = torch.from_numpy(np.array(Tools.encode_string_array(unit_type)))
        self.input_units = torch.empty((n_units), dtype=torch.float32)
        self.output_units = torch.empty((n_units), dtype=torch.float32)
        self.links = torch.ones((n_units, max_num_links), dtype=torch.int32) * -1
        pass  # function

    pass  # class


@dataclass()
class OperationUnits():
    """
    定义运作单元（机器件）之结构化数组的数据（Numpy 版本）
    """

    uid: np.ndarray  # 运作单元之 ID
    uid_name: np.ndarray  # 运作单元之名称
    units_type: np.ndarray  # 运作单元之类型
    input_units: np.ndarray  # 运作单元之输入
    output_units: np.ndarray  # 运作单元之输出
    links: np.ndarray  # 运作单元之连接（N×M）

    def __init__(self, n_units: int, max_num_links: int, unit_type: str):
        uid = np.arange(n_units)  # 单元之 ID
        uid_name = np.array([Tools.generate_unique_identifier() for i in range(len(n_units))])  # 单元之名称
        units_type = np.full(n_units, unit_type, np.dtype('S128'))  # 单元之类型
        input_units = np.full(n_units, ' ', np.dtype('S128'))  # 单元之输入
        output_units = np.full(n_units, ' ', np.dtype('S128'))  # 单元之输出
        links = -np.ones((n_units, max_num_links), np.dtype(np.int32))  # 单元之连接（N×M）
        pass  # function

    pass  # class


@dataclass()
class KeyData():
    """
    定义匹配钥匙对数据结构
    """


class DefineUnits():

    # units_dtype = np.dtype([
    #     ('uid', np.uint64),  # 单元之 ID
    #     ('units_type', 'S128'),  # 单元之类型
    #     ('input_units', 'S128'),  # 单元之输入
    #     ('output_units', 'S128'),  # 单元之输出
    #     ('contents_obj', 'S128'),  # 单元之内容
    #     ('containers_obj', 'S128'),  # 单元之容器
    #     ('nodes_obj', 'S128'),  # 单元之节点
    # ])

    @classmethod
    def define_operation_units(cls, n_units: int, mode: str = 'numpy'):
        """
        定义运作单元（机器件）之结构化数组的数据类型。
        模式：numpy 或 torch

        Args:
            n_units (int): 单元数量
            mode (str): 模式。默认值为 numpy

        Returns:

        """
        # units = np.zeros(n_units, dtype=op_units_dtype)  # 创建一个结构化数组
        # units['uid'] = np.arange(n_units)  # 初始化 uid

        op_units_Uid = torch.arange(n_units, dtype=torch.int64)
        op_units_UidString = torch.from_numpy(Tools.generate_unique_identifier())
        op_units_UnitsType = torch.from_numpy(np.array(Tools.encode_string_array('hello world')))
        # op_units_InputUnits = np.full(n_units, ' ', np.dtype('S128'))

        return op_units_Uid, op_units_UidString, op_units_UnitsType
        pass  # function

    pass  # class


# class Units:
#     def __init__(self, uid, pos_x, pos_y, input_units, output_units, units_type, contents_obj, containers_obj, nodes_obj):
#         self.uid = uid
#         self.pos_x = pos_x
#         self.pos_y = pos_y
#         self.input_units = input_units
#         self.output_units = output_units
#         self.units_type = units_type
#         self.contents_obj = contents_obj
#         self.containers_obj = containers_obj
#         self.nodes_obj = nodes_obj
#
# def define_units(n_units: int):
#
#     """
#     定义运作单元（机器件）之结构化数组的数据类型
#
#     Args:
#         n_units (int): 单元数量
#
#     Returns:
#         list: 包含 n_units 个 Unit 对象的列表
#     """
#     units = []
#     for i in range(n_units):
#         unit = Units(
#             uid=torch.tensor(i, dtype=torch.int64),
#             # pos_x=torch.tensor(0.0, dtype=torch.float64),
#             # pos_y=torch.tensor(0.0, dtype=torch.float64),
#             input_units=torch.empty(1, dtype=torch.float32),
#             output_units=torch.empty(1, dtype=torch.float32),
#             units_type=torch.tensor('', dtype=torch.string),
#             contents_obj=torch.tensor('', dtype=torch.string),
#             containers_obj=torch.tensor('', dtype=torch.string),
#             nodes_obj=torch.tensor('', dtype=torch.string)
#         )
#         units.append(unit)
#
#
#     return units
#     pass  # function


#
# ## 定义单元众 Units 及其相关操作 #HACK torch 版本。未开发完。暂时不使用
# @njit
# def define_units(n_units: int = N_UNITS):
#     # 定义输入单元
#     uid = torch.arange(n_units, dtype=torch.int64)
#     pos_x = torch.zeros(n_units, dtype=torch.float64)
#     pos_y = torch.zeros(n_units, dtype=torch.float64)
#     pos_z = torch.zeros(n_units, dtype=torch.float64)
#     input_units = torch.empty(n_units, dtype=torch.float32)
#     output_units = torch.empty(n_units, dtype=torch.float32)
#     units_type = np.empty(n_units, dtype=np.dtype('S128'))
#     contents_obj = np.empty(n_units, dtype=np.dtype('object'))
#     containers_obj = np.empty(n_units, dtype=np.dtype('S128'))
#     nodes_obj = np.empty(n_units, dtype=np.dtype('S128'))
#
#     # 打包上述变量然后返回元组
#     units = (pos_x, pos_y, pos_z, input_units, output_units, units_type, contents_obj, containers_obj, nodes_obj)
#
#     return units
#


# 本地测试
if __name__ == "__main__":
    # units = define_neurons_units()
    # print(units)
    # print(units.dtype)
    # print(units.shape)
    # print(units['uid'])
    # print(units['pos_x'])
    # print(units['pos_y'])
    # print(units['input_units'])
    # print(units['output_units'])
    # print(units['units_type'])
    # print(units['contents_obj'])
    # print(units['containers_obj'])
    # print(units['nodes_obj'])
    #
    # units = add_unit(units, uid=1000)
    # print(units)
    # print(units.dtype)
    # print(units.shape)
    # print(units['uid'])
    # print(units['pos_x'])
    # print(units['pos_y'])
    # print(units['input_units'])
    # print(units['output_units'])
    # print(units['units_type'])
    # print(units['contents_obj'])
    # print(units['containers_obj'])
    # print(units['nodes_obj'])
    #
    # units = delete_unit(units, uid=1000)
    # print(units)
    # print(units.dtype)
    # print(units.shape)
    # print(units['uid'])
    # print(units['pos_x'])
    # print(units['pos_y'])
    # print(units['input_units'])
    # print(units['output_units'])
    # print(units['units_type'])
    # print(units['contents_obj'])
    # print(units['containers_obj'])
    # print(units['nodes_obj'])
    #
    # print(query_unit(units, uid=1000))
    # print(query_unit(units, uid=1001))
    # print(query_unit(units, uid=1002))

    pass
