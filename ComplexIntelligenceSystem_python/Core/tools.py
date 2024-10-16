"""
常用工具
"""
import string
import random
import numpy as np
import torch

class Tools:
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



    @classmethod
    def encode_string_array(cls, strings, max_len=128):
        # 创建一个 tensor，存储字符串的 ASCII 数值表示，空位用 ASCII 码 32 (空格) 填充
        encoded_array = np.full(max_len, 32, dtype=np.int32)



        for i, s in enumerate(strings):
            # 将每个字符串的前 max_len 个字符转换为 ASCII 值
            # ascii_values = [ord(c) for c in s[:max_len]]
            # encoded_array[i, :len(ascii_values)] = ascii_values
            ascii_values = ord(s[:max_len])
            encoded_array[i] = ascii_values

        # #DEBUG 打印效果
        print(encoded_array)

        # 转换为 PyTorch tensor
        return torch.tensor(encoded_array, dtype=torch.int32)

    # # 示例
    # strings = ['unit1', 'unit2', 'unit_longer_name']
    # max_len = 10
    # encoded_tensor = encode_string_array(strings, max_len)
    # print(encoded_tensor)

    @classmethod
    def decode_string_array(cls, encoded_tensor):
        decoded_strings = []

        # 遍历 tensor，逐个元素转换回字符串
        for row in encoded_tensor:
            chars = chr(row.item())  # 32 是空格的 ASCII
            decoded_strings.append(''.join(chars))

        return ''.join(decoded_strings)

    # # 示例解码
    # decoded_strings = decode_string_array(encoded_tensor)
    # print(decoded_strings)


if __name__ == '__main__':
    # 生成一个随机的字符串
    new_identifier = Tools.generate_unique_identifier()
    print(f'\n{new_identifier}')
    # 编码字符串数组
    encoded_array=Tools.encode_string_array(new_identifier)
    print(encoded_array)
    # 解码字符串数组
    decoded_strings=Tools.decode_string_array(encoded_array)
    print(decoded_strings)
    pass  # function