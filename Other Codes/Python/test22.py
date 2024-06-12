import random
positive = 0
negative = 0

for i in range(1000000):
    result = random.randint(0, 1)
    if result == 1:
        positive += 1
    else:
        negative += 1

print(positive)
print(negative)
