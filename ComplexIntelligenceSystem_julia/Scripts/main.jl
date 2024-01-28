using Pkg
Pkg.activate("./ComplexIntelligenceSystem_julia")

# using DrWatson
# quickactivate("./ComplexIntelligenceSystem_julia")

using Agents

"""配置全局参数"""
config = Dict(
    :N_entity => 1000, # 总的实体之数量
    :N_Ji => 1000, # 机实体之数量
    :N_Qi => 1000, # 器实体之数量
    :N_Sign => 1000, # 信实体之数量
    :N_Data => 1000, # 数实体之数量
)

"""初始化函数"""
function model_initiation()
    # 初始化实体
    # 初始化机实体
    # 初始化器实体
    # 初始化信实体
    # 初始化数实体
    # 初始化空间
    # 初始化模型
end

"""定义实体之"""

"""定义实体之"""
function EntityBody()
end

"""定义实体"""
@agent EntityAgent GraphAgent begin
    id::Int # 编号
    uid::Int # 唯一编号
    type::Symbol # 类型
    fun_type::Symbol  # 功能类型
    position::NTuple{3,Float16} # 所在的三维空间位置
    body::Int # 主体
    links::Array{Int,config[:N_entity]} # 实体与实体之间的连接，以数组形式表示，数组元素是实体之唯一编号
end

"""定义机实体"""
@agent Ji GraphAgent begin
    id::Int # 编号
    uid::Int # 唯一编号
    type::Symbol # 类型
    position::NTuple{3,Float16} # 所在的三维空间位置
    body::Int # 主体
    JiLinks::Array{Int,config[:N_Ji]} # 实体与实体之间的连接，以数组形式表示，数组元素是实体之唯一编号
end

"""定义器实体"""


"""定义空间"""
space = GraphSpace(complete_graph(config[:N_Ji_Ji])) # 创建一个完全图空间

## 创建模型

# """定义模型"""
# model = ABM(Ji, space)

rng = Xoshiro(seed)
@assert length(Ns) ==
length(Is) ==
length(β_und) ==
length(β_det) ==
size(migration_rates, 1) "length of Ns, Is, and B, and number of rows/columns in migration_rates should be the same "
@assert size(migration_rates, 1) == size(migration_rates, 2) "migration_rates rates should be a square matrix"


# """创建调度"""
schelling = AgentBasedModel(EntityAgent, space; properties=config,rng=rng)

"""定义初始化方式"""
function initialize(; total_agents=config[:N_Ji_Ji])
    #NOW
end


