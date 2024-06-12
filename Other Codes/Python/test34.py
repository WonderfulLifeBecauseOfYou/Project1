import Complex as c
a1, b1 = eval(input("Enter the first complex number:"))
a2, b2 = eval(input("Enter the second complex number:"))

c1 = c.Complex(a1, b1)
c2 = c.Complex(a2, b2)

print(c1, "+", c2, "=", c1+c2)
print(c1, "-", c2, "=", c1-c2)
print(c1, "*", c2, "=", c1*c2)
print(c1, "/", c2, "=", c1/c2)
print("|", c1, "|","=", abs(c1))