def sortColumns(m):
    sorted_m = [list(col) for col in zip(*map(sorted, zip(*m)))]
    return sorted_m


def main():
    # Prompt the user to enter the number of rows and columns
    rows = int(input("Enter the number of rows: "))
    cols = int(input("Enter the number of columns: "))

    # Prompt the user to enter the values for the matrix
    matrix = []
    for i in range(rows):
        row = []
        for j in range(cols):
            value = int(input(f"Enter a value for element at index ({i}, {j}): "))
            row.append(value)
        matrix.append(row)

    # Sort the columns in the matrix
    sorted_matrix = sortColumns(matrix)

    # Display the sorted matrix
    for row in sorted_matrix:
        print(row)


main()