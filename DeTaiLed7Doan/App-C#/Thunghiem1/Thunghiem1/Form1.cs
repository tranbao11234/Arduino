using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Thunghiem1
{
    public partial class Form1 : Form
    {
        int i = 1; // giá trị i = 1 mặc định là đo độ C khi mở ứng dụng

        string pathdof = @"C:\\xampp\htdocs\read\readf.txt"; // chuỗi đường dẫn đến file text đọc độ F
        string pathdoc = @"C:\\xampp\htdocs\read\readc.txt"; // chuỗi đường dẫn đến file text đọc độ C

        string rtime = @"C:\\xampp\htdocs\read\readtime.txt"; // chuỗi đường dẫn đến file text đọc dữ liệu nhận được box bên phải (terminal)

        float dok = 0; 
        float tinhdok = 0;
        public Form1()
        {
            InitializeComponent();
        }

        #region
        private void Form1_Load(object sender, EventArgs e)
        {
            cbxTenCong.DataSource = SerialPort.GetPortNames(); // lấy danh sách cổng COM hợp lệ và đưa vào combobox để chọn
            if(cbxTenCong.Items.Count >0)
            {
                cbxTenCong.SelectedIndex = 0;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        private void UART_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // hàm được thực hiện khi Serial hay UART nhận được dữ liệu từ Arduino
            BeginInvoke((Action)delegate // uỷ quyền và thực hiện nhận dữ liệu
            {
                txtNhan.Text += UART.ReadExisting(); // đưa dữ liệu vào box bên phải
                File.WriteAllText(rtime, txtNhan.Text); // đưa toàn bộ dữ liệu box bên phải vào file text
            });
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UART.PortName = cbxTenCong.Text; // lấy tên cổng COM từ Combobox đã chọn

            UART.Open(); // mở Serialport
            if(UART.IsOpen) // kiểm tra Serial mở thì trả về thông báo
            {
                MessageBox.Show("Kết nối thành công");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            UART.Close();
            if (!UART.IsOpen)
            {
                MessageBox.Show("Đã ngắt kết nối");
            }
            /**
            txtNhan.Text += "--Đã dừng--";
            string lastLine = txtNhan.Lines[txtNhan.Lines.Length - 2];
            label2.Text = lastLine.ToString() + "°C";
            dok = float.Parse(lastLine);
            tinhdok = dok * 9 / 5 + 32;
            label3.Text = tinhdok.ToString() + "°F";
             */
        }

        private void txtNhan_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            if (i == 2) // đang hiển thị độ F
            {
                label3.Text = UART.ReadLine().ToString(); // đọc dữ liệu từ UART (dòng hiện tại)
                chuyenf.Text = "Đang hiển thị độ C"; // chuyển đổi nội dung button
                File.WriteAllText(pathdof, label3.Text); // lưu tới file text độ F
                UART.Write("1"); // đưa dữ liêu (1) về arduino chuyển về độ C
                i = 1;
            }
            else if(i == 1)  // đang hiển thị độ C
            {
                label2.Text = UART.ReadLine().ToString(); // đọc dữ liệu từ UART (dòng hiện tại)
                chuyenf.Text = "Đang hiển thị độ F"; // chuyển đổi nội dung button
                File.WriteAllText(pathdoc, label2.Text); // lưu tới file text độ C
                UART.Write("2"); // đưa dữ liêu (2) về arduino chuyển về độ F
                i = 2;
            }
            
        }

        private void openled_Click(object sender, EventArgs e)
        {
            if (UART.IsOpen) // kiểm tra có đang kết nối cổng COM chưa
            {
                UART.Write("1"); 
                // dữ liệu đưa vào là 1 và được arduino kiểm tra để bật led lên là đo độ C
            }
            else
            {
                MessageBox.Show("Chưa kết nối với Arduino sao mà mở được");
            }
        }

        private void clean_Click(object sender, EventArgs e)
        {
            txtNhan.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (i == 2) // đang hiển thị độ F
            {
                label3.Text = UART.ReadLine().ToString(); // đọc dữ liệu từ UART (dòng hiện tại)
                File.WriteAllText(pathdof, label3.Text); // lưu tới file text độ F
            }
            else if (i == 1)  // đang hiển thị độ C
            {
                label2.Text = UART.ReadLine().ToString(); // đọc dữ liệu từ UART (dòng hiện tại)
                File.WriteAllText(pathdoc, label2.Text); // lưu tới file text độ C
            }
        }
    }
}
