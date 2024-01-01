using MatrixApplication.Matrices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Proiect_Matrix
{
    public partial class Form1 : Form
    {
        private List<NumericMatrix> matrices;

        private string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data_set";

       
        public Form1()
        {
            InitializeComponent();
        }

        private void read_data_matrix_Click(object sender, EventArgs e)
        {
            string inputFilePath = Path.Combine(path, "input.txt");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Check if input.txt exists in data_set directory, and delete it if it does

            if (File.Exists(inputFilePath))
            {
                try
                {
                    File.Delete(inputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Text Files|*.txt";
                openFileDialog1.Title = "Select a text file";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;

                    try
                    {
                        // Copy the selected file to the data_set directory as input.txt
                        File.Copy(filePath, inputFilePath);
                        MessageBox.Show("File copied successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void add_matrices_Click(object sender, EventArgs e)
        {
            string inputFilePath = Path.Combine(path, "input.txt");
            matrices = NumericMatrix.ReadMatricesFromFile(inputFilePath);
            if (matrices != null && matrices.Count >= 2)
            {
                try
                {
                    NumericMatrix result = matrices[0];
                    for (int i = 1; i < matrices.Count; i++)
                    {
                        result += matrices[i];
                    }

                    // Creează un fișier text numit sum_matrix.txt în folderul data_set
                    string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data_set", "sum_matrix.txt");

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        // Afiseaza in fisier rezultatul final
                        WriteMatrixToFile(writer, result);
                    }

                    // Deschide fisierul
                    System.Diagnostics.Process.Start(outputFilePath);

                    MessageBox.Show("Rezultat salvat in sum_matrix.txt!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Introdu cel putin 2 matrici pentru suma.");
            }
        }

        private void WriteMatrixToFile(StreamWriter writer, NumericMatrix matrix)
        {
            for (int i = 0; i < matrix.data.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.data.GetLength(1); j++)
                {
                    writer.Write(matrix.data[i, j] + " ");
                }
                writer.WriteLine();
            }
        }

        private void subtract_matrices_Click(object sender, EventArgs e)
        {
            string inputFilePath = Path.Combine(path, "input.txt");
            matrices = NumericMatrix.ReadMatricesFromFile(inputFilePath);
            if (matrices != null && matrices.Count >= 2)
            {
                try
                {
                    NumericMatrix result = matrices[0];
                    for (int i = 1; i < matrices.Count; i++)
                    {
                        result -= matrices[i];
                    }

                    // Creează un fișier text numit diff_matrix.txt în folderul data_set
                    string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data_set", "diff_matrix.txt");

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        // Afiseaza in fisier rezultatul final
                        WriteMatrixToFile(writer, result);
                    }

                    // Deschide fisierul
                    System.Diagnostics.Process.Start(outputFilePath);

                    MessageBox.Show("Rezultat salvat in diff_matrix.txt!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Introdu cel putin 2 matrici pentru diferenta.");
            }
        }

        private void multiply_matrices_Click(object sender, EventArgs e)
        {
            string inputFilePath = Path.Combine(path, "input.txt");
            matrices = NumericMatrix.ReadMatricesFromFile(inputFilePath);
            if (matrices != null && matrices.Count >= 2)
            {
                try
                {
                    NumericMatrix result = matrices[0];
                    for (int i = 1; i < matrices.Count; i++)
                    {
                        result *= matrices[i];
                    }

                    // Creează un fișier text numit product_matrix.txt în folderul data_set
                    string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data_set", "product_matrix.txt");

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        // Afiseaza in fisier rezultatul final
                        WriteMatrixToFile(writer, result);
                    }

                    // Deschide fisierul
                    System.Diagnostics.Process.Start(outputFilePath);

                    MessageBox.Show("Rezultat salvat in product_matrix.txt!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Introdu cel putin 2 matrici pentru produs.");
            }
        }

        private void transpose_matrices_Click(object sender, EventArgs e)
        {
            string inputFilePath = Path.Combine(path, "input.txt");
            matrices = NumericMatrix.ReadMatricesFromFile(inputFilePath);

            if (matrices != null && matrices.Count > 0)
            {
                try
                {
                    // Creează un fișier text numit transposed_matrices.txt în folderul data_set
                    string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data_set", "transposed_matrices.txt");

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        foreach (var originalMatrix in matrices)
                        {
                            // Transpose the current matrix
                            NumericMatrix transposedMatrix =!originalMatrix;

                            // Afiseaza matricea originala si transpusa in fisier
                            writer.WriteLine("Original Matrix:");
                            WriteMatrixToFile(writer, originalMatrix);
                            writer.WriteLine("Transpose Matrix:");
                            WriteMatrixToFile(writer, transposedMatrix);
                            writer.WriteLine();
                        }
                    }

                    // Deschide fisierul
                    System.Diagnostics.Process.Start(outputFilePath);

                    MessageBox.Show("Matricele transpuse sunt salvate in transposed_matrices.txt!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nicio matrice gasita.");
            }
        }


        private void matrices_power_Click(object sender, EventArgs e)
        {
            string inputFilePath = Path.Combine(path, "input.txt");
            matrices = NumericMatrix.ReadMatricesFromFile(inputFilePath);

            if (matrices != null && matrices.Count > 0)
            {
                // Verifica daca puterea introdusa este pozitiva 
                if (int.TryParse(n_power.Text, out int power) && power >= 0)
                {
                    try
                    {
                        // Creează un fișier text numit powered_matrices.txt în folderul data_set
                        string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data_set", "powered_matrices.txt");

                        using (StreamWriter writer = new StreamWriter(outputFilePath))
                        {
                            foreach (var matrix in matrices)
                            {
                                
                                NumericMatrix poweredMatrix = matrix ^ power;

                                // Afiseaza matricea originala si matricea la puterea N in fisier
                                writer.WriteLine($"Original Matrix (la puterea {power}):");
                                WriteMatrixToFile(writer, matrix);
                                writer.WriteLine("Powered Matrix:");
                                WriteMatrixToFile(writer, poweredMatrix);
                                writer.WriteLine();
                            }
                        }

                        // Deschide fisierul
                        System.Diagnostics.Process.Start(outputFilePath);

                        MessageBox.Show($"Matriciile ridicata la puterea {power} sunt salvate in powered_matrices.txt!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Intro o valoare pozitiva pentru putere.");
                }
            }
            else
            {
                MessageBox.Show("Nicio matrice gasita.");
            }
        }
    }
}
