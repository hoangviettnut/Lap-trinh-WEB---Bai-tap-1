using System;
using System.Web;
using System.Web.UI;
using System.Text;
using Luong.Emotion;

namespace WebApplication
{
    public partial class api : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Thiết lập CORS headers
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            
            // Thiết lập response type là JSON
            Response.ContentType = "application/json";
            Response.Charset = "utf-8";
            
            try
            {
                // Xử lý OPTIONS request cho CORS
                if (Request.HttpMethod == "OPTIONS")
                {
                    Response.StatusCode = 200;
                    Response.End();
                    return;
                }
                
                // Kiểm tra method POST
                if (Request.HttpMethod != "POST")
                {
                    SendErrorResponse("Chỉ hỗ trợ method POST");
                    return;
                }

                // Lấy dữ liệu từ form
                string inputText = Request.Form["inputText"];
                
                if (string.IsNullOrEmpty(inputText))
                {
                    SendErrorResponse("Vui lòng nhập văn bản cần phân tích");
                    return;
                }

                // Tạo instance của EmotionPredictor
                EmotionPredictor predictor = new EmotionPredictor();
                predictor.InputText = inputText;

                // Thực hiện dự đoán cảm xúc
                string emotion = predictor.PredictEmotion();
                string color = predictor.PredictColor();

                // Tạo response JSON
                StringBuilder jsonResponse = new StringBuilder();
                jsonResponse.Append("{");
                jsonResponse.Append("\"success\": true,");
                jsonResponse.Append("\"emotion\": \"" + EscapeJsonString(emotion) + "\",");
                jsonResponse.Append("\"color\": \"" + EscapeJsonString(color) + "\",");
                jsonResponse.Append("\"inputText\": \"" + EscapeJsonString(inputText) + "\",");
                jsonResponse.Append("\"timestamp\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"");
                jsonResponse.Append("}");

                // Gửi response
                Response.Write(jsonResponse.ToString());
            }
            catch (Exception ex)
            {
                // Log lỗi
                System.Diagnostics.Debug.WriteLine("Error in api.aspx.cs: " + ex.Message);
                
                // Gửi response lỗi
                SendErrorResponse("Có lỗi xảy ra khi xử lý yêu cầu: " + ex.Message);
            }
        }

        private void SendErrorResponse(string message)
        {
            StringBuilder jsonResponse = new StringBuilder();
            jsonResponse.Append("{");
            jsonResponse.Append("\"success\": false,");
            jsonResponse.Append("\"message\": \"" + EscapeJsonString(message) + "\",");
            jsonResponse.Append("\"timestamp\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"");
            jsonResponse.Append("}");

            Response.Write(jsonResponse.ToString());
        }

        private string EscapeJsonString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            return input.Replace("\\", "\\\\")
                       .Replace("\"", "\\\"")
                       .Replace("\n", "\\n")
                       .Replace("\r", "\\r")
                       .Replace("\t", "\\t");
        }
    }
}
