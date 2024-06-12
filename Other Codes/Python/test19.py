i = 1
for _ in range(9):
    j = 1
    for _ in range(i):
        print(j, "*", i, "=", i*j, end="   ")
        j = j + 1
    print("")
    i = i + 1
