"""
运作所提供的件以提供功能
"""



# 给指定的查询添加指定的信号
def add_syms(query:np.array, syms:np.array):
    """
    添加一个信号
    Args:
        query (np.array): 查询
        syms (np.array): 符号
    """
    return np.concatenate((query, syms))
    pass  # function



