scores = input("Enter scores: ").split()
scores = [int(score) for score in scores]

best_score = max(scores)
grades = []
for score in scores:
    if score >= best_score - 10:
        grade = 'A'
    elif score >= best_score - 20:
        grade = 'B'
    elif score >= best_score - 30:
        grade = 'C'
    elif score >= best_score - 40:
        grade = 'D'
    else:
        grade = 'F'
    grades.append(grade)

for i, score in enumerate(scores):
    print(f"Student {i} score is {score} and grade is {grades[i]}")
