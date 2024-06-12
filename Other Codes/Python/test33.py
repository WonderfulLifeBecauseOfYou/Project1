import Point as point

x1, y1 = eval(input("Enter the 1st point:"))
x2, y2 = eval(input("Enter the 2st point:"))

p1 = point.Point(x1, y1)
p2 = point.Point(x2, y2)

print("Points are", p1, "and", p2, "\nThe distance between two points is", p1.distance(p2))
print("The two points are", end="")
print("" if p2.isNearBy(p1) else "NOT", " near to each other")
