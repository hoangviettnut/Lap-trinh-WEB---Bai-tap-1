using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Luong.Emotion;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            var predictor = new EmotionPredictor();
            predictor.InputText = txtInput.Text;
            string emotion = predictor.PredictEmotion();
            string color = predictor.PredictColor();
            lblResult.Text = $"Cam xuc du doan: {emotion}\nMau tuong ung: {color}";
        }
    }
}
