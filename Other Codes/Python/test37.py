def eliminateDuplicates(lst):
    unique_list = list(set(lst))
    return unique_list

numbers = input("Enter ten numbers: ").split()
numbers = [int(num) for num in numbers]

result = eliminateDuplicates(numbers)

print("The distinct numbers are:", end=" ")
for num in result:
    print(num, end=" ")
