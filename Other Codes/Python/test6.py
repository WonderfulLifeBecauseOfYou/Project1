import math

radius = float(input("请输入圆柱的半径: "))
length = float(input("请输入圆柱的长度: "))

area = math.pi * radius * radius
volume = area * length

print("圆柱的面积是:", "{:.2f}".format(area))
print(f"圆柱的体积是: {volume:.2f}")
