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

    uid: torch.Tensor  # 单元之 ID（N）
    units_name: torch.Tensor  # 单元之名称（N×K）
    units_type: torch.Tensor  # 单元之类型（N）
    pos_x: torch.Tensor  # 单元之物理空间之 X 坐标
    pos_y: torch.Tensor  # 单元之物理空间之 Y 坐标
    # pos_z: torch.Tensor  # 单元之物理空间之 Z 坐标 #NOTE 如果需要启用再用
    input_units: torch.Tensor  # 单元之输入
    output_units: torch.Tensor  # 单元之输出
    # contents_obj: torch.Tensor  # 单元之内容
    # containers_obj: torch.Tensor  # 单元之容器
    # nodes_obj: torch.Tensor  # 单元之节点
    links: torch.Tensor  # 单元之连接

    def __init__(self, n_units: int, max_num_links: int):
        self.uid = torch.arange(n_units, dtype=torch.int64)
        self.units_name = torch.from_numpy(np.array([Tools.encode_string_array(Tools.generate_unique_identifier()) for i in range(n_units)]))
        self.units_type = torch.from_numpy(np.array(Tools.encode_string_array('neurons')))
        self.pos_x = torch.zeros(n_units, dtype=torch.float64)
        self.pos_y = torch.zeros(n_units, dtype=torch.float64)
        # self.pos_z = torch.zeros(n_units, dtype=torch.float64)
        self.input_units = torch.empty((n_units), dtype=torch.float32)
        self.output_units = torch.empty((n_units), dtype=torch.float32)
        # self.contents_obj = torch.empty((n_units), dtype=torch.string)
        # self.containers_obj = torch.empty((n_units), dtype=torch.string)
        # self.nodes_obj = torch.empty((n_units), dtype=torch.string)
        self.links = torch.empty((n_units, max_num_links), dtype=torch.int32)
        pass  # function

    pass  # class


# @dataclass()
# class OperationUnits(): # HACK 暂时不使用
#     """
#     定义运作单元（机器件）之结构化数组的数据（PyTorch 版本）
#     """
#
#     uid: torch.Tensor  # 运作单元之 ID
#     units_name: torch.Tensor  # 运作单元之名称
#     units_type: torch.Tensor  # 运作单元之类型
#     input_units: torch.Tensor  # 运作单元之输入
#     output_units: torch.Tensor  # 运作单元之输出
#     links: torch.Tensor  # 运作单元之连接（N×M）
#
#     def __init__(self, n_units: torch.int64, max_num_links: torch.int32, unit_type: torch.uint8):
#         self.uid = torch.arange(n_units, dtype=torch.int64)
#         self.units_name = torch.from_numpy(np.array([Tools.generate_unique_identifier() for i in range(n_units)]))
#         self.units_type = torch.from_numpy(np.array(Tools.encode_string_array(unit_type)))
#         self.input_units = torch.empty((n_units), dtype=torch.float32)
#         self.output_units = torch.empty((n_units), dtype=torch.float32)
#         self.links = torch.ones((n_units, max_num_links), dtype=torch.int32) * -1
#         pass  # function
#
#     pass  # class


@dataclass()
class OperationUnits():
    """
    定义运作单元（机器件）之结构化数组的数据（Numpy 版本）
    """

    def __init__(self, n_units: np.uint32, max_num_links: np.uint32, unit_type: np.uint8):
        self.uid = np.arange(n_units)  # 单元之 ID
        self.uid_name = np.array([Tools.generate_unique_identifier() for i in range(n_units)])  # 运作单元之名称
        self.units_type = np.full(n_units, unit_type)  # 运作单元之类型
        self.input_units = np.full(n_units, ' ', np.dtype('S128'))  # 运作单元之输入
        self.output_units = np.full(n_units, ' ', np.dtype('S128'))  # 运作单元之输出
        self.links = -np.ones((n_units, max_num_links), np.dtype(np.int32))  # 运作单元之连接（N×M）
        pass  # function

    pass  # class


@dataclass()
class KeyData():
    """
    定义匹配钥匙对数据结构
    """
    pass  # class


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
