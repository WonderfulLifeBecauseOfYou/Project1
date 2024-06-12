def sortRows(m):
    sorted_matrix = [sorted(row) for row in m]
    return sorted_matrix

def main():
    rows, cols = map(int, input("Enter the number of rows and columns (separated by a space): ").split())

    matrix = []
    for i in range(rows):
        row_input = input(f"Enter values for row {i+1} (separated by spaces): ")
        row_values = list(map(int, row_input.split()))
        matrix.append(row_values)

    sorted_matrix = sortRows(matrix)
    print("Original matrix:")
    for row in matrix:
        print(row)
    print("Row-sorted matrix:")
    for row in sorted_matrix:
        print(row)

if __name__ == "__main__":
    main()
