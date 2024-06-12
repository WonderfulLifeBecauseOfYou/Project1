
number = int(input("请输入一个0到1000之间的整数: "))

sum = 0
if number > 1000 or number < 0:
    print("no")
    raise()
else:
    while number:
        sum += number % 10
        number //= 10

print(f"数字之和是: {sum}")
