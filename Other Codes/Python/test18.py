num = int(input("Enter the number of lines: "))
i = 1
for _ in range(num):
    j = 1
    n = i
    t = 2 * (num - i)
    for _ in range(t):
        print(" ", end="")
    for _ in range(i - 1):
        print(n, end=" ")
        n = n - 1
    for _ in range(i):
        print(j, end=" ")
        j = j + 1

    print("")
    i = i + 1


