def sumDigits(a):
    sum = 0
    while a != 0:
        sum += a % 10
        a = a // 10
    return sum
n = eval(input("Enter a n: "))
print(sumDigits(n))




