using System;
using System.Collections.Generic;
using MatrixExceptions;
using System.IO;
using System.Drawing.Drawing2D;

namespace MatrixApplication
{
    namespace Matrices
    {
        public interface IMatrixOperations<T>
        {
            Matrix<T> Add(Matrix<T> other);
            Matrix<T> Subtract(Matrix<T> other);
            Matrix<T> Multiply(Matrix<T> other);
            Matrix<T> Transpose();
        }

        public abstract class Matrix<T> : IMatrixOperations<T>
        {
            public T[,] data;

            public Matrix(int rows, int cols)
            {
                data = new T[rows, cols];
            }

            public abstract Matrix<T> Add(Matrix<T> other);
            public abstract Matrix<T> Subtract(Matrix<T> other);
            public abstract Matrix<T> Multiply(Matrix<T> other);
            public abstract Matrix<T> Transpose();
        }

        public class NumericMatrix : Matrix<double>
        {
            public NumericMatrix(int rows, int cols) : base(rows, cols)
            {
            }

            public override Matrix<double> Add(Matrix<double> other)
            {
                if (other is NumericMatrix numericMatrix)
                {
                    if (data.GetLength(0) != numericMatrix.data.GetLength(0) || data.GetLength(1) != numericMatrix.data.GetLength(1))
                    {
                        throw new MatrixException("Matrices must have the same dimensions for addition.");
                    }

                    NumericMatrix result = new NumericMatrix(data.GetLength(0), data.GetLength(1));

                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            result.data[i, j] = this.data[i, j] + numericMatrix.data[i, j];
                        }
                    }

                    return result;
                }
                else
                {
                    throw new MatrixException("Cannot add matrices of different types.");
                }
            }

            public override Matrix<double> Subtract(Matrix<double> other)
            {
                if (other is NumericMatrix numericMatrix)
                {
                    if (data.GetLength(0) != numericMatrix.data.GetLength(0) || data.GetLength(1) != numericMatrix.data.GetLength(1))
                    {
                        throw new MatrixException("Matrices must have the same dimensions for subtraction.");
                    }

                    NumericMatrix result = new NumericMatrix(data.GetLength(0), data.GetLength(1));

                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            result.data[i, j] = this.data[i, j] - numericMatrix.data[i, j];
                        }
                    }

                    return result;
                }
                else
                {
                    throw new MatrixException("Cannot subtract matrices of different types.");
                }
            }

            public override Matrix<double> Multiply(Matrix<double> other)
            {
                if (other is NumericMatrix numericMatrix)
                {
                    if (data.GetLength(1) != numericMatrix.data.GetLength(0))
                    {
                        throw new MatrixException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
                    }

                    NumericMatrix result = new NumericMatrix(data.GetLength(0), numericMatrix.data.GetLength(1));

                    for (int i = 0; i < result.data.GetLength(0); i++)
                    {
                        for (int j = 0; j < result.data.GetLength(1); j++)
                        {
                            result.data[i, j] = 0;

                            for (int k = 0; k < data.GetLength(1); k++)
                            {
                                result.data[i, j] += this.data[i, k] * numericMatrix.data[k, j];
                            }
                        }
                    }

                    return result;
                }
                else
                {
                    throw new MatrixException("Cannot multiply matrices of different types.");
                }
            }

            public override Matrix<double> Transpose()
            {
                NumericMatrix result = new NumericMatrix(data.GetLength(1), data.GetLength(0));

                // Expresie lambda pentru a transpune matricea
                Func<int, int, double> transposeExpression = (i, j) => this.data[j, i];

                for (int i = 0; i < result.data.GetLength(0); i++)
                {
                    for (int j = 0; j < result.data.GetLength(1); j++)
                    {
                        result.data[i, j] = transposeExpression(i, j);
                    }
                }

                return result;
            }

            public static NumericMatrix operator +(NumericMatrix matrix1, NumericMatrix matrix2)
            {
                return matrix1.Add(matrix2) as NumericMatrix;
            }

            public static NumericMatrix operator -(NumericMatrix matrix1, NumericMatrix matrix2)
            {
                return matrix1.Subtract(matrix2) as NumericMatrix;
            }

            public static NumericMatrix operator *(NumericMatrix matrix1, NumericMatrix matrix2)
            {
                return matrix1.Multiply(matrix2) as NumericMatrix;
            }

            public static NumericMatrix operator !(NumericMatrix matrix)
            {
                return matrix.Transpose() as NumericMatrix;
            }

            public static NumericMatrix operator ^(NumericMatrix matrix1, int putere)
            {
                NumericMatrix matrix2 = matrix1;
                return matrix2.Multiply(matrix1) as NumericMatrix;
            }

            public static List<NumericMatrix> ReadMatricesFromFile(string filePath)
            {
                List<NumericMatrix> matrices = new List<NumericMatrix>();

                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    int currentIndex = 0;

                    // Citeste numarul de matrici
                    int numberOfMatrices = int.Parse(lines[currentIndex++]);

                    for (int matrixIndex = 0; matrixIndex < numberOfMatrices; matrixIndex++)
                    {
                        // Sare peste linea libera dintre matrici
                        currentIndex++;

                        // Citeste dimensiunea matricii
                        string[] dimensions = lines[currentIndex].Split(' ');
                        int rows = int.Parse(dimensions[0]);
                        int cols = int.Parse(dimensions[1]);

                        // Cream un NumericMatrix
                        NumericMatrix matrix = new NumericMatrix(rows, cols);

                        // Citeste matricea
                        for (int i = 0; i < rows; i++)
                        {
                            string[] rowValues = lines[currentIndex + i + 1].Split(' '); // Fix: index + i + 1
                            for (int j = 0; j < cols; j++)
                            {
                                matrix.data[i, j] = double.Parse(rowValues[j]);
                            }
                        }

                        matrices.Add(matrix);
                        currentIndex += rows + 1; // Urmatoarea matrice
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }

                return matrices;
            }

        }
    }
}