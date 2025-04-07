namespace VerseIndenting
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;


    public partial class FormVerses : Form
    {
        List<Verse> verses = new List<Verse>();

        public FormVerses()
        {
            InitializeComponent();

            // Hardcoded verse data
            verses = new List<Verse>
            {
                new Verse("A", "God said, 'This is the sign of the covenant which I am " +
                "making between Me and you and every living creature that is with you, " +
                "for all future generations (v.12)'"),
                new Verse("B", "I have set My rainbow in the cloud, and it shall serve " +
                "as a sign of a covenant between ME and the earth (v.13)"),
                new Verse("C", "It shall come about, when I make a cloud appear over " +
                "the earth, that the rainbow will be seen in the cloud (v.14)"),
                new Verse("D", "And I will remember My covenant, which is between Me " +
                "and you and every living creature of all flesh; and never again shall " +
                "the water become a flood to destroy all flesh (v.15)"),
                new Verse("C'", "When the rainbow is in the cloud, then I will look at " +
                "it (v.16)"),
                new Verse("B'", "to remember the everlasting covenant between God and " +
                "every living creature of all flesh that is on the earth"),
                new Verse("A'", "God said to Noah, 'TThis is the sign of the covenant " +
                "which I have established between Me and all flesh that is on the earth'")
            };

            DisplayVersesRecursively(0, verses.Count - 1, 0);

        }
        //Recursive function to display verses in a chiasm
        private void DisplayVersesRecursively(int start, int end, int level)
        {
            // Start is the index of the first verse in the chiasm, end is the index of the
            // last verse in the chiasm. Level is the current level of recursion used to
            // calculate padding.

            // Base case: if start is greater than end index, return or "break" out of the 
            // recursion

            if (start > end)
            {
                return;
            }
            // Calculate the padding based on the current level of recursion level
            int padding = level * 20;

            // Display the first part of the chiasm
            AddVerseToPanel(verses[start], padding, level);

            // Recurse into the next level if not at the middle yet
            if (start != end)
            {
                // Call the next "step" of the recursion
                DisplayVersesRecursively(start + 1, end - 1, level + 1);

                // Unwind the recursion by displaying the second part of the chiasm.
                AddVerseToPanel(verses[end], padding, level);
            }
        }
        // create a label for each verse and add it to the panel with the appropriate padding
        private void AddVerseToPanel(Verse verse, int padding, int level)
        {
            // Define each color for the levels
            Color[] colors = new Color[]
                {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.PaleVioletRed,
                Color.Green,
                Color.Blue,
                Color.Red
            };

            // Use the modulus operator to cycle through the colors
            Color verseColor = colors[level % colors.Length];

            Label label = new Label
            {
                Text = $"{verse.Label}: {verse.Text}",
                Padding = new Padding(padding, 0, 0, 0),
                ForeColor = verseColor,
                AutoSize = true
            };
            // padding is used to indent the labels based on the recursion level.
            // the flowLayout panel automatically arranges the labels in a flow layout.
            // Be sure to change the panel's AutoScroll property to true if you have many verses.
            // change the orientation of the flow layout panel to vertical so that the verses are
            // displayed from top to bottom.
            flowLayoutPanel1.Controls.Add(label);

        }
        public void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open a Verse File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the verses from the selected file
                List<Verse> loadedVerses = FileIO.LoadVersesFromFile(openFileDialog.FileName);

                //Check if verses loaded
                if (loadedVerses != null && loadedVerses.Count > 0)
                {

                    // Clear the existing verses
                    flowLayoutPanel1.Controls.Clear();
                    // Display the loaded verses
                    verses = loadedVerses;
                    DisplayVersesRecursively(0, verses.Count - 1, 0);
                }
                else
                {
                    MessageBox.Show("No verses found in the file.");
                }
                

            }
        }

    }
}
