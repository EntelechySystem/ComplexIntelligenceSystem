"""
模型
"""

from ComplexIntelligenceSystem_python.Core.define_units import define_neurons_units
import logging


def content_model(para: dict, globals: dict):
    logging.info("模型内容")


    ## 设置项
    # 神经元数量 = globals['神经元数量']

    ## 定义神经元单元
    units = define_neurons_units(10)

    ## 2. 定义连接单元


    ## 3. 定义容器单元
    print(units)
    print(units.dtype)
    print(units.shape)
    print(units['uid'])
    print(units['pos_x'])
    print(units['pos_y'])
    print(units['input_units'])
    print(units['output_units'])
    print(units['units_type'])
    print(units['contents_obj'])
    print(units['containers_obj'])
    print(units['nodes_obj'])

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
    pass  # function

