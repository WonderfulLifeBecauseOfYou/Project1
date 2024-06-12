import math


class Circle2D:
    def __init__(self, x=0, y=0, radius=0):
        self.__x = x
        self.__y = y
        self.__radius = radius

    def getX(self):
        return self.__x

    def setX(self, x):
        self.__x = x

    def getY(self):
        return self.__y

    def setY(self, y):
        self.__y = y

    def getRadius(self):
        return self.__radius

    def setRadius(self, radius):
        self.__radius = radius

    def getArea(self):
        return math.pi * self.__radius ** 2

    def getPerimeter(self):
        return 2 * math.pi * self.__radius

    def containsPoint(self, x, y):
        distance = math.sqrt((x - self.__x) ** 2 + (y - self.__y) ** 2)
        return distance <= self.__radius

    def contains(self, circle):
        distance = math.sqrt((circle.getX() - self.__x) ** 2 + (circle.getY() - self.__y) ** 2)
        return distance + circle.getRadius() <= self.__radius

    def overlaps(self, circle):
        distance = math.sqrt((circle.getX() - self.__x) ** 2 + (circle.getY() - self.__y) ** 2)
        return distance < self.__radius + circle.getRadius()

    def __cmp__(self, other):
        return cmp(self.__radius, other.getRadius())

    def __lt__(self, other):
        return self.__radius < other.getRadius()

    def __le__(self, other):
        return self.__radius <= other.getRadius()

    def __eq__(self, other):
        return self.__radius == other.getRadius()

    def __ne__(self, other):
        return self.__radius != other.getRadius()

    def __gt__(self, other):
        return self.__radius > other.getRadius()

    def __ge__(self, other):
        return self.__radius >= other.getRadius()


def main():
    x1, y1, radius1 = eval(input("Enter circle1's center x, y coordinates, and radius: "))

    x2, y2, radius2 = eval(input("Enter circle2's center x, y coordinates, and radius: "))

    c1 = Circle2D(x1, y1, radius1)
    c2 = Circle2D(x2, y2, radius2)

    print("Circle1:")
    print("Area:", c1.getArea())
    print("Perimeter:", c1.getPerimeter())

    print("\nCircle2:")
    print("Area:", c2.getArea())
    print("Perimeter:", c2.getPerimeter())

    print("\nDoes circle1 contain circle2?", c1.contains(c2))

    print("Does circle1 overlap with circle2?", c1.overlaps(c2))

    print("Does circle1 contain point ({}, {})?".format(c2.getX(), c2.getY()), c1.containsPoint(c2.getX(), c2.getY()))


main()
