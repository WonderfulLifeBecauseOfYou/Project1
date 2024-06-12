def reverse(a):
    sum = 0
    while a != 0:
        sum = sum * 10 + a % 10
        a = a // 10
    return sum
number = int(input("Enter a number: "))
print(reverse(number))


