using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> list = new List<int>();

        public void Vypis(List<int> list, ListBox listbox)
        {
            listbox.Items.Clear();
            foreach (int cislo in list)
            {
                listbox.Items.Add(cislo);
            }
        }
        public int DruheMax(int druhemax)
        {
            int max = int.MinValue;
            druhemax = int.MinValue;
            foreach (int cislo in list)
            {
                if (cislo > druhemax)
                {
                    if (cislo > max)
                    {
                        max = cislo;
                    }
                    else
                    {
                        druhemax = cislo;
                    }
                }
            }
            return druhemax;
        }
        Random rng = new Random();

        private int CifernySoucet(int max)
        {
            max = int.MinValue;
            foreach (int cislo in list)
            {
                if (cislo > max)
                {
                    max = cislo;
                }
            }
            int soucet = 0;
            while (max > 1)
            {
                int zbytek = max % 10;
                soucet += zbytek;
                max /= 10;
            }
            return soucet;
        }
        public bool Dokonale(int cislo)
        {
            bool dokonale = false;
            int soucet = 0;
            List<int> pomocny = new List<int>();
            if (cislo != 0)
            {
                for (int i = 1; i < cislo; i++)
                {
                    if (cislo % i == 0)
                    {
                        pomocny.Add(i);
                    }
                }
                foreach (int i in pomocny)
                {
                    soucet += i;
                }
                if (soucet == cislo)
                {
                    dokonale = true;
                }
            }
            return dokonale;

        }

        public void Smazat(List<int> list)
        {
            try
            {
                foreach (int cislo in list)
                {
                    if (Dokonale(cislo) == true)
                    {
                        list.Remove(cislo);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chyba");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                list.Clear();
                int n = int.Parse(textBox1.Text);
                bool dokonale = false;
                int cislo = 0;
                for (int i = 0; i < n; i++)
                {
                    int randomak = rng.Next(-4, 101);
                    list.Add(randomak);
                }
                Vypis(list, listBox1);
            }
            catch
            {
                MessageBox.Show("Chyba");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Smazat(list);
            Vypis(list, listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list.Sort();
            Vypis(list, listBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int soucet = 0;
            int pocet = 0;
            foreach (int cislo in list)
            {
                soucet += cislo;
                pocet++;
            }
            label4.Text = "Průměr všech čísel v listu: " + (double)soucet / (double)pocet;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int druhemax = int.MinValue;
            label1.Text = DruheMax(druhemax).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int max = int.MinValue;
            label2.Text = CifernySoucet(max).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            List<char> list2 = new List<char>();
            foreach (int cislo in list)
            {
                if (cislo >= 65 && cislo <= 90)
                {
                    list2.Add((char)cislo);
                }
                else
                {
                    list2.Add('*');
                }
            }
            foreach (char znak in list2)
            {
                listBox4.Items.Add(znak);
            }
        }
    }
}
