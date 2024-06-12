using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deksomboon_Inkjet.Class
{
    public class LocalStorage
    {
        public static string GetPrograms()
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Expiration file not found. Please check the file path.");
                    return null;
                }

                // Read all text from the file
                string fileContent = File.ReadAllText(filePath);

                // Find the latest inkjet data
                string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.StartsWith("programs="))
                    {
                        return line.Substring("programs=".Length);
                    }
                }

                // If inkjet data is not found
                Console.WriteLine("programs data not found in the file.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public static void Add_Local_ComPort(string inkjetValue)
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    //MessageBox.Show("Expiration file not found. Please check the file path.", "File Not Found");
                    Console.WriteLine("Expiration file not found. Please check the file path.", "File Not Found");
                    return; // Exit the method if the file does not exist
                }

                // Read existing data from the file
                string fileContent = File.ReadAllText(filePath);

                // Check if inkjet data already exists in the file
                if (fileContent.Contains("comport="))
                {
                    // Update existing inkjet data with the new value
                    string updatedContent = Regex.Replace(fileContent, @"comport=.*?(?:\r\n|$)", $"comport={inkjetValue}\r\n");
                    File.WriteAllText(filePath, updatedContent);
                }
                else
                {
                    // Append the inkjet data to the existing data with a comma
                    string newData = fileContent + $"comport={inkjetValue}\r\n";
                    File.WriteAllText(filePath, newData);
                }

                //MessageBox.Show("Successfully added or updated comport data in the file.", "Data Added/Updated");
                Console.WriteLine("Successfully added or updated comport data in the file.", "Data Added / Updated");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error occurred while writing to the file: {e.Message}");
                //MessageBox.Show("An error occurred while writing to the file. Please try again.", "Error");
            }
        }

        public static string ReadLocalComport()
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Expiration file not found. Please check the file path.");
                    return null;
                }

                // Read all text from the file
                string fileContent = File.ReadAllText(filePath);

                // Find the latest inkjet data
                string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.StartsWith("comport="))
                    {
                        return line.Substring("comport=".Length);
                    }
                }

                // If inkjet data is not found
                Console.WriteLine("comport data not found in the file.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public static void AddInkjetData(string inkjetValue)
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Expiration file not found. Please check the file path.", "File Not Found");
                    return; // Exit the method if the file does not exist
                }

                // Read existing data from the file
                string fileContent = File.ReadAllText(filePath);

                // Check if inkjet data already exists in the file
                if (fileContent.Contains("inkjet="))
                {
                    // Update existing inkjet data with the new value
                    string updatedContent = Regex.Replace(fileContent, @"inkjet=.*?(?:\r\n|$)", $"inkjet={inkjetValue}\r\n");
                    File.WriteAllText(filePath, updatedContent);
                }
                else
                {
                    // Append the inkjet data to the existing data with a comma
                    string newData = fileContent + $"inkjet={inkjetValue}\r\n";
                    File.WriteAllText(filePath, newData);
                }

                //MessageBox.Show("Successfully added or updated inkjet data in the file.", "Data Added/Updated");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error occurred while writing to the file: {e.Message}");
                MessageBox.Show("An error occurred while writing to the file. Please try again.", "Error");
            }
        }

        public static void AddLocationData(string locationValue)
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Expiration file not found. Please check the file path.", "File Not Found");
                    return; // Exit the method if the file does not exist
                }

                // Read existing data from the file
                string fileContent = File.ReadAllText(filePath);

                // Check if inkjet data already exists in the file
                if (fileContent.Contains("location="))
                {
                    // Update existing inkjet data with the new value
                    string updatedContent = Regex.Replace(fileContent, @"location=.*?(?:\r\n|$)", $"location={locationValue}\r\n");
                    File.WriteAllText(filePath, updatedContent);
                }
                else
                {
                    // Append the inkjet data to the existing data with a comma
                    string newData = fileContent + $"location={locationValue}\r\n";
                    File.WriteAllText(filePath, newData);
                }

                //MessageBox.Show("Successfully added or updated location data in the file.", "Data Added/Updated");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error occurred while writing to the file: {e.Message}");
                MessageBox.Show("An error occurred while writing to the file. Please try again.", "Error");
            }
        }

        public static string ReadLocationData()
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Expiration file not found. Please check the file path.");
                    return null;
                }

                // Read all text from the file
                string fileContent = File.ReadAllText(filePath);

                // Find the latest inkjet data
                string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.StartsWith("location="))
                    {
                        return line.Substring("location=".Length);
                    }
                }

                // If inkjet data is not found
                Console.WriteLine("location data not found in the file.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public static void AddLocationPrefixData(string location_prefix)
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Expiration file not found. Please check the file path.", "File Not Found");
                    return; // Exit the method if the file does not exist
                }

                // Read existing data from the file
                string fileContent = File.ReadAllText(filePath);

                // Check if inkjet data already exists in the file
                if (fileContent.Contains("location_prefix="))
                {
                    // Update existing inkjet data with the new value
                    string updatedContent = Regex.Replace(fileContent, @"location_prefix=.*?(?:\r\n|$)", $"location_prefix={location_prefix}\r\n");
                    File.WriteAllText(filePath, updatedContent);
                }
                else
                {
                    // Append the inkjet data to the existing data with a comma
                    string newData = fileContent + $"location_prefix={location_prefix}\r\n";
                    File.WriteAllText(filePath, newData);
                }

                //MessageBox.Show("Successfully added or updated location data in the file.", "Data Added/Updated");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error occurred while writing to the file: {e.Message}");
                MessageBox.Show("An error occurred while writing to the file. Please try again.", "Error");
            }
        }

        public static string ReadLocationPrefixData()
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Expiration file not found. Please check the file path.");
                    return null;
                }

                // Read all text from the file
                string fileContent = File.ReadAllText(filePath);

                // Find the latest inkjet data
                string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.StartsWith("location_prefix="))
                    {
                        return line.Substring("location_prefix=".Length);
                    }
                }

                // If inkjet data is not found
                Console.WriteLine("location_prefix data not found in the file.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public static string ReadInkjetData()
        {
            try
            {
                // Get the path to the desktop directory
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Combine the path with the file path
                string filePath = Path.Combine(path, "ECC Software", "deksomboon", "data.txt");

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Expiration file not found. Please check the file path.");
                    return null;
                }

                // Read all text from the file
                string fileContent = File.ReadAllText(filePath);

                // Find the latest inkjet data
                string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.StartsWith("inkjet="))
                    {
                        return line.Substring("inkjet=".Length);
                    }
                }

                // If inkjet data is not found
                Console.WriteLine("Inkjet data not found in the file.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
    }
}
