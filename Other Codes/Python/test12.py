year = int(input("请输入年份: "))
month = int(input("请输入月份 (1-12): "))
day = int(input("请输入月份中的某一天 (1-31): "))

if month < 3:
    month += 12
    year -= 1

k = year % 100
j = year // 100

f = day + (13 * (month + 1)) // 5 + k + k // 4 + j // 4 + 5 * j
h = f % 7
days_of_week = ["Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"]
print(f"这一天是: {days_of_week[h]}")