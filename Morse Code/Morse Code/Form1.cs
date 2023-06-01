using System.Transactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;



namespace Morse_Code
{
    public partial class Form1 : Form
    {
        private SoundPlayer _soundplayer;
        private SoundPlayer _soundplayer1;
        public Form1()
        {
            InitializeComponent();
            _soundplayer = new SoundPlayer("line.wav");
            _soundplayer1 = new SoundPlayer("dot.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // initialize a dictionary MorseDict which maps characters to their respective Morse code representations
            Dictionary<char, string> MorseDict = new Dictionary<char, string>(){
            {'a',".-"},{'b',"-..."},{'c',"-.-."},{'d',"-.."},{'e',"."},{'f',"..-."},
            {'g',"--."},{'h',"...."},{'i',".."},{'j',".---"},{'k',"-.-"},{'l',".-.."},
            {'m',"--"},{'n',"-."},{'o',"---"},{'p',".--."},{'q',"--.-"},{'r',".-."},
            {'s',"..."},{'t',"-"},{'u',"..-"},{'v',"...-"},{'w',".--"},{'x',"-..-"},
            {'y',"-.--"},{'z',"--.."},{' ',"/"},{'1',".----"},{'2',"..---"},{'3',"...--"},
            {'4',"....-"},{'5',"....."},{'6',"-...."},{'7',"--..."},{'8',"---.."},{'9',"----."},
            {'0',"-----"},{'.',".-.-.-"},{',',"--..--"},{'?',"..--.."},{'/',"-..-."},
            {'-',"-....-"},{'(',"-.--."},{')',"-.--.-"},{'!',"-.-.--"},{':',"---..."},
            {';',"-.-.-."},{'=',"-...-"},{'+',".-.-."},{'_',"..--.-"},{'"',".-..-."},
            {'@',".--.-."},{'\'',".----."}
            };
            string phrase = textBox1.Text;
            String translated = "";

            //try block to handle any potential exceptions that may occur during the translation process
            try
            {

                // iterates over each character (i) in the input phrase
                foreach (char i in phrase)
                {
                    //If the character is an uppercase letter,it converts it to lowercase and retrieves the corresponding Morse code from MorseDict
                    if (i >= 65 && i <= 90)
                    {
                        translated += MorseDict[char.ToLower(i)] + " ";
                    }
                    //If the character is not an uppercase letter, it directly retrieves the Morse code from MorseDict and appends it to translated, followed by a space
                    else
                    {
                        translated += MorseDict[i] + " ";
                    }
                }
                textBox2.Text = translated;
            }

            //error message
            catch (Exception error)
            {
                textBox2.Text = "One of the characters you used does not have a morse code translation.";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text; // Get the text from the TextBox control

            // Display a SaveFileDialog to select the file path
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt"; // Set the file filter
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName; // Get the selected file path

                    // Save the text to the file
                    System.IO.File.WriteAllText(filePath, text);
                    MessageBox.Show("Text saved successfully!");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {



            Dictionary<char, string> MorseDict = new Dictionary<char, string>(){
            {'a',".-"},{'b',"-..."},{'c',"-.-."},{'d',"-.."},{'e',"."},{'f',"..-."},
            {'g',"--."},{'h',"...."},{'i',".."},{'j',".---"},{'k',"-.-"},{'l',".-.."},
            {'m',"--"},{'n',"-."},{'o',"---"},{'p',".--."},{'q',"--.-"},{'r',".-."},
            {'s',"..."},{'t',"-"},{'u',"..-"},{'v',"...-"},{'w',".--"},{'x',"-..-"},
            {'y',"-.--"},{'z',"--.."},{' ',"/"},{'1',".----"},{'2',"..---"},{'3',"...--"},
            {'4',"....-"},{'5',"....."},{'6',"-...."},{'7',"--..."},{'8',"---.."},{'9',"----."},
            {'0',"-----"},{'.',".-.-.-"},{',',"--..--"},{'?',"..--.."},{'/',"-..-."},
            {'-',"-....-"},{'(',"-.--."},{')',"-.--.-"},{'!',"-.-.--"},{':',"---..."},
            {';',"-.-.-."},{'=',"-...-"},{'+',".-.-."},{'_',"..--.-"},{'"',".-..-."},
            {'@',".--.-."},{'\'',".----."}
            };

            string phrase = textBox1.Text;
            string translated = "";

            try
            {
                foreach (char i in phrase)
                {
                    if (i >= 65 && i <= 90)
                    {
                        translated += MorseDict[char.ToLower(i)] + " ";
                    }
                    else
                    {
                        translated += MorseDict[i] + " ";
                    }
                }

                textBox2.Text = translated;

                foreach (char c in phrase)
                {
                    if (MorseDict.ContainsKey(char.ToLower(c)))
                    {
                        string morseCode = MorseDict[char.ToLower(c)];
                        foreach (char mc in morseCode)
                        {
                            if (mc == '-')
                            {
                                _soundplayer.Play();
                            }
                            else if (mc == '.')
                            {
                                _soundplayer1.Play();
                            }

                            Thread.Sleep(500); // Delay 
                        }

                        Thread.Sleep(500); // Delay 
                    }
                    else if (c == ' ')
                    {
                        Thread.Sleep(500); // Delay
                    }
                }
            }
            catch (Exception error)
            {
                textBox2.Text = "One of the characters you used does not have a Morse code translation.";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

