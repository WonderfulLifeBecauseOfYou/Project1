import math

a = float(input("请输入a的值: "))
b = float(input("请输入b的值: "))
c = float(input("请输入c的值: "))

discriminant = b**2 - 4*a*c

if discriminant > 0:
    root1 = (-b + math.sqrt(discriminant)) / (2*a)
    root2 = (-b - math.sqrt(discriminant)) / (2*a)
    print(f"方程有两个实根: {root1:.2f} 和 {root2:.2f}")
elif discriminant == 0:
    root = -b / (2*a)
    print(f"方程有一个实根: {root:.2f}")
else:
    print("方程没有实根")
