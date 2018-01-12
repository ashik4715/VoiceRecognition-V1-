using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace VoiceRecognition_V1_
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speechsynth = new SpeechSynthesizer();
        SpeechRecognitionEngine receng = new SpeechRecognitionEngine();
        Choices choice = new Choices();

        public Form1()
        {
            InitializeComponent();
        }

        void receng_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "hello":
                    list1.Items.Add("User: " + "hello");
                    speechsynth.SpeakAsync("hello user");                  
                    list1.Items.Add("System bot: "+"hello user");
                    break;
                case "hi there":
                    list1.Items.Add("User: " + "hi there");
                    speechsynth.SpeakAsync("hi user");
                    list1.Items.Add("System bot:" + "hi user");
                    break;
                case "how are you":
                    list1.Items.Add("User: " + "how are you");
                    speechsynth.SpeakAsync("i am fine. what about you");
                    list1.Items.Add("System bot:" + "i am fine. what about you");
                    break;
                case "what is the current time":
                    list1.Items.Add("User: " + "what is the current time");
                    speechsynth.SpeakAsync("right now it is " + DateTime.Now.ToLongTimeString());
                    list1.Items.Add("System bot: " + "right now it is " + DateTime.Now.ToLongTimeString());
                    break;
                case "thank you":
                    list1.Items.Add("User: " + "thank you");
                    speechsynth.SpeakAsync("well. same to you");
                    list1.Items.Add("System bot: " + "well. same to you");
                    break;
                case "open blog":
                    list1.Items.Add("User: " + "open blog");
                    Process.Start("chrome", "http://homotrick.blogspot.in");
                    break;
                case "find my medicine":
                    list1.Items.Add("User: " + "find my medicine");
                    speechsynth.SpeakAsync("i found your medicine");
                    list1.Items.Add("System bot: " + "i found your medicine");
                    break;
                case "find medicine":
                    list1.Items.Add("User: " + "find medicine");
                    speechsynth.SpeakAsync("medicine found");
                    list1.Items.Add("System bot: " + "medicine found");
                    break;
                case "find Naproxen":
                    list1.Items.Add("User: " + "find Naproxen");
                    speechsynth.SpeakAsync("medicine Naproxen found");
                    list1.Items.Add("System bot: " + "medicine Naproxen found");
                    break;
                case "search medicine":
                    list1.Items.Add("User: " + "search medicine");
                    speechsynth.SpeakAsync("your medicine found");
                    list1.Items.Add("System bot: " + "your medicine found");
                    break;
                case "find again":
                    list1.Items.Add("User: " + "find again");
                    speechsynth.SpeakAsync("sweaping the area for your medicine");
                    list1.Items.Add("System bot: " + "sweaping the area for your medicine");
                    break;
                case "search again":
                    list1.Items.Add("User: " + "search again");
                    speechsynth.SpeakAsync("looking for your medicine");
                    list1.Items.Add("System bot: " + "looking for your medicine");
                    break;
                case "close":
                    list1.Items.Add("User: " + "close");
                    list1.Items.Add("System bot: " + "Glad to assist you. bye bye");
                    speechsynth.Speak("Glad to assist you. bye bye");              
                    Application.Exit();
                    break;

            }
            //list1.Items.Add(e.Result.Text.ToString());
        }

        private void startbtn_Click_1(object sender, EventArgs e)
        {
            startbtn.Enabled = false;
            stopbtn.Enabled = true;
            choice.Add(new string[] { "hi there","hello", "how are you", "what is the current time", "open blog", "thank you",
                "close","find my medicine","search medicine", "find Naproxen" , "find medicine","search again","find again" });
            Grammar gr = new Grammar(new GrammarBuilder(choice));
            try
            {
                receng.RequestRecognizerUpdate();
                receng.LoadGrammar(gr);
                receng.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(receng_SpeechRecognized);
                receng.SetInputToDefaultAudioDevice();
                receng.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void stopbtn_Click_1(object sender, EventArgs e)
        {
            receng.RecognizeAsyncStop();
            startbtn.Enabled = true;
            stopbtn.Enabled = false;
        }
    }
}
