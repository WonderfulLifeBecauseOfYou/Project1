k = 1
print("{:<10} {:>10}".format('Kilograms', 'Pounds'))
for _ in range(100):
    p = k * 2.2
    # print('%-10.f %10.1f' % (k, p))
    # print("{:<10} {:>10.2f}".format(k, p))
    print(f"{k:<10.0f} {p:10.2f}")
    k = k + 2


