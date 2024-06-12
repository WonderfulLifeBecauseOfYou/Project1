class Complex:
    def __init__(self, a=0, b=0):
        self.a = a
        self.b = b

    def getRealPart(self):
        return self.a

    def getImaginaryPart(self):
        return self.b

    def __str__(self):
        if self.b != 0:
            return "(" + str(self.getRealPart()) + " + " + str(self.getImaginaryPart()) + "i)"
        else:
            return "(" + str(self.getRealPart()) + ")"

    def __add__(self, x):
        real = self.a + x.getRealPart()
        imaginary = self.b + x.getImaginaryPart()
        return Complex(real, imaginary)

    def __sub__(self, x):
        real = self.a - x.getRealPart()
        imaginary = self.b - x.getImaginaryPart()
        return Complex(real, imaginary)

    def __mul__(self, x):
        real = self.a * x.getRealPart() - self.b * x.getImaginaryPart()
        imaginary = self.b * x.getRealPart() + self.a * x.getImaginaryPart()
        return Complex(real, imaginary)

    def __truediv__(self, x):
        real = (self.a * x.getRealPart() + self.b * x.getImaginaryPart()) / (x.getRealPart() ** 2 + x.getImaginaryPart() ** 2)
        imaginary = (self.b * x.getRealPart() - self.a * x.getImaginaryPart()) / (x.getRealPart() ** 2 + x.getImaginaryPart() ** 2)
        return Complex(real, imaginary)

    def __abs__(self):
        return (self.a ** 2 + self.b ** 2) ** 0.5
