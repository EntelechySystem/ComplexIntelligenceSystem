"""
模型
"""

from ComplexIntelligenceSystem_python.Core.define_units import define_neurons_units, define_units
import logging


def content_model(para: dict, globals: dict):
    logging.info("模型内容")

    ## 设置项
    # 神经元数量 = globals['神经元数量']

    ## 定义神经元件
    neurons_units = define_neurons_units(globals['神经元件总数量'])

    ## 打印初始化的神经元件
    print(neurons_units)
    print(neurons_units.dtype)
    print(neurons_units.shape)

    ## 初始化运作单元
    units = define_units(globals['运作单元总数量'])



    ## 打印初始化的运作单元
    print(units)
    print(units.dtype)
    print(units.shape)

    # neurons_units = add_unit(neurons_units, uid=1000)
    # print(neurons_units)
    # print(neurons_units.dtype)
    # print(neurons_units.shape)
    # print(neurons_units['uid'])
    # print(neurons_units['pos_x'])
    # print(neurons_units['pos_y'])
    # print(neurons_units['input_units'])
    # print(neurons_units['output_units'])
    # print(neurons_units['units_type'])
    # print(neurons_units['contents_obj'])
    # print(neurons_units['containers_obj'])
    # print(neurons_units['nodes_obj'])
    #
    # neurons_units = delete_unit(neurons_units, uid=1000)
    # print(neurons_units)
    # print(neurons_units.dtype)
    # print(neurons_units.shape)
    # print(neurons_units['uid'])
    # print(neurons_units['pos_x'])
    # print(neurons_units['pos_y'])
    # print(neurons_units['input_units'])
    # print(neurons_units['output_units'])
    # print(neurons_units['units_type'])
    # print(neurons_units['contents_obj'])
    # print(neurons_units['containers_obj'])
    # print(neurons_units['nodes_obj'])
    #
    # print(query_unit(neurons_units, uid=1000))
    # print(query_unit(neurons_units, uid=1001))
    # print(query_unit(neurons_units, uid=1002))
    pass  # function
