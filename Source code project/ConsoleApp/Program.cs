using System;
using Luong.Emotion;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EmotionPredictor predictor = new EmotionPredictor();

            Console.WriteLine("Nhap van ban de du doan cam xuc:");
            string input = Console.ReadLine();

            predictor.InputText = input;

            string emotion = predictor.PredictEmotion();
            string color = predictor.PredictColor();

            Console.WriteLine("\n🎯 Ket qua:");
            Console.WriteLine($"Cam xuc du doan: {emotion}");
            Console.WriteLine($"Mau tuong ung: {color}");

            Console.WriteLine("\nPress any keys to exit...");
            Console.ReadKey();
        }
    }
}
