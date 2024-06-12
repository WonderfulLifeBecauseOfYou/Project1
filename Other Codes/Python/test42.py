def equals(m1, m2):
    if len(m1) != len(m2) or len(m1[0]) != len(m2[0]):
        return False

    for i in range(len(m1)):
        for j in range(len(m1[0])):
            if m1[i][j] != m2[i][j]:
                return False

    return True


def main():
    # Prompt the user to enter the number of rows and columns for matrix 1
    rows1 = int(input("Enter the number of rows for matrix 1: "))
    cols1 = int(input("Enter the number of columns for matrix 1: "))

    # Prompt the user to enter the values for matrix 1
    matrix1 = []
    for i in range(rows1):
        row = []
        for j in range(cols1):
            value = int(input(f"Enter a value for element at index ({i}, {j}) for matrix 1: "))
            row.append(value)
        matrix1.append(row)

    # Prompt the user to enter the number of rows and columns for matrix 2
    rows2 = int(input("Enter the number of rows for matrix 2: "))
    cols2 = int(input("Enter the number of columns for matrix 2: "))

    # Prompt the user to enter the values for matrix 2
    matrix2 = []
    for i in range(rows2):
        row = []
        for j in range(cols2):
            value = int(input(f"Enter a value for element at index ({i}, {j}) for matrix 2: "))
            row.append(value)
        matrix2.append(row)

    # Check if the matrices are identical
    if equals(matrix1, matrix2):
        print("The matrices are identical.")
    else:
        print("The matrices are not identical.")


main()
