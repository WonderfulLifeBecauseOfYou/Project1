import turtle

x1, y1, r1 = map(float, input("请输入第一个圆的中心坐标和半径: ").split(","))
x2, y2, r2 = map(float, input("请输入第二个圆的中心坐标和半径: ").split(","))

t = turtle.Turtle()

t.penup()
t.goto(x1, y1 - r1)
t.pendown()
t.circle(r1)

t.penup()
t.goto(x2, y2 - r2)
t.pendown()
t.circle(r2)
turtle.done()

