m = 0
print("{:<10} {:<10}".format('Miles', 'Kilograms'))
for _ in range(10):
    m = m + 1
    k = m * 1.609
    print('%-10.f %-10.3f' % (m, k))
