num_counts = {}
nums = input("Enter integers between 1 and 100: ").split()
nums = [int(num) for num in nums]
for num in nums:
    if num in num_counts:
        num_counts[num] += 1
    else:
        num_counts[num] = 1
print(num_counts)
for num in num_counts:
    if num_counts[num] == 1:
        print(f"{num} occurs 1 time")
    else:
        print(f"{num} occurs {num_counts[num]} times")
