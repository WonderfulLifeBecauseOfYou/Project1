seconds = int(input("请输入秒数: "))

minutes = seconds // 60
hours = minutes // 60
days = hours // 24
months = days // 30
years = months // 12

print(f"{seconds}秒是 {years}年, {months % 12}月, {days % 30}天, {hours % 24}小时, {minutes % 60}分钟.")
