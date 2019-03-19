using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitim.FormlarArasiBilgi
{
    public partial class PersonInfo : Form
    {
        public Person Person { get; set; }

        public PersonInfo()
        {
            InitializeComponent();
            Person = new Person();
        }
        public PersonInfo(Person person)
        {
            Person = person;
            InitializeComponent();

            textBoxName.Text = Person.Name;
            textBoxSurname.Text = Person.Surname;
            dateTimePickerBirthdate.Value = Person.BirthDay;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Person.Name = textBoxName.Text;
            Person.Surname = textBoxSurname.Text;
            Person.BirthDay = dateTimePickerBirthdate.Value;
        }
    }
}
