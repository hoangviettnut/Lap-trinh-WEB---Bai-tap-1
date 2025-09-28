<%@ WebHandler Language="C#" Class="EmotionHandler" %>

using System;
using System.Web;
using Luong.Emotion;

public class EmotionHandler : IHttpHandler {
    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "application/json";
        string inputText = context.Request["text"];
        var predictor = new EmotionPredictor();
        predictor.InputText = inputText;
        string emotion = predictor.PredictEmotion();
        string color = predictor.PredictColor();
        // Tr? v? JSON th? công
        string json = "{\"emotion\":\"" + emotion.Replace("\"", "\\\"") + "\",\"color\":\"" + color.Replace("\"", "\\\"") + "\"}";
        context.Response.Write(json);
    }

    public bool IsReusable {
        get { return false; }
    }
}
