def count(s):
    counts = [0] * 10
    for char in s:
        if char.isdigit():
            digit = int(char)
            counts[digit] += 1
    return counts

s = input("Enter a string: ")

result = count(s)

for digit, count in enumerate(result):
    if count == 1:
        print(f"{digit} occurs 1 time")
    else:
        print(f"{digit} occurs {count} times")
