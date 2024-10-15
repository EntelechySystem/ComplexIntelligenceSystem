"""
定义件众 Units 及其相关操作
"""

import torch
import numpy as np
from numba import njit

# @njit
# def define_neurons_units(n_units: int = N_UNITS):
#     """
#     定义神经件之结构化数组的数据类型
#
#     Args:
#         n_units (int): 件数量
#
#     Returns:
#         units (np.ndarray): 一个结构化数组
#     """
#     neurons_units_dtype = np.dtype([
#         ('uid', np.uint64),  # 件之 ID
#         ('units_type', 'S128'),  # 件之类型
#         ('pos_x', np.float64),  # 件之物理空间之 X 坐标
#         ('pos_y', np.float64),  # 件之物理空间之 Y 坐标
#         # ('pos_z', np.float64),  # 件之物理空间之 Z 坐标 #NOTE 如果需要启用再用
#         ('input_units', 'O'),  # 件之输入
#         ('output_units', 'O'),  # 件之输出
#         ('contents_obj', 'O'),  # 件之内容
#         ('containers_obj', 'S128'),  # 件之容器
#         ('nodes_obj', 'S128'),  # 件之节点
#     ])
#
#     units = np.zeros(n_units, dtype=neurons_units_dtype)  # 创建一个结构化数组
#     units['uid'] = np.arange(n_units)  # 初始化 uid
#
#     return units
#     pass  # function

units_dtype = np.dtype([
    ('uid', np.uint64),  # 件之 ID
    ('units_type', 'S128'),  # 件之类型
    ('input_units', 'S128'),  # 件之输入
    ('output_units', 'S128'),  # 件之输出
    ('contents_obj', 'S128'),  # 件之内容
    ('containers_obj', 'S128'),  # 件之容器
    ('nodes_obj', 'S128'),  # 件之节点
])


# # @njit
# def define_units(n_units: int):
#     """
#     定义运作单元（机器件）之结构化数组的数据类型
#
#     Args:
#         n_units (int): 件数量
#
#     Returns:
#         units (np.ndarray): 一个结构化数组
#     """
#     units_dtype = np.dtype([
#         ('uid', np.uint64),  # 件之 ID
#         ('pos_x', np.float64),  # 件之物理空间之 X 坐标
#         ('pos_y', np.float64),  # 件之物理空间之 Y 坐标
#         # ('pos_z', np.float64),  # 件之物理空间之 Z 坐标 #NOTE 如果需要启用再用
#         ('input_units', 'O'),  # 件之输入
#         ('output_units', 'O'),  # 件之输出
#         ('units_type', 'S128'),  # 件之类型
#         ('contents_obj', 'O'),  # 件之内容
#         ('containers_obj', 'S128'),  # 件之容器
#         ('nodes_obj', 'S128'),  # 件之节点
#     ])
#
#     units = np.zeros(n_units, dtype=units_dtype)  # 创建一个结构化数组
#     units['uid'] = np.arange(n_units)  # 初始化 uid
#
#     return units
#     pass  # function


# @njit(forceobj=True)
# def define_units(n_units: int):
#     """
#     定义运作单元（机器件）之结构化数组的数据类型
#
#     Args:
#         n_units (int): 件数量
#
#     Returns:
#
#     """
#     # units = np.zeros(n_units, dtype=op_units_dtype)  # 创建一个结构化数组
#     # units['uid'] = np.arange(n_units)  # 初始化 uid
#
#     op_units_Uid = np.arange(n_units)
#     op_units_UnitsType = np.full(n_units, ' ', np.dtype('S128'))
#     op_units_InputUnits = np.full(n_units, ' ', np.dtype('S128'))
#
#     return op_units_Uid, op_units_UnitsType, op_units_InputUnits
#     pass  # function
#

class Units:
    def __init__(self, uid, pos_x, pos_y, input_units, output_units, units_type, contents_obj, containers_obj, nodes_obj):
        self.uid = uid
        self.pos_x = pos_x
        self.pos_y = pos_y
        self.input_units = input_units
        self.output_units = output_units
        self.units_type = units_type
        self.contents_obj = contents_obj
        self.containers_obj = containers_obj
        self.nodes_obj = nodes_obj

def define_units(n_units: int):

    """
    定义运作单元（机器件）之结构化数组的数据类型

    Args:
        n_units (int): 件数量

    Returns:
        list: 包含 n_units 个 Unit 对象的列表
    """
    units = []
    for i in range(n_units):
        unit = Units(
            uid=torch.tensor(i, dtype=torch.int64),
            # pos_x=torch.tensor(0.0, dtype=torch.float64),
            # pos_y=torch.tensor(0.0, dtype=torch.float64),
            input_units=torch.empty(1, dtype=torch.float32),
            output_units=torch.empty(1, dtype=torch.float32),
            units_type=torch.tensor('', dtype=torch.string),
            contents_obj=torch.tensor('', dtype=torch.string),
            containers_obj=torch.tensor('', dtype=torch.string),
            nodes_obj=torch.tensor('', dtype=torch.string)
        )
        units.append(unit)
    return units
    pass  # function

# @njit
def add_unit(units, uid: np.uint64):
    """
    添加一个件
    Args:
        units (np.ndarray): 件众
        uid (np.uint64): 件之 ID
    """
    units_dtype = units.dtype
    new_unit = np.zeros(1, dtype=units_dtype)
    new_unit['uid'] = uid
    return np.concatenate((units, new_unit))
    pass  # function


# @njit
def delete_unit(units, uid: np.uint64):
    """
    删除一个件

    Args:
        units (np.ndarray): 件众
        uid (np.uint64): 件之 ID

    Returns:

    """
    return np.delete(units, uid)
    pass  # function


# @njit
def query_unit(units, uid):
    """
    查找一个件

    Args:
        units (np.ndarray): 件众
        uid (np.uint64): 件之 ID

    Returns:

    """
    return np.where(units['uid'] == uid)[0]
    pass  # function


# @njit
def move_uint(uid, pos_x, pos_y, pos_z, input_units, output_units, dx, dy, dz):
    """
    根据递增量更新一个件之位置

    Args:
        uid ():
        pos_x ():
        pos_y ():
        pos_z ():
        input_units ():
        output_units ():
        dx ():
        dy ():
        dz ():

    Returns:

    """
    pos_x += dx
    pos_y += dy
    pos_z += dz


#
# ## 定义件众 Units 及其相关操作 #HACK torch 版本。未开发完。暂时不使用
# @njit
# def define_units(n_units: int = N_UNITS):
#     # 定义输入件
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
