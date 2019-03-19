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
    public partial class Form1 : Form
    {
        public List<Person> Persons  = new List<Person>()
        {
            new Person {Id = 1, Name = "Sait", Surname = "Orhan", BirthDay = new DateTime(1989, 11,09)},
            new Person() {Id = 2, Name = "Said Nur", Surname = "Yağmahan", BirthDay = new DateTime(1989, 1,1)}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataSourcePeople.DataSource = Persons;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Person person = dataSourcePeople.Current as Person;

            if (person == null)
            {
                return;
            }

            PersonInfo personInfo = new PersonInfo(person);
            personInfo.ShowDialog();

            
                person.Name = personInfo.Person.Name;
                person.Surname = personInfo.Person.Surname;
                person.BirthDay = personInfo.Person.BirthDay;
            
            dataSourcePeople.DataSource = null;
            dataSourcePeople.DataSource = Persons;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            PersonInfo personInfo = new PersonInfo();
            personInfo.ShowDialog();

                personInfo.Person.Id = Persons.Max(p => p.Id) + 1;
                Persons.Add(personInfo.Person);
            dataSourcePeople.DataSource = null;
            dataSourcePeople.DataSource = Persons;
        }
    }
}
