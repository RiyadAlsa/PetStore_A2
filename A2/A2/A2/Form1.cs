using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2
{
    public partial class Form1 : Form
    {
        LinkedList<PetData> PetLinkedList = new LinkedList<PetData>();

        int PetNumber = 1;

        public Form1()
        {
            InitializeComponent();

            label6.Visible = false;
            DisplayBox.Visible = false;

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            PetData Pet = new PetData()
            {
                Name = NameBox.Text,
                Age = int.Parse(AgeBox.Text),
                Weight = int.Parse(WeightBox.Text),
                Height = int.Parse(HeightBox.Text)
            };

            PetLinkedList.AddFirst(Pet);
            Reset();

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            DisplayBox.Visible = true;

            if (AgeRadio.Checked)
            {
                var sortedAge = PetLinkedList.OrderBy(Pet => Pet.Age).ThenBy(Pet => Pet.Weight).ThenBy(Pet => Pet.Height).ToList();

                foreach (PetData Pets in sortedAge)
                {
                    DisplayBox.AppendText($"Name: {Pets.Name}, Age: {Pets.Age}, Weight: {Pets.Weight}, Height: {Pets.Height}");
                    DisplayBox.AppendText(Environment.NewLine);
                    Thread.Sleep(1000);
                }
                DisplayBox.AppendText(Environment.NewLine);
                Thread.Sleep(10000);
            }
            else if (WeightRadio.Checked)
            {
                var sortedWeight = PetLinkedList.OrderBy(Pet => Pet.Weight).ThenBy(Pet => Pet.Age).ThenBy(Pet => Pet.Height).ToList();

                foreach (PetData Pets in sortedWeight)
                {
                    DisplayBox.AppendText($"Name: {Pets.Name}, Age: {Pets.Age}, Weight: {Pets.Weight}, Height: {Pets.Height}");
                    DisplayBox.AppendText(Environment.NewLine);
                    Thread.Sleep(1000);
                }
                DisplayBox.AppendText(Environment.NewLine);
                Thread.Sleep(10000);
            }
        }

        private void Reset()
        {
            PetNumber++;

            NameBox.Clear();
            AgeBox.Clear();
            WeightBox.Clear();
            HeightBox.Clear();

            label1.Text = $"Name {PetNumber}:";
            label2.Text = $"Age {PetNumber}:";
            label3.Text = $"Weight {PetNumber}:";
            label4.Text = $"Height {PetNumber}:";
        }
    }

    class PetData
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public int Weight { set; get; }
        public int Height { set; get; }
    }
}