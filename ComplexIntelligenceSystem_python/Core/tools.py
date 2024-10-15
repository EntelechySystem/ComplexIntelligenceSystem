"""
常用工具
"""
import string
from random import random


@classmethod
def generate_unique_identifier(cls):
    """
    随机生成一个8位的英文大小写字母和阿拉伯数字混合的字符串作为id。

    注意，区分大小写。

    Returns:
        str: id字符串
    """
    while True:
        # 生成一个随机的字符串
        new_identifier = ''.join(random.choices(string.ascii_letters + string.digits, k=8))

        return new_identifier
    pass  # function