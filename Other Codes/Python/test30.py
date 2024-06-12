class Fan:
    SLOW = 1
    MEDIUM = 2
    FAST = 3

    def __init__(self, speed=SLOW, radius=5, color='blue', on=False):
        self.__speed = speed
        self.__on = on
        self.__radius = radius
        self.__color = color

    def get_speed(self):
        return self.__speed

    def set_speed(self, speed):
        self.__speed = speed

    def is_on(self):
        return self.__on

    def set_on(self, on):
        self.__on = on

    def get_radius(self):
        return self.__radius

    def set_radius(self, radius):
        self.__radius = radius

    def get_color(self):
        return self.__color

    def set_color(self, color):
        self.__color = color

    def display_info(self):
        print("Speed:", self.__speed)
        print("Radius:", self.__radius)
        print("Color:", self.__color)
        print("On:", self.__on)


fan1 = Fan(Fan.FAST, 10, 'yellow', True)
fan2 = Fan(Fan.MEDIUM, 5, 'blue', False)

print("Fan 1:")
fan1.display_info()
print()
print("Fan 2:")
fan2.display_info()
