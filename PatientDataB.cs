using System;
using System.ComponentModel;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace PatientMonitor
{

    class PatientDataB
    {
        //attributes 
        private static string connectionStr;

        //  SqlConnection connection;
        private static PatientDataB _instance;

        private System.Data.SqlClient.SqlConnection connectionToDB;

        private SqlDataAdapter dataAdapter;

        //constructors

        //properties 

        public static string ConnectionStr
        {
            set
            {
                connectionStr = value;
            }
        }

        //methods
        //return the connection to the database
        public static PatientDataB getDBConnectionInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientDataB();
            }

            return _instance;
        }


        // Open the connection
        public void openConnection()
        {
            // create the connection to the database as an instance of System.Data.SqlClient.SqlConnection
            connectionToDB = new System.Data.SqlClient.SqlConnection(connectionStr);

            //open the connection
            connectionToDB.Open();
        }

        public void closeConnection()
        {
            //close the connection to the database
            connectionToDB.Close();

        }

        public System.Data.DataSet getDataSet(String sqlQuery)
        {
            System.Data.DataSet dataSet = null;

            openConnection();

            // create the dataAdapter object
            dataAdapter = new SqlDataAdapter(sqlQuery, connectionToDB);

            //create the dataSet object
            dataSet = new System.Data.DataSet();

            //fill in the dataSet with the data coming from the DB 
            dataAdapter.Fill(dataSet);

            closeConnection();
            //return the dataset
            return dataSet;
        }
        private static PatientDataB databaseConnectionInstance;
        public static PatientDataB DatabaseConnectionInstance
        {
            get
            {
                if (databaseConnectionInstance == null)
                    databaseConnectionInstance = new PatientDataB();

                return databaseConnectionInstance;
            }
        }
        
        // delete the speciefied row from the table Students
        public int Oncall(int curRow, string sqlStatement)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                // create and initialise a sql command
                using (SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection))
                {

                    // set the parameters of the sql statement
                    sqlCommand.Parameters.AddWithValue("@curRow", curRow);

                    // open the connection and execute the command containing the sql statement
                    try
                    {
                        sqlConnection.Open();
                        int noOfRows = sqlCommand.ExecuteNonQuery();

                        //return the no of rows inserted(is 1 if executed correctly)
                        return noOfRows;
                    }
                    catch (System.Data.SqlClient.SqlException )
                    {
                        //return an error code
                        return invariable.OncallError;
                    }
                }
            }
        }

        public System.Data.DataSet getDataSetOC1(String sqlQuery)
        {
            System.Data.DataSet dataSetOC1 = null;

            openConnection();

            // create the dataAdapter object
            dataAdapter = new SqlDataAdapter(sqlQuery, connectionToDB);

            //create the dataSet object
            dataSetOC1 = new System.Data.DataSet();

            //fill in the dataSet with the data coming from the DB 
            dataAdapter.Fill(dataSetOC1);

            closeConnection();
            //return the dataset
            return dataSetOC1;
        }
        public int Offcall(int curRow1, string sqlStatement)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                // create and initialise a sql command
                using (SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection))
                {

                    // set the parameters of the sql statement
                    sqlCommand.Parameters.AddWithValue("@curRow1", curRow1);

                    // open the connection and execute the command containing the sql statement
                    try
                    {
                        sqlConnection.Open();
                        int noOfRows = sqlCommand.ExecuteNonQuery();

                        //return the no of rows inserted(is 1 if executed correctly)
                        return noOfRows;
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        //return an error code
                        return invariable.OffcallError;
                    }

                }

            }
        }
    }
}
        
    
