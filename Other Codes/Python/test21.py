
def perfect(a):
    sum = 0
    for i in range(1, a, 1):
        if a % i == 0:
            sum = sum + i
    if sum == a:
        return 1
    else:
        return 0

for i in range(1, 10000, 1):
    if perfect(i) == 1:
        print(i)
