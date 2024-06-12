import turtle
import time

t = turtle.Turtle()
t.speed(9)
t.width(2)

t.penup()
t.goto(0, -150)
t.pendown()
t.circle(150)

time = time.localtime()
hour = time.tm_hour
minute = time.tm_min

turtle.penup()
turtle.hideturtle()
turtle.setpos(-13, -170)
turtle.write(hour)
turtle.penup()
turtle.hideturtle()
turtle.setpos(-0, -170)
turtle.write(":")
turtle.penup()
turtle.hideturtle()
turtle.setpos(5, -170)
turtle.write(minute)

t.penup()
t.goto(0, 0)
t.setheading(90)
t.right(minute * 6)
t.pendown()
t.forward(120)

t.penup()
t.goto(0, 0)
t.setheading(90)
t.right(hour * 30 + minute * 0.5)
t.pendown()
t.forward(80)

turtle.done()
