x1, y1 = map(float, input("请输入第一个点的坐标 (x1, y1): ").split(","))
x2, y2 = map(float, input("请输入第二个点的坐标 (x2, y2): ").split(","))
x3, y3 = map(float, input("请输入第三个点的坐标 (x3, y3): ").split(","))

s1 = ((x1 - x2) ** 2 + (y1 - y2) ** 2) ** 0.5
s2 = ((x1 - x3) ** 2 + (y1 - y3) ** 2) ** 0.5
s3 = ((x2 - x3) ** 2 + (y2 - y3) ** 2) ** 0.5
s = (s1 + s2 + s3) / 2

area = (s * (s - s1) * (s - s2) * (s - s3)) ** 0.5
print(f"三角形的面积是: {area:.1f}")
