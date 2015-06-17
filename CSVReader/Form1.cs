//Данный файл проекта скачан с сайта http://melfis.ru/. 
//Прошу при использовании материалов с моего сайта делать активную гиперссылку на мой блог http://melfis.ru 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Класс для получения данных из CVS файла
        public class Cargo
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string List_price { get; set; }
            public string MyPrice { get; set; }


            //Метод для получения частей из строки
            public void piece(string line)
            {
                string[] parts = line.Split(',');  //Разделитель в CVS файле.
                ID = parts[0];
                Name = parts[1];
                List_price = parts[2];
                MyPrice = parts[3];
            }



            public static List<Cargo> ReadFile(string filename)
            {
                List<Cargo> res = new List<Cargo>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Cargo p = new Cargo();
                        p.piece(line);
                        res.Add(p);
                    }
                }

                return res;
            }
        }

        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Cargo> CSV_Struct = new List<Cargo>();
            CSV_Struct = Cargo.ReadFile("C://1.csv");

            for (int i = 0; i <= CSV_Struct.Count-1; i++)
            {
                listView1.Items.Add(CSV_Struct[i].ID);
                listView1.Items[i].SubItems.Add(CSV_Struct[i].Name);
                listView1.Items[i].SubItems.Add(CSV_Struct[i].List_price);
                listView1.Items[i].SubItems.Add(CSV_Struct[i].MyPrice);
            }
        }
    }
}
