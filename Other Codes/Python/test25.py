def isValid(side1, side2, side3):
    if (side1 + side2 > side3) and (side1 + side3 > side2) and (side2 + side3 > side1):
        return True
    else:
        return False

def area(side1, side2, side3):
    p = (side1 + side2 + side3) / 2
    area = (p * (p - side1) * (p - side2) * (p - side3)) ** 1/2
    return area

x, y, z = map(float, input("Enter three sides in double: ").split(","))
if isValid(x, y, z):
    a = area(x, y, z)
    print("The area of the triangle is:", a)
else:
    print("Input is invalid")

