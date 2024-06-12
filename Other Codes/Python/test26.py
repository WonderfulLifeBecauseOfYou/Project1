class Rectangle:
    def __init__(self, width=1, height=2):
        self.width = width
        self.height = height

    def getArea(self):
        return self.width * self.height

    def getPerimeter(self):
        return 2 * (self.width + self.height)

rectangle1 = Rectangle(4, 40)

rectangle2 = Rectangle(3.5, 35.7)

print("Rectangle 1:")
print("Width:", rectangle1.width)
print("Height:", rectangle1.height)
print("Area:", rectangle1.getArea())
print("Perimeter:", rectangle1.getPerimeter())

print("\nRectangle 2:")
print("Width:", rectangle2.width)
print("Height:", rectangle2.height)
print("Area:", rectangle2.getArea())
print("Perimeter:", rectangle2.getPerimeter())