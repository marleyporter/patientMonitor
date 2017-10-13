using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Media;
using System.IO;

namespace PatientMonitor
{
    public partial class Main : Form
    {
        //SqlConnection connection;
        // String connectionString;
        public Main()
        {
            InitializeComponent();
            LoadLogsTable();
            // connectionString = ConfigurationManager.ConnectionStrings["PatientMonitor.Properties.Settings.PatientDTBConnectionString"].ConnectionString;
        }
        private void LoadTable()
        {                 ///Dataset for the oncall Staff table.
                          ///Get dataset from DB using oncall query
            DataSet dsstaff = PatientDataB.getDBConnectionInstance().getDataSetOC1(invariable.sqlQuerySelectStaffAll);

            //get the table from the dataset
            DataTable StaffOC = dsstaff.Tables[0];

        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReloadStaffTables();
        }

        private void LoadLogsTable()
        {
            DataSet lds = PatientDataB.getDBConnectionInstance().getDataSet(invariable.sqlQuerySelectLogsAll);
            DataTable LogsList = lds.Tables[0];

            this.dgvLogs.DataSource = LogsList;
            this.dgvLogsT.DataSource = LogsList;
        }
        private void ReloadStaffTables()
        {
            // Dataset for main Bedlist on overview tab
            //fill in the grid 
            DataSet ds = PatientDataB.getDBConnectionInstance().getDataSet(invariable.sqlQuerySelectAll);

            //get the table from the dataset
            DataTable BedList = ds.Tables[0];

            //set up the data grid view
            this.dgvBeds.DataSource = BedList;

            {
                ///Dataset for the oncall Staff table.
                ///Get dataset from DB using oncall query
                DataSet dsstaff = PatientDataB.getDBConnectionInstance().getDataSet(invariable.sqlQuerySelectStaffOnCall);

                //get the table from the dataset
                DataTable StaffOC = dsstaff.Tables[0];

                //display the data in both overview and on call tabs
                this.dgvStaffOC.DataSource = StaffOC;
                this.dgvStaffOCT.DataSource = StaffOC;
            }

            {
                ///Dataset for the not on call staff table
                /// get dataset from DB using oncall query
                DataSet dsstaffNOC = PatientDataB.getDBConnectionInstance().getDataSet(invariable.sqlQuerySelectStaffNotOnCall);
                //get the table from the dataset
                DataTable StaffNOC = dsstaffNOC.Tables[0];

                //display the data in both overview and on call tabs
                this.dgvStaffNOC.DataSource = StaffNOC;
                this.dgvStaffNOCT.DataSource = StaffNOC;
            }
        }







        //when file --> exit is selected the program exits
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
        }
        //when file --> logout is selected the program restarts
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
        private void PatientData()
        {
            //using (connection = new SqlConnection(connectionString))
            // using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM BedList", connection))
            {
                //DataTable BedListTable = new DataTable();
                //adapter.Fill(BedListTable);
                //  connection.Open();
            }

            //  connection.Close();
        }

        private void BedList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void tabPage1_Click(object sender, EventArgs e)
        //{
        // PatientData();
        //}

        // Class Constructor
        NumberGen NumberG = new NumberGen();

        public void Numbers()
        {
            //infinite loop
            do
            {
                //assigns random number from
                int heart1 = NumberG.Heart1();
                lblPatientHeart.Invoke((MethodInvoker)(() => lblPatientHeart.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart.Invoke((MethodInvoker)(() => lblPatientHeart.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart.Value || heart1 > maxHeart.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 1!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing.Invoke((MethodInvoker)(() => lblPatientBreathing.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing.Invoke((MethodInvoker)(() => lblPatientBreathing.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing.Value || breath1 > maxBreathing.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 1!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic.Invoke((MethodInvoker)(() => lblPatientSystolic.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic.Invoke((MethodInvoker)(() => lblPatientSystolic.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic.Value || systolic1 > maxSystolic.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 1!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic.Invoke((MethodInvoker)(() => lblPatientDiastolic.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic.Invoke((MethodInvoker)(() => lblPatientDiastolic.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic.Value || diastolic1 > maxDiastolic.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 1!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp.Invoke((MethodInvoker)(() => lblPatientTemp.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp.Invoke((MethodInvoker)(() => lblPatientTemp.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp.Value || temp1 > maxTemp.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 1!!");
                }


            } while (true);
        }

        public void NumbersTwo()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart2.Invoke((MethodInvoker)(() => lblPatientHeart2.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart2.Invoke((MethodInvoker)(() => lblPatientHeart2.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart2.Value || heart1 > maxHeart2.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 2!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing2.Invoke((MethodInvoker)(() => lblPatientBreathing2.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing2.Invoke((MethodInvoker)(() => lblPatientBreathing2.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing2.Value || breath1 > maxBreathing2.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 2!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic2.Invoke((MethodInvoker)(() => lblPatientSystolic2.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic2.Invoke((MethodInvoker)(() => lblPatientSystolic2.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic2.Value || systolic1 > maxSystolic2.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 2!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic2.Invoke((MethodInvoker)(() => lblPatientDiastolic2.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic2.Invoke((MethodInvoker)(() => lblPatientDiastolic2.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic2.Value || diastolic1 > maxDiastolic2.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 2!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp2.Invoke((MethodInvoker)(() => lblPatientTemp2.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp2.Invoke((MethodInvoker)(() => lblPatientTemp2.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp2.Value || temp1 > maxTemp2.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 2!!");
                }


            } while (true);
        }

        public void NumbersThree()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart3.Invoke((MethodInvoker)(() => lblPatientHeart3.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart3.Invoke((MethodInvoker)(() => lblPatientHeart3.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart3.Value || heart1 > maxHeart3.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 3!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing3.Invoke((MethodInvoker)(() => lblPatientBreathing3.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing3.Invoke((MethodInvoker)(() => lblPatientBreathing3.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing3.Value || breath1 > maxBreathing3.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 3!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic3.Invoke((MethodInvoker)(() => lblPatientSystolic3.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic3.Invoke((MethodInvoker)(() => lblPatientSystolic3.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic3.Value || systolic1 > maxSystolic3.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 3!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic3.Invoke((MethodInvoker)(() => lblPatientDiastolic3.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic3.Invoke((MethodInvoker)(() => lblPatientDiastolic3.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic3.Value || diastolic1 > maxDiastolic3.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 3!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp3.Invoke((MethodInvoker)(() => lblPatientTemp3.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp3.Invoke((MethodInvoker)(() => lblPatientTemp3.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp3.Value || temp1 > maxTemp3.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 3!!");
                }


            } while (true);
        }

        public void NumbersFour()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart4.Invoke((MethodInvoker)(() => lblPatientHeart4.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart4.Invoke((MethodInvoker)(() => lblPatientHeart4.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart4.Value || heart1 > maxHeart4.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 4!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing4.Invoke((MethodInvoker)(() => lblPatientBreathing4.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing4.Invoke((MethodInvoker)(() => lblPatientBreathing4.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing4.Value || breath1 > maxBreathing4.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 4!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic4.Invoke((MethodInvoker)(() => lblPatientSystolic4.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic4.Invoke((MethodInvoker)(() => lblPatientSystolic4.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic4.Value || systolic1 > maxSystolic4.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 4!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic4.Invoke((MethodInvoker)(() => lblPatientDiastolic4.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic4.Invoke((MethodInvoker)(() => lblPatientDiastolic4.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic4.Value || diastolic1 > maxDiastolic4.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 4!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp4.Invoke((MethodInvoker)(() => lblPatientTemp4.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp4.Invoke((MethodInvoker)(() => lblPatientTemp4.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp4.Value || temp1 > maxTemp4.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 4!!");
                }


            } while (true);
        }

        public void NumbersFive()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart5.Invoke((MethodInvoker)(() => lblPatientHeart5.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart5.Invoke((MethodInvoker)(() => lblPatientHeart5.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart5.Value || heart1 > maxHeart5.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 5!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing5.Invoke((MethodInvoker)(() => lblPatientBreathing5.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing5.Invoke((MethodInvoker)(() => lblPatientBreathing5.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing5.Value || breath1 > maxBreathing5.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 5!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic5.Invoke((MethodInvoker)(() => lblPatientSystolic5.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic5.Invoke((MethodInvoker)(() => lblPatientSystolic5.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic5.Value || systolic1 > maxSystolic5.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 5!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic5.Invoke((MethodInvoker)(() => lblPatientDiastolic5.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic5.Invoke((MethodInvoker)(() => lblPatientDiastolic5.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic5.Value || diastolic1 > maxDiastolic5.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 5!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp5.Invoke((MethodInvoker)(() => lblPatientTemp5.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp5.Invoke((MethodInvoker)(() => lblPatientTemp5.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp5.Value || temp1 > maxTemp5.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 5!!");
                }


            } while (true);
        }

        public void NumbersSix()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart6.Invoke((MethodInvoker)(() => lblPatientHeart6.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart6.Invoke((MethodInvoker)(() => lblPatientHeart6.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart6.Value || heart1 > maxHeart6.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 6!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing6.Invoke((MethodInvoker)(() => lblPatientBreathing6.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing6.Invoke((MethodInvoker)(() => lblPatientBreathing6.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing6.Value || breath1 > maxBreathing6.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 6!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic6.Invoke((MethodInvoker)(() => lblPatientSystolic6.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic6.Invoke((MethodInvoker)(() => lblPatientSystolic6.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic6.Value || systolic1 > maxSystolic6.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 6!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic6.Invoke((MethodInvoker)(() => lblPatientDiastolic6.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic6.Invoke((MethodInvoker)(() => lblPatientDiastolic6.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic6.Value || diastolic1 > maxDiastolic6.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 6!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp6.Invoke((MethodInvoker)(() => lblPatientTemp6.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp6.Invoke((MethodInvoker)(() => lblPatientTemp6.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp6.Value || temp1 > maxTemp6.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 6!!");
                }


            } while (true);
        }

        public void NumbersSeven()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart7.Invoke((MethodInvoker)(() => lblPatientHeart7.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart7.Invoke((MethodInvoker)(() => lblPatientHeart7.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart7.Value || heart1 > maxHeart7.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 7!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing7.Invoke((MethodInvoker)(() => lblPatientBreathing7.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing7.Invoke((MethodInvoker)(() => lblPatientBreathing7.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing7.Value || breath1 > maxBreathing7.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 7!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic7.Invoke((MethodInvoker)(() => lblPatientSystolic7.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic7.Invoke((MethodInvoker)(() => lblPatientSystolic7.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic7.Value || systolic1 > maxSystolic7.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 7!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic7.Invoke((MethodInvoker)(() => lblPatientDiastolic7.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic7.Invoke((MethodInvoker)(() => lblPatientDiastolic7.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic7.Value || diastolic1 > maxDiastolic7.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 7!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp7.Invoke((MethodInvoker)(() => lblPatientTemp7.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp7.Invoke((MethodInvoker)(() => lblPatientTemp7.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp7.Value || temp1 > maxTemp7.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 7!!");
                }


            } while (true);
        }

        public void NumbersEight()
        {
            do
            {
                //assigns random number from 
                int heart1 = NumberG.Heart1();
                lblPatientHeart8.Invoke((MethodInvoker)(() => lblPatientHeart8.Text = Convert.ToString(heart1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientHeart8.Invoke((MethodInvoker)(() => lblPatientHeart8.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (heart1 < minHeart8.Value || heart1 > maxHeart8.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's HEART RATE is out of the set limits! BED 8!!");
                }


                //assigns random number from method to label
                int breath1 = NumberG.Breath1();
                lblPatientBreathing8.Invoke((MethodInvoker)(() => lblPatientBreathing8.Text = Convert.ToString(breath1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientBreathing8.Invoke((MethodInvoker)(() => lblPatientBreathing8.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (breath1 < minBreathing8.Value || breath1 > maxBreathing8.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's BREATHING RATE is out of the set limits! BED 8!!");
                }


                //assigns random number from method to label
                int systolic1 = NumberG.Systolic1();
                lblPatientSystolic8.Invoke((MethodInvoker)(() => lblPatientSystolic8.Text = Convert.ToString(systolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientSystolic8.Invoke((MethodInvoker)(() => lblPatientSystolic8.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (systolic1 < minSystolic8.Value || systolic1 > maxSystolic8.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's SYSTOLIC PRESSURE is out of the set limits! BED 8!!");
                }


                //assigns random number from method to label
                int diastolic1 = NumberG.Diastolic1();
                lblPatientDiastolic8.Invoke((MethodInvoker)(() => lblPatientDiastolic8.Text = Convert.ToString(diastolic1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientDiastolic8.Invoke((MethodInvoker)(() => lblPatientDiastolic8.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (diastolic1 < minDiastolic8.Value || diastolic1 > maxDiastolic8.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's DIASTOLIC PRESSURE is out of the set limits! BED 8!!");
                }


                //assigns random number from method to label
                int temp1 = NumberG.Temp1();
                lblPatientTemp8.Invoke((MethodInvoker)(() => lblPatientTemp8.Text = Convert.ToString(temp1))); //Source: http://stackoverflow.com/questions/2172467/set-value-of-label-with-c-sharp-cross-threading
                Thread.Sleep(500); //Wait
                lblPatientTemp8.Invoke((MethodInvoker)(() => lblPatientTemp8.Refresh())); //Refresh label for different number
                //if the patient data goes out of the max or min limits, sound alarm and display a message 
                if (temp1 < minTemp8.Value || temp1 > maxTemp8.Value)
                {
                    playSound();
                    MessageBox.Show("Patient's TEMPERATURE is out of the set limits! BED 8!!");
                }


            } while (true);
        }

        //Method that sounds an alarm
        private void playSound()
        {
            //string cd = Directory.GetCurrentDirectory();
            //MessageBox.Show(cd);
            string file = (@"C:\Users\Marley\Documents\Visual Studio 2015\Projects\NumberGenerator\NumberGenerator\Mutable.wav"); //cd + @"../../Mutable.wav";
            SoundPlayer sound = new SoundPlayer(file);
            sound.Play();

        }

        private void btnOnCall_Click(object sender, EventArgs e)
        {
            {
                //int curRow = dgvStaffNOC.CurrentCell.RowIndex;
                DataGridViewSelectedRowCollection selectedRows = dgvStaffNOCT.SelectedRows;
                if (selectedRows.Count > 0)
                {
                    int curRow = int.Parse(dgvStaffNOCT.SelectedRows[0].Cells["Id"].Value.ToString());
                    int rows = PatientDataB.DatabaseConnectionInstance.Oncall(curRow, invariable.sqlQuerySetOnCall);
                    if (rows == invariable.OncallError)
                    {
                        MessageBox.Show(invariable.errNothingMovedTables);

                        LoadTable();
                        ReloadStaffTables();


                    }
                    else
                    {
                        MessageBox.Show("No Staff Member Selected");
                    }

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOffCall_Click(object sender, EventArgs e)
        {
            //int curRow = dgvStaffNOC.CurrentCell.RowIndex;
            DataGridViewSelectedRowCollection selectedRows = dgvStaffOCT.SelectedRows;
            if (selectedRows.Count > 0)
            {
                int curRow1 = int.Parse(dgvStaffOCT.SelectedRows[0].Cells["Id"].Value.ToString());
                int rows = PatientDataB.DatabaseConnectionInstance.Offcall(curRow1, invariable.sqlQuerySetOffCall);
                if (rows == invariable.OncallError)
                {
                    MessageBox.Show(invariable.errNothingMovedTables);

                    LoadTable();
                    ReloadStaffTables();


                }
                else
                {
                    MessageBox.Show("No Staff Member Selected");
                }

            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                Numbers();

            }).Start();
        }

        private void cbheart1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart1.Checked)
            {
                lblHeartRate.Visible = false;
                lblPatientHeart.Visible = false;
                minHeart.Visible = false;
                maxHeart.Visible = false;
            }
            else
            {
                lblHeartRate.Visible = true;
                lblPatientHeart.Visible = true;
                minHeart.Visible = true;
                maxHeart.Visible = true;
            }
        }

        private void cbbreath1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath1.Checked)
            {
                lblBreathingRate.Visible = false;
                lblPatientBreathing.Visible = false;
                minBreathing.Visible = false;
                maxBreathing.Visible = false;
            }
            else
            {
                lblBreathingRate.Visible = true;
                lblPatientBreathing.Visible = true;
                minBreathing.Visible = true;
                maxBreathing.Visible = true;
            }
        }

        private void cbsystolic1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic1.Checked)
            {
                lblSystolicPressure.Visible = false;
                lblPatientSystolic.Visible = false;
                minSystolic.Visible = false;
                maxSystolic.Visible = false;
            }
            else
            {
                lblSystolicPressure.Visible = true;
                lblPatientSystolic.Visible = true;
                minSystolic.Visible = true;
                maxSystolic.Visible = true;
            }
        }

        private void cbdiastolic1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic1.Checked)
            {
                lblDiastolicPressure.Visible = false;
                lblPatientDiastolic.Visible = false;
                minDiastolic.Visible = false;
                maxDiastolic.Visible = false;
            }
            else
            {
                lblDiastolicPressure.Visible = true;
                lblPatientDiastolic.Visible = true;
                minDiastolic.Visible = true;
                maxDiastolic.Visible = true;
            }
        }

        private void cbtemp1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp1.Checked)
            {
                lblTemperature.Visible = false;
                lblPatientTemp.Visible = false;
                minTemp.Visible = false;
                maxTemp.Visible = false;
            }
            else
            {
                lblTemperature.Visible = true;
                lblPatientTemp.Visible = true;
                minTemp.Visible = true;
                maxTemp.Visible = true;
            }
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersTwo();

            }).Start();
        }

        private void cbheart2_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart2.Checked)
            {
                lblHeartRate2.Visible = false;
                lblPatientHeart2.Visible = false;
                minHeart2.Visible = false;
                maxHeart2.Visible = false;
            }
            else
            {
                lblHeartRate2.Visible = true;
                lblPatientHeart2.Visible = true;
                minHeart2.Visible = true;
                maxHeart2.Visible = true;
            }
        }

        private void cbbreath2_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath2.Checked)
            {
                lblBreathingRate2.Visible = false;
                lblPatientBreathing2.Visible = false;
                minBreathing2.Visible = false;
                maxBreathing2.Visible = false;
            }
            else
            {
                lblBreathingRate2.Visible = true;
                lblPatientBreathing2.Visible = true;
                minBreathing2.Visible = true;
                maxBreathing2.Visible = true;
            }
        }

        private void cbsystolic2_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic2.Checked)
            {
                lblSystolicPressure2.Visible = false;
                lblPatientSystolic2.Visible = false;
                minSystolic2.Visible = false;
                maxSystolic2.Visible = false;
            }
            else
            {
                lblSystolicPressure2.Visible = true;
                lblPatientSystolic2.Visible = true;
                minSystolic2.Visible = true;
                maxSystolic2.Visible = true;
            }
        }

        private void cbdiastolic2_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic2.Checked)
            {
                lblDiastolicPressure2.Visible = false;
                lblPatientDiastolic2.Visible = false;
                minDiastolic2.Visible = false;
                maxDiastolic2.Visible = false;
            }
            else
            {
                lblDiastolicPressure2.Visible = true;
                lblPatientDiastolic2.Visible = true;
                minDiastolic2.Visible = true;
                maxDiastolic2.Visible = true;
            }
        }

        private void cbtemp2_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp2.Checked)
            {
                lblTemperature2.Visible = false;
                lblPatientTemp2.Visible = false;
                minTemp2.Visible = false;
                maxTemp2.Visible = false;
            }
            else
            {
                lblTemperature2.Visible = true;
                lblPatientTemp2.Visible = true;
                minTemp2.Visible = true;
                maxTemp2.Visible = true;
            }
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersThree();

            }).Start();
        }

        private void cbheart3_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart3.Checked)
            {
                lblHeartRate3.Visible = false;
                lblPatientHeart3.Visible = false;
                minHeart3.Visible = false;
                maxHeart3.Visible = false;
            }
            else
            {
                lblHeartRate3.Visible = true;
                lblPatientHeart3.Visible = true;
                minHeart3.Visible = true;
                maxHeart3.Visible = true;
            }
        }

        private void cbbreath3_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath3.Checked)
            {
                lblBreathingRate3.Visible = false;
                lblPatientBreathing3.Visible = false;
                minBreathing3.Visible = false;
                maxBreathing3.Visible = false;
            }
            else
            {
                lblBreathingRate3.Visible = true;
                lblPatientBreathing3.Visible = true;
                minBreathing3.Visible = true;
                maxBreathing3.Visible = true;
            }
        }

        private void cbsystolic3_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic3.Checked)
            {
                lblSystolicPressure3.Visible = false;
                lblPatientSystolic3.Visible = false;
                minSystolic3.Visible = false;
                maxSystolic3.Visible = false;
            }
            else
            {
                lblSystolicPressure3.Visible = true;
                lblPatientSystolic3.Visible = true;
                minSystolic3.Visible = true;
                maxSystolic3.Visible = true;
            }
        }

        private void cbdiastolic3_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic3.Checked)
            {
                lblDiastolicPressure3.Visible = false;
                lblPatientDiastolic3.Visible = false;
                minDiastolic3.Visible = false;
                maxDiastolic3.Visible = false;
            }
            else
            {
                lblDiastolicPressure3.Visible = true;
                lblPatientDiastolic3.Visible = true;
                minDiastolic3.Visible = true;
                maxDiastolic3.Visible = true;
            }
        }

        private void cbtemp3_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp3.Checked)
            {
                lblTemperature3.Visible = false;
                lblPatientTemp3.Visible = false;
                minTemp3.Visible = false;
                maxTemp3.Visible = false;
            }
            else
            {
                lblTemperature3.Visible = true;
                lblPatientTemp3.Visible = true;
                minTemp3.Visible = true;
                maxTemp3.Visible = true;
            }
        }

        private void btnStart4_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersFour();

            }).Start();
        }

        private void cbheart4_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart4.Checked)
            {
                lblHeartRate4.Visible = false;
                lblPatientHeart4.Visible = false;
                minHeart4.Visible = false;
                maxHeart4.Visible = false;
            }
            else
            {
                lblHeartRate4.Visible = true;
                lblPatientHeart4.Visible = true;
                minHeart4.Visible = true;
                maxHeart4.Visible = true;
            }
        }

        private void cbbreath4_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath4.Checked)
            {
                lblBreathingRate4.Visible = false;
                lblPatientBreathing4.Visible = false;
                minBreathing4.Visible = false;
                maxBreathing4.Visible = false;
            }
            else
            {
                lblBreathingRate4.Visible = true;
                lblPatientBreathing4.Visible = true;
                minBreathing4.Visible = true;
                maxBreathing4.Visible = true;
            }
        }

        private void cbsystolic4_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic4.Checked)
            {
                lblSystolicPressure4.Visible = false;
                lblPatientSystolic4.Visible = false;
                minSystolic4.Visible = false;
                maxSystolic4.Visible = false;
            }
            else
            {
                lblSystolicPressure4.Visible = true;
                lblPatientSystolic4.Visible = true;
                minSystolic4.Visible = true;
                maxSystolic4.Visible = true;
            }
        }

        private void cbdiastolic4_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic4.Checked)
            {
                lblDiastolicPressure4.Visible = false;
                lblPatientDiastolic4.Visible = false;
                minDiastolic4.Visible = false;
                maxDiastolic4.Visible = false;
            }
            else
            {
                lblDiastolicPressure4.Visible = true;
                lblPatientDiastolic4.Visible = true;
                minDiastolic4.Visible = true;
                maxDiastolic4.Visible = true;
            }
        }

        private void cbtemp4_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp4.Checked)
            {
                lblTemperature4.Visible = false;
                lblPatientTemp4.Visible = false;
                minTemp4.Visible = false;
                maxTemp4.Visible = false;
            }
            else
            {
                lblTemperature4.Visible = true;
                lblPatientTemp4.Visible = true;
                minTemp4.Visible = true;
                maxTemp4.Visible = true;
            }
        }

        private void btnStart5_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersFive();

            }).Start();
        }

        private void cbheart5_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart5.Checked)
            {
                lblHeartRate5.Visible = false;
                lblPatientHeart5.Visible = false;
                minHeart5.Visible = false;
                maxHeart5.Visible = false;
            }
            else
            {
                lblHeartRate5.Visible = true;
                lblPatientHeart5.Visible = true;
                minHeart5.Visible = true;
                maxHeart5.Visible = true;
            }
        }

        private void cbbreath5_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath5.Checked)
            {
                lblBreathingRate5.Visible = false;
                lblPatientBreathing5.Visible = false;
                minBreathing5.Visible = false;
                maxBreathing5.Visible = false;
            }
            else
            {
                lblBreathingRate5.Visible = true;
                lblPatientBreathing5.Visible = true;
                minBreathing5.Visible = true;
                maxBreathing5.Visible = true;
            }
        }

        private void cbsystolic5_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic5.Checked)
            {
                lblSystolicPressure5.Visible = false;
                lblPatientSystolic5.Visible = false;
                minSystolic5.Visible = false;
                maxSystolic5.Visible = false;
            }
            else
            {
                lblSystolicPressure5.Visible = true;
                lblPatientSystolic5.Visible = true;
                minSystolic5.Visible = true;
                maxSystolic5.Visible = true;
            }
        }

        private void cbdiastolic5_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic5.Checked)
            {
                lblDiastolicPressure5.Visible = false;
                lblPatientDiastolic5.Visible = false;
                minDiastolic5.Visible = false;
                maxDiastolic5.Visible = false;
            }
            else
            {
                lblDiastolicPressure5.Visible = true;
                lblPatientDiastolic5.Visible = true;
                minDiastolic5.Visible = true;
                maxDiastolic5.Visible = true;
            }
        }

        private void cbtemp5_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp5.Checked)
            {
                lblTemperature5.Visible = false;
                lblPatientTemp5.Visible = false;
                minTemp5.Visible = false;
                maxTemp5.Visible = false;
            }
            else
            {
                lblTemperature5.Visible = true;
                lblPatientTemp5.Visible = true;
                minTemp5.Visible = true;
                maxTemp5.Visible = true;
            }
        }

        private void btnStart6_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersSix();

            }).Start();
        }

        private void cbheart6_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart6.Checked)
            {
                lblHeartRate6.Visible = false;
                lblPatientHeart6.Visible = false;
                minHeart6.Visible = false;
                maxHeart6.Visible = false;
            }
            else
            {
                lblHeartRate6.Visible = true;
                lblPatientHeart6.Visible = true;
                minHeart6.Visible = true;
                maxHeart6.Visible = true;
            }
        }

        private void cbbreath6_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath6.Checked)
            {
                lblBreathingRate6.Visible = false;
                lblPatientBreathing6.Visible = false;
                minBreathing6.Visible = false;
                maxBreathing6.Visible = false;
            }
            else
            {
                lblBreathingRate6.Visible = true;
                lblPatientBreathing6.Visible = true;
                minBreathing6.Visible = true;
                maxBreathing6.Visible = true;
            }
        }

        private void cbsystolic6_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic6.Checked)
            {
                lblSystolicPressure6.Visible = false;
                lblPatientSystolic6.Visible = false;
                minSystolic6.Visible = false;
                maxSystolic6.Visible = false;
            }
            else
            {
                lblSystolicPressure6.Visible = true;
                lblPatientSystolic6.Visible = true;
                minSystolic6.Visible = true;
                maxSystolic6.Visible = true;
            }
        }

        private void cbdiastolic6_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic6.Checked)
            {
                lblDiastolicPressure6.Visible = false;
                lblPatientDiastolic6.Visible = false;
                minDiastolic6.Visible = false;
                maxDiastolic6.Visible = false;
            }
            else
            {
                lblDiastolicPressure6.Visible = true;
                lblPatientDiastolic6.Visible = true;
                minDiastolic6.Visible = true;
                maxDiastolic6.Visible = true;
            }
        }

        private void cbtemp6_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp6.Checked)
            {
                lblTemperature6.Visible = false;
                lblPatientTemp6.Visible = false;
                minTemp6.Visible = false;
                maxTemp6.Visible = false;
            }
            else
            {
                lblTemperature6.Visible = true;
                lblPatientTemp6.Visible = true;
                minTemp6.Visible = true;
                maxTemp6.Visible = true;
            }
        }

        private void btnStart7_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersSeven();

            }).Start();
        }

        private void cbheart7_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart7.Checked)
            {
                lblHeartRate7.Visible = false;
                lblPatientHeart7.Visible = false;
                minHeart7.Visible = false;
                maxHeart7.Visible = false;
            }
            else
            {
                lblHeartRate7.Visible = true;
                lblPatientHeart7.Visible = true;
                minHeart7.Visible = true;
                maxHeart7.Visible = true;
            }
        }

        private void cbbreath7_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath7.Checked)
            {
                lblBreathingRate7.Visible = false;
                lblPatientBreathing7.Visible = false;
                minBreathing7.Visible = false;
                maxBreathing7.Visible = false;
            }
            else
            {
                lblBreathingRate7.Visible = true;
                lblPatientBreathing7.Visible = true;
                minBreathing7.Visible = true;
                maxBreathing7.Visible = true;
            }
        }

        private void cbsystolic7_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic7.Checked)
            {
                lblSystolicPressure7.Visible = false;
                lblPatientSystolic7.Visible = false;
                minSystolic7.Visible = false;
                maxSystolic7.Visible = false;
            }
            else
            {
                lblSystolicPressure7.Visible = true;
                lblPatientSystolic7.Visible = true;
                minSystolic7.Visible = true;
                maxSystolic7.Visible = true;
            }
        }

        private void cbdiastolic7_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic7.Checked)
            {
                lblDiastolicPressure7.Visible = false;
                lblPatientDiastolic7.Visible = false;
                minDiastolic7.Visible = false;
                maxDiastolic7.Visible = false;
            }
            else
            {
                lblDiastolicPressure7.Visible = true;
                lblPatientDiastolic7.Visible = true;
                minDiastolic7.Visible = true;
                maxDiastolic7.Visible = true;
            }
        }

        private void cbtemp7_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp7.Checked)
            {
                lblTemperature7.Visible = false;
                lblPatientTemp7.Visible = false;
                minTemp7.Visible = false;
                maxTemp7.Visible = false;
            }
            else
            {
                lblTemperature7.Visible = true;
                lblPatientTemp7.Visible = true;
                minTemp7.Visible = true;
                maxTemp7.Visible = true;
            }
        }

        private void btnStart8_Click(object sender, EventArgs e)
        {
            //Create new thread, enabling us to perform other tasks while displaying patient data --- Code from Stackoverflow
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                NumbersEight();

            }).Start();
        }

        private void cbheart8_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbheart8.Checked)
            {
                lblHeartRate8.Visible = false;
                lblPatientHeart8.Visible = false;
                minHeart8.Visible = false;
                maxHeart8.Visible = false;
            }
            else
            {
                lblHeartRate8.Visible = true;
                lblPatientHeart8.Visible = true;
                minHeart8.Visible = true;
                maxHeart8.Visible = true;
            }
        }

        private void cbbreath8_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbbreath8.Checked)
            {
                lblBreathingRate8.Visible = false;
                lblPatientBreathing8.Visible = false;
                minBreathing8.Visible = false;
                maxBreathing8.Visible = false;
            }
            else
            {
                lblBreathingRate8.Visible = true;
                lblPatientBreathing8.Visible = true;
                minBreathing8.Visible = true;
                maxBreathing8.Visible = true;
            }
        }

        private void cbsystolic8_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbsystolic8.Checked)
            {
                lblSystolicPressure8.Visible = false;
                lblPatientSystolic8.Visible = false;
                minSystolic8.Visible = false;
                maxSystolic8.Visible = false;
            }
            else
            {
                lblSystolicPressure8.Visible = true;
                lblPatientSystolic8.Visible = true;
                minSystolic8.Visible = true;
                maxSystolic8.Visible = true;
            }
        }

        private void cbdiastolic8_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbdiastolic8.Checked)
            {
                lblDiastolicPressure8.Visible = false;
                lblPatientDiastolic8.Visible = false;
                minDiastolic8.Visible = false;
                maxDiastolic8.Visible = false;
            }
            else
            {
                lblDiastolicPressure8.Visible = true;
                lblPatientDiastolic8.Visible = true;
                minDiastolic8.Visible = true;
                maxDiastolic8.Visible = true;
            }
        }

        private void cbtemp8_CheckedChanged(object sender, EventArgs e)
        {
            //if check box is ticked, hide the following items, if not, leave them visible
            if (cbtemp8.Checked)
            {
                lblTemperature8.Visible = false;
                lblPatientTemp8.Visible = false;
                minTemp8.Visible = false;
                maxTemp8.Visible = false;
            }
            else
            {
                lblTemperature8.Visible = true;
                lblPatientTemp8.Visible = true;
                minTemp8.Visible = true;
                maxTemp8.Visible = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }
    }
}