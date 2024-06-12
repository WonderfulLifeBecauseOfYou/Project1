s1 = "COMP2021PythonProgramming"
s2 = s1
s3 = "COMP"
s4 = "to"

a = s1 == s2
b = s2.count('o')
m = len(s1)
c = id(s1) == id(s2)
n = max(s1)
d = id(s1) == id(s3)
o = min(s1)
e = s1 <= s4
p = s1[-4]
f = s2 >= s4
q = s1.lower()
g = s1 != s4
r = s1.rfind('o')
h = s1.upper()
s = s1.startswith("o")
i = s1.find(s4)
t = s1.endswith("o")
j = s1[4]
u = s1.isalpha()
k = s1[4:8]
v = s1 + s1

print("a:", a)
print("b:", b)
print("m:", m)
print("c:", c)
print("n:", n)
print("d:", d)
print("o:", o)
print("e:", e)
print("p:", p)
print("f:", f)
print("q:", q)
print("g:", g)
print("r:", r)
print("h:", h)
print("s:", s)
print("i:", i)
print("t:", t)
print("j:", j)
print("u:", u)
print("k:", k)
print("v:", v)