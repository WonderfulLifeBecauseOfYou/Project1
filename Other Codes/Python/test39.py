def locateMax(m):
    max_value = m[0][0]
    max_i, max_j = 0, 0

    for i in range(len(m)):
        for j in range(len(m[i])):
            if m[i][j] > max_value:
                max_value = m[i][j]
                max_i, max_j = i, j

    return max_i, max_j

def main():
    rows, cols = map(int, input("Enter the number of rows and columns: ").split(","))
    input("Enter the matrix: \n")
    matrix = []
    for i in range(rows):
        row = list(map(int, input().split()))
        matrix.append(row)

    max_i, max_j = locateMax(matrix)
    print(f"The location of the biggest element is: ({max_i}, {max_j})")

if __name__ == "__main__":
    main()
