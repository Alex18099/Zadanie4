using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Zadanie4
{
    public partial class Form1 : Form
    {
        Color color = Color.Black; //������� ���������� ���� Color ����������� �� ������ ����.
        bool isPressed = false; //���������� ���������� ������������ ��� ������������ ����� ����� �������� �� panel
        Point CurrentPoint; //������� ����� �������.
        Point PrevPoint; //��� ��������� ����� �������.
        Graphics g; //������� ����������� �������.
        ColorDialog colorDialog = new ColorDialog(); //���������� ���� ��� ������ �����
        public Form1()
        {
            
            InitializeComponent();
            label2.BackColor = Color.Black; //�� ��������� ��� ���� ����� ������ ����, ������� �� ������� ����� �� ��� ��� label2
            g = panel1.CreateGraphics(); //������� ������� ��� ������ � �������� �� �������� panel

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK) //���� ���� ��������� � OK, �� ������ ���� ��� ���� � ���� label2
            {
                color = colorDialog.Color; //������ ���� ��� ����
                label2.BackColor = colorDialog.Color; //������ ���� ��� ���� label2
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh(); //������� ������� Panel
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint= e.Location;
                my_Pen();
            }
        }
        private void my_Pen()
        {
            Pen pen = new Pen(color, (float)numericUpDown1.Value); //������� ����, ������ ��� ���� � �������.
            g.DrawLine(pen, CurrentPoint, PrevPoint); //���������� ����� �������
        }

        
    }
}