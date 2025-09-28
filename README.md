# BÀI TẬP 1 MÔN HỌC: LẬP TRÌNH WEB
# SINH VIÊN THỰC HIỆN: LƯƠNG HOÀNG VIỆT - MSSV: K225480106073
## BÀI TOÁN : DỰ ĐOÁN CẢM XÚC DỰA TRÊN INPUT CỦA USER
## TỔNG QUAN VỀ CÁC CÔNG CỤ ĐƯỢC DÙNG TRONG BÀI
### 1.DLL (Dynamic Link Library) là một thư viện chứa mã lệnh có thể được sử dụng lại bởi nhiều ứng dụng khác nhau. Trong bài này:
- DLL là trái tim xử lý của toàn bộ hệ thống.
- Nó không có giao diện, không nhập xuất trực tiếp.
- Nhận dữ liệu thông qua thuộc tính hoặc hàm, và trả kết quả cũng qua thuộc tính hoặc giá trị trả về.
- Được viết bằng Class Library (.NET Framework 2.0) để đảm bảo tương thích với các ứng dụng khác.
### 2.Console App là gì?
Console Application là ứng dụng chạy trong cửa sổ dòng lệnh (màn hình đen), không có giao diện đồ họa.
- Viết bằng C# Console (.NET Framework 2.0).
- Nhập dữ liệu từ bàn phím.
- Gọi DLL để xử lý.
- Hiển thị kết quả ra màn hình.
- Thường dùng để test nhanh hoặc chạy trên máy không cần giao diện.
### 3.Windows Form App là gì?
Windows Form Application là ứng dụng có giao diện đồ họa chạy trên Windows.
- Viết bằng C# Windows Form (.NET Framework 2.0).
- Giao diện gồm các control như TextBox, Button, Label...
- Người dùng nhập dữ liệu qua giao diện.
- Gọi DLL để xử lý.
- Hiển thị kết quả lên form.
### 4.Web App là gì?
Web Application là ứng dụng chạy trên trình duyệt, giao tiếp với server qua HTTP.
- Giao diện viết bằng HTML + CSS + JavaScript.
- Backend viết bằng ASP.NET Web Forms (.NET Framework 2.0).
- Chạy qua IIS (Internet Information Services) – máy chủ web của Windows.
- Dữ liệu được gửi từ client (trình duyệt) lên server qua JavaScript.
- Server nhận dữ liệu, gọi DLL để xử lý, trả kết quả dạng JSON.
- Client nhận JSON và cập nhật giao diện.

## 1. TẠO DLL VỚI CLASS LIBRARY <br>
### a) Viết code C# và build Solution <br>
<img width="1905" height="714" alt="image" src="https://github.com/user-attachments/assets/59a63d22-d94c-47be-b178-4a3f22519149" /> <br>
### b) DLL được tạo sau khi build <br>
<img width="1681" height="130" alt="image" src="https://github.com/user-attachments/assets/2ee85428-a957-430c-897b-c679cd0f9c16" /> <br>
## 2. Sử dụng Console App và biên dịch <br> 
### a) Link DLL vào Refenrences của ConsoleApp <br>
<img width="580" height="201" alt="image" src="https://github.com/user-attachments/assets/2c671b85-7542-443b-86a3-27a593cc0748" /> <br>
### b) Chạy file exe của ConsoleApp
<img width="1484" height="755" alt="image" src="https://github.com/user-attachments/assets/61d385b9-c2f5-479f-bfa6-190f20bf5506" /> <br>
## 3. Windows Form Application
### a) Link DLL vào Refenrences của WFA <br>
<img width="564" height="311" alt="image" src="https://github.com/user-attachments/assets/14fa8d56-1e80-4628-b13f-066468c37b76" />
### b) Kết quả chạy WFA
<img width="782" height="542" alt="image" src="https://github.com/user-attachments/assets/a51cfea6-dee2-471a-8b5c-3ee5621800e5" /> <BR>
## 4. Web Application <br>
### a) Link DLL vào Refenrences của WA <br>
<img width="580" height="358" alt="image" src="https://github.com/user-attachments/assets/6295ef85-f59f-4bad-8ee1-71096e635f02" /> <br>
### b) Viết code và tạo backend cần thiết <br>
<img width="558" height="432" alt="image" src="https://github.com/user-attachments/assets/13d680d5-66c2-4ee1-8919-f63bb887bb35" /> <br>
Giao diện cơ bản: <img width="1919" height="970" alt="image" src="https://github.com/user-attachments/assets/2de5453e-c4fa-47ca-baf6-91a3ad7ec465" /> <br>
### c) Cấu hình IIS và Application pool
Tại windows Features tick các tính năng như hình dưới: <br>
<img width="555" height="492" alt="image" src="https://github.com/user-attachments/assets/ecdd4bdb-4f96-4023-b297-e8b7c1f6342e" /> <br>
Sử dụng notepad với quyền admin để thêm host: <br>
<img width="1426" height="823" alt="image" src="https://github.com/user-attachments/assets/e3d0b291-c3bc-40bc-b8bb-def4727e6c86" /> <br>
Sau khi xong 2 bước trên, mở IIS Manager tạo site "Du doan cam xuc":
<img width="731" height="840" alt="image" src="https://github.com/user-attachments/assets/d5b5941a-5ce9-422c-ba82-566720fffe09" /> <br>
<img width="1422" height="815" alt="image" src="https://github.com/user-attachments/assets/5015abb4-2fd4-4e3f-8c1e-5fd7dd42aa7e" /><br>
Tiếp đó tại Application pool, mở basic setting của "Du doan cam xuc", chọn như hình dưới ( theo yêu cầu đề bài):<br>
<img width="377" height="349" alt="image" src="https://github.com/user-attachments/assets/61de785b-2f45-44e6-b0ba-aa82393791f1" /> <br>
Cuối cùng cấp quyền truy cập folder WebApp cho IISUSER để có thể truy cập vào web.
### d) Truy cập trang web:
Với đường dẫn đã tạo trước đó, truy cập vào: emotion.local để vào trang web. Khi user input bất kì hệ thống sẽ dự báo cảm xúc của user đó, kết quả được đưa ra ở hình dưới: <br>
<img width="609" height="457" alt="image" src="https://github.com/user-attachments/assets/7013daa3-903e-4238-9f76-6a7e6d3722d3" /> <br>
## NOTE: Toàn bộ Source code và Project được upload kèm theo trong Repository













