"""
定义单位众 Units 及其相关操作
"""

import numpy as np

# from numba import njit

N_UNITS = 1000  # 定义 Units 数量


# @njit
def define_units(n_units: int = N_UNITS):
    """
    定义一个单位之结构化数组的数据类型
    Args:
        n_units (int): 单位数量

    Returns:
        units (np.ndarray): 一个结构化数组
    """
    units_dtype = np.dtype([
        ('uid', np.uint64),  # 单位之 ID
        ('pos_x', np.float64),  # 单位之物理空间之 X 坐标
        ('pos_y', np.float64),  # 单位之物理空间之 Y 坐标
        # ('pos_z', np.float64),  # 单位之物理空间之 Z 坐标 #NOTE 如果需要启用再用
        ('input_units', 'O'),  # 单位之输入
        ('output_units', 'O'),  # 单位之输出
        ('units_type', 'S128'),  # 单位之类型
        ('contents_obj', 'O'),  # 单位之内容
        ('containers_obj', 'S128'),  # 单位之容器
        ('nodes_obj', 'S128'),  # 单位之节点
    ])

    units = np.zeros(n_units, dtype=units_dtype)  # 创建一个结构化数组
    units['uid'] = np.arange(n_units)  # 初始化 uid

    return units
    pass  # function


# @njit
def add_unit(units, uid: np.uint64):
    """
    添加一个单位
    Args:
        units (np.ndarray): 单位众
        uid (np.uint64): 单位之 ID
    """
    units_dtype = units.dtype
    new_unit = np.zeros(1, dtype=units_dtype)
    new_unit['uid'] = uid
    return np.concatenate((units, new_unit))
    pass  # function


# @njit
def delete_unit(units, uid: np.uint64):
    """
    删除一个单位

    Args:
        units (np.ndarray): 单位众
        uid (np.uint64): 单位之 ID

    Returns:

    """
    return np.delete(units, uid)
    pass  # function


# @njit
def find_unit(units, uid):
    """
    查找一个单位

    Args:
        units (np.ndarray): 单位众
        uid (np.uint64): 单位之 ID

    Returns:

    """
    return np.where(units['uid'] == uid)[0]
    pass  # function


# @njit
def move_uint(uid, pos_x, pos_y, pos_z, input_units, output_units, dx, dy, dz):
    """
    根据递增量更新一个单位之位置

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
# ## 定义单位众 Units 及其相关操作 #HACK torch 版本。未开发完。暂时不使用
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
