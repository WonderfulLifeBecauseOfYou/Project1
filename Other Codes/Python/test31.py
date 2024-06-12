import math


class RegularPolygon:
    def __init__(self, n=3, side=1, x=0, y=0):
        self.__n = n
        self.__side = side
        self.__x = x
        self.__y = y

    def get_n(self):
        return self.__n

    def set_n(self, n):
        self.__n = n

    def get_side(self):
        return self.__side

    def set_side(self, side):
        self.__side = side

    def get_x(self):
        return self.__x

    def set_x(self, x):
        self.__x = x

    def get_y(self):
        return self.__y

    def set_y(self, y):
        self.__y = y

    def get_perimeter(self):
        return self.__n * self.__side

    def get_area(self):
        area = (self.__n * self.__side ** 2) / (4 * math.tan(math.pi / self.__n))
        return area


polygon1 = RegularPolygon()
print("Polygon 1 - Perimeter:", polygon1.get_perimeter())
print("Polygon 1 - Area:", polygon1.get_area())

polygon2 = RegularPolygon(6, 4)
print("Polygon 2 - Perimeter:", polygon2.get_perimeter())
print("Polygon 2 - Area:", polygon2.get_area())

polygon3 = RegularPolygon(10, 4, 5.6, 7.8)
print("Polygon 3 - Perimeter:", polygon3.get_perimeter())
print("Polygon 3 - Area:", polygon3.get_area())