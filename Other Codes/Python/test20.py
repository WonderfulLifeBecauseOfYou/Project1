for i in range(10000, 110000, 10000):

    a = 0
    x = 1
    for _ in range(i):
        a = float((a + ((-1) ** (x + 1))/(2 * x - 1)))
        x = x + 1
    print("The PI is", 4*a, "for i =", i)

