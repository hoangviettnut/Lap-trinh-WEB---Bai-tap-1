using System;

namespace Luong.Emotion
{
    public class EmotionPredictor
    {
        public string InputText { get; set; }
        public string EmotionResult { get; private set; }

        public string PredictEmotion()
        {
            if (string.IsNullOrEmpty(InputText))
            {
                EmotionResult = "Khong xac dinh";
                return EmotionResult;
            }

            string text = InputText.ToLower();

            // Vui vẻ
            if (text.Contains(":)))") || text.Contains(":d") || text.Contains("happy") || text.Contains("tuyet") || text.Contains("great") || text.Contains("vui") || text.Contains("haha") || text.Contains("hạnh phúc") || text.Contains("cười") || text.Contains("thích") || text.Contains("love") || text.Contains("yêu") || text.Contains("ok") || text.Contains("good") || text.Contains("excellent") || text.Contains("awesome"))
                EmotionResult = "Vui ve";
            // Buồn bã
            else if (text.Contains(":((") || text.Contains(":'(") || text.Contains("sad") || text.Contains("chan") || text.Contains("te") || text.Contains("buồn") || text.Contains("khóc") || text.Contains("tệ") || text.Contains("fail") || text.Contains("disappointed") || text.Contains("thất vọng") || text.Contains("chán") || text.Contains("bad"))
                EmotionResult = "Buon ba";
            // Giận dữ
            else if (text.Contains(":)") || text.Contains(":@") || text.Contains("angry") || text.Contains("uc") || text.Contains("buc") || text.Contains("giận") || text.Contains("bực") || text.Contains("tức") || text.Contains("cay") || text.Contains("điên") || text.Contains("mad") || text.Contains("rage") || text.Contains("furious"))
                EmotionResult = "Gian du";
            // Lo lắng/sợ hãi
            else if (text.Contains(":(") || text.Contains(":o") || text.Contains("so") || text.Contains("run") || text.Contains("worried") || text.Contains("lo") || text.Contains("lo lắng") || text.Contains("sợ") || text.Contains("hoảng") || text.Contains("fear") || text.Contains("scared") || text.Contains("anxious") || text.Contains("stress"))
                EmotionResult = "Lo lang";
            else
                EmotionResult = "Khong xac dinh";

            return EmotionResult;
        }

        public string PredictColor()
        {
            if (string.IsNullOrEmpty(EmotionResult)) PredictEmotion();
            if (EmotionResult.Contains("Vui")) return "Yellow";
            if (EmotionResult.Contains("Buon")) return "Blue";
            if (EmotionResult.Contains("Gian")) return "Red";
            if (EmotionResult.Contains("Lo")) return "Gray";
            return "White";
        }
    }
}