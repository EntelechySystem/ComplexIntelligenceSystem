using Pkg
Pkg.activate("./ComplexIntelligenceSystem_julia")

# using DrWatson
# quickactivate("./ComplexIntelligenceSystem_julia")

using Agents

"""配置全局参数"""
config = Dict(
    :N => 1000,
)

"""定义机器单元"""
@agent MachineUnit GraphAgent begin
    id::Int # 机器单元之编号
    uid::Int # 机器单元之唯一编号
    type::Symbol # 机器单元之类型
    position::Int # 机器单元之所在的位置
    body::Int #机器单元之身体
end


"""定义空间"""
space = GraphSpace(complete_graph(config[:N]))

"""定义模型"""
model = ABM(Ji, space)

"""定义初始化方式"""
function initialize(;total_agents=config[:N])
    #NOW
end


