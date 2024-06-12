class Point:
    def __init__(self, x=0, y=0):
        self.x = x
        self.y = y

    def getX(self):
        return self.x

    def getY(self):
        return self.y

    def distance(self, p1):
        return ((self.x - p1.getX()) ** 2 + (self.y - p1.getY()) ** 2) ** 0.5

    def isNearBy(self, p1):
        return self.distance(p1) < 5

    def __str__(self):
        return "(" + str(self.x) + "," + str(self.y) + ")"

