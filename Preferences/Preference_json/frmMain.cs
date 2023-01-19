using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Preference_json;
using static System.Windows.Forms.AxHost;

namespace Preference_json
{
    public partial class frmMain : Form
    {
        DataBase<Preferences> bd = new DataBase<Preferences>($"C:\\Users\\{(WindowsIdentity.GetCurrent().Name).Remove(0, 4)}\\AppData\\Roaming\\BAS-Reporter\\bd.json");
        int Id = 0;
        public string formularioName;
        public string propName;
        public string propValue;
        Preferences p; 


        private int countPreferences(List<Preferences> list) 
        {
            return list.Count;
        }

        void showPreferences(List<Preferences> list)
        {            
            foreach (Preferences p in list)
            {
                if (p.reportName == "TransReporter") 
                {
                    this.Text = p.reportName;
                    if (p.propertieName == "textBox1") 
                    {
                        textBox1.Text = p.propertieValue;
                    }
                    if (p.propertieName=="WindowState")
                    {
                        this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), p.propertieValue.ToString());
                    }
                }
                

                //this.textBox1.Text = p.Input.ToString();
                /*this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), p.State.ToString());
                if(p.BtnRadio == 1)
                {
                    radioButton1.Checked = true;
                }
                if(p.BtnRadio > 1)
                {
                    radioButton2.Checked = true;
                }*/
            }
        }

        public frmMain()
        {
            InitializeComponent();
             this.Text = $"{this.Text} - USER: {(WindowsIdentity.GetCurrent().Name).Remove(0, 4)}";
            bd.Load();
            showPreferences(bd.values);
        }

        private void frnMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*int DNI = 3613;
            var s = this.WindowState;
            int r = 1;
            
            if (radioButton1.Checked == true)
            {
                r = 1;
            }
            if (radioButton2.Checked == true)
            {
                r = 2;
            }*/
            

            if (this.textBox1.Text != "") 
            {
                Id= countPreferences(bd.values) + 1;
                this.formularioName = "TransReporter";
                this.propName = "textBox1";
                this.propValue = textBox1.Text;
                p = new Preferences(Id, this.formularioName, this.propName, this.propValue);
                
                bd.Insert(p);
                //showPreferences(bd.values);
            }

            Id = countPreferences(bd.values) + 1;
            formularioName = "TransReporter";
            string propName = "WindowState";
            string propValue = this.WindowState.ToString();
            MessageBox.Show(propValue);
            //Preferences p = new Preferences(DNI, textBox1.Text, s.ToString(), r);
            p = new Preferences(Id, formularioName, propName, propValue);
            //if (!File.Exists(bd.route))
            //{
                bd.Insert(p);
                //showPreferences(bd.values);
            //}
            //bd.Update(X => X.Id == ID, p);
            //showPreferences(bd.values);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
