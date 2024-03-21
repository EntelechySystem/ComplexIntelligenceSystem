"""
引擎之初始化环境
"""

# ## 包含环境
# using Pkg
# Pkg.activate(".")


## 添加自定义的环境变量
ENV["ENGINE_PATH"] = abspath(joinpath(@__DIR__, "../../", "Engine"))
ENV["DATA_PATH"] = abspath(joinpath(ENV["ENGINE_PATH"], "../", "Data"))
ENV["AGENTS_DATA_PATH"] = abspath(joinpath(ENV["DATA_PATH"], "AgentsData"))
ENV["SIMS_DATA_PATH"] = abspath(joinpath(ENV["DATA_PATH"], "SimulationsData"))
ENV["SETTINGS_DATA_PATH"] = abspath(joinpath(ENV["DATA_PATH"], "SettingsData"))
ENV["LIBRARY_PATH"] = abspath(joinpath(ENV["ENGINE_PATH"], "Library"))
ENV["CONFIG_LIBRARY_PATH"] = abspath(joinpath(ENV["LIBRARY_PATH"], "Config"))
ENV["SETTINGS_LIBRARY_PATH"] = abspath(joinpath(ENV["LIBRARY_PATH"], "Settings"))
ENV["GLOBALS_LIBRARY_PATH"] = abspath(joinpath(ENV["LIBRARY_PATH"], "Globals"))

## 临时修改默认的环境变量


## 包括文件
include("./../Core/define_const.jl")
include("./../Tools/Tools.jl")
include("./../Tools/DataManageTools.jl")
include("./../Tools/MathTool.jl")
include("./../Tools/PhysicsTools.jl")
include("./../Core/define_type.jl")
include("./../Functions/visualization.jl")






