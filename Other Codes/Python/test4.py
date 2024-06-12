import turtle


t = turtle.Turtle()
for _ in range(2):
    t.forward(100)
    t.left(90)
    t.forward(50)
    t.left(90)
t.goto(20, 20)
for _ in range(2):
    t.forward(100)
    t.left(90)
    t.forward(50)
    t.left(90)

t.penup()
t.goto(0, 50)
t.pendown()
t.goto(20, 70)
t.penup()
t.goto(100, 50)
t.pendown()
t.goto(120, 70)
t.penup()
t.goto(100, 0)
t.pendown()
t.goto(120, 20)
t.hideturtle()
turtle.done()
