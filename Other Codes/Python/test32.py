import math

class QuadraticEquation:
    def __init__(self, a, b, c):
        self.__a = a
        self.__b = b
        self.__c = c

    def getA(self):
        return self.__a

    def getB(self):
        return self.__b

    def getC(self):
        return self.__c

    def getDiscriminant(self):
        return self.__b**2 - 4 * self.__a * self.__c

    def getRoot1(self):
        discriminant = self.getDiscriminant()
        if discriminant >= 0:
            return (-self.__b + math.sqrt(discriminant)) / (2 * self.__a)
        else:
            return 0

    def getRoot2(self):
        discriminant = self.getDiscriminant()
        if discriminant > 0:
            return (-self.__b - math.sqrt(discriminant)) / (2 * self.__a)
        else:
            return 0

def main():
    a = float(input("Enter coefficient a: "))
    b = float(input("Enter coefficient b: "))
    c = float(input("Enter coefficient c: "))

    equation = QuadraticEquation(a, b, c)
    discriminant = equation.getDiscriminant()

    if discriminant > 0:
        root1 = equation.getRoot1()
        root2 = equation.getRoot2()
        print("The equation has two roots:", root1, "and", root2)
    elif discriminant == 0:
        root = equation.getRoot1()
        print("The equation has one root:", root)
    else:
        print("The equation has no roots.")

main()