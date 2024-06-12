import sys

# Prompt the user to enter filing status
status = eval(input(
    "(o-single filer，1-married jointly, \n" +
    "2-married separately，3-head of household) \n"
    + "Enter the fi1ing status: "))

# Prompt the user to enter taxable income
income = eval(input("Enter the taxable income: "))
# Compute tax
tax = 0
if status == 0:  # Compute tax for single filers
    if income <= 8350:
        tax = income * 0.10
    elif income <= 33950:
        tax = 8350 * 0.10 + (income - 8350) * 0.15
    elif income <= 82250:
        tax = 8350 * 0.10 + (33950 - 8350) * 0.15 + (income - 33950) * 0.25
    elif income <= 171550:
        tax = 8350 * 0.10 + (33950 - 8350) * 0.15 + \
              (82250 - 33950) * 0.25 + (income - 82250) * 0.28
    elif income <= 372950:
        tax = 8350 * 0.10 + (33950 - 8350) * 0.15 + \
              (82250 - 33950) * 0.25 + (171550 - 82250) * 0.28 + \
              (income - 171550) * 0.33
    else:
        tax = 8350 * 0.10 + (33950 - 8350) * 0.15 + \
              (82250 - 33950) * 0.25 + (171550 - 82250) * 0.28 + \
              (372950 - 171550) * 0.33 + (income - 372950) * 0.35

elif status == 1:  # Compute tax for married file jointly
    if income <= 16700:
        tax = income * 0.10
    elif income <= 67900:
        tax = 16700 * 0.10 + (income - 16700) * 0.15
    elif income <= 137050:
        tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + (income - 67900) * 0.25
    elif income <= 208850:
        tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + \
              (137050 - 67900) * 0.25 + (income - 137050) * 0.28
    elif income <= 372950:
        tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + \
              (137050 - 67900) * 0.25 + (208850 - 137050) * 0.28 + \
              (income - 208850) * 0.33
    else:
        tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + \
              (137050 - 67900) * 0.25 + (208850 - 137050) * 0.28 + \
              (income - 208850) * 0.33 + (income - 372950) * 0.35

elif status == 2:  # Compute tax for married separately
    print("只算了1和2，后面都一样的")
elif status == 3:  # Compute tax for head of household
    print("只算了1和2，后面都一样的")
else:
    print("Error: invalid status")
    sys.exit()

# Display the result
print("Tax is", format(tax, ".2f"))
