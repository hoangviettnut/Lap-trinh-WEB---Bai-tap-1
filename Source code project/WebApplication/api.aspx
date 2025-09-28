<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="Luong.Emotion" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";
        string inputText = Request["text"];
        var predictor = new EmotionPredictor();
        predictor.InputText = inputText;
        string emotion = predictor.PredictEmotion();
        string color = predictor.PredictColor();
        // T?o JSON th? công
        string json = "{\"emotion\":\"" + emotion.Replace("\"", "\\\"") + "\",\"color\":\"" + color.Replace("\"", "\\\"") + "\"}";
        Response.Write(json);
        Response.End();
    }
</script>
