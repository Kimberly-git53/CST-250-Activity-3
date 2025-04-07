using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Added for StreamReader
using System.Windows.Forms;
using System.Web; // Added for MessageBox

namespace VerseIndenting
{
    public class FileIO
    {
               
        // Method to read verses from a file
        public static List<Verse> LoadVersesFromFile(string filename)
        {
            // Create a list to hold the verses
            List<Verse> verses = new List<Verse>();
            // Specify the file name

            

            // Open the file and read the lines
            using (StreamReader reader = new StreamReader(filename))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into label and text
                    string[] parts = line.Split(new[] { '|' }, 2);
                    if (parts.Length == 2)
                    {
                        string label = parts[0].Trim();
                        string text = parts[1].Trim();
                        // Create a new Verse object and add it to the list
                        verses.Add(new Verse(label, text));
                    }
                    else
                    {
                        MessageBox.Show("Error parsing data for verse: " + line);
                    }
                }
            }
            // Display the verses in the flow layout panel
            return verses;
        }
    }

}
