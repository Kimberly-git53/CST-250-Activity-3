using System;
// Data class to hold the label and text of a verse
public class Verse
{
    public string Label { get; set; }
    public string Text { get; set; }

    public Verse(string label, string text)
	{
        Label = label;
        Text = text;
    }
}
