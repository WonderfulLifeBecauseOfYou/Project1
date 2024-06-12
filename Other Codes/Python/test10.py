import turtle

screen = turtle.Screen()
screen.bgcolor("white")

t = turtle.Turtle()
t.speed(5)
t.color("red")

t.begin_fill()
t.penup()
t.goto(-70, 120)
t.pendown()
for _ in range(6):
    t.forward(140)
    t.right(60)
t.end_fill()

t.penup()
t.color("white")
t.goto(0, -30)
t.write("STOP", align="center", font=("Arial", 40, "bold"))

turtle.done()


