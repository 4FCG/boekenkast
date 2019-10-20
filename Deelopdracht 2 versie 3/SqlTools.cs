using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Deelopdracht_2_versie_3
{
    static class SqlTools
    {
        private const string connectionstring = "Data Source=USER;Initial Catalog=\"deelopdracht 2\";Integrated Security=True";
        public static DataTable SqlRead(string queryString, params object[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    SqlQueryParameters(command, queryString, args);
                    command.Connection.Open();
                    DataTable data = new DataTable();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        data.Load(reader);
                    }
                    command.Connection.Close();
                    return data;
                }
            }
        }
        //Creates proper SqlParameters from given parameters and adds them to the given SqlCommand, Parameter names are taken from the queryString.
        private static void SqlQueryParameters(SqlCommand command, string queryString, object[] parameters)
        {
            int counter = 0;
            //Match all characters afer @ until whitespace
            try
            {
                foreach (Match match in new Regex(@"@(\S+)").Matches(queryString))
                {
                    command.Parameters.Add(new SqlParameter(match.Value, parameters[counter]));
                    counter++;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect amount of parameters given for Sql function.");
                throw;
            }
        }

        public static int SqlWrite(string queryString, params object[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    SqlQueryParameters(command, queryString, args);
                    command.Connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static Dictionary<string, object> RowToDict(DataRow row)
        {
            return row.Table.Columns.Cast<DataColumn>().ToDictionary(column => column.ColumnName, column => row[column]);
        }

        public static List<Dictionary<string, object>> SearchDatabaseObject(Type target)
        {
            var output = new List<Dictionary<string, object>>();
            using (DataTable data = SqlRead("SELECT * FROM " + target.ToString().Remove(0, 24) + " ;")) 
            {
                foreach (DataRow row in data.Rows)
                {
                    output.Add(RowToDict(row));
                }
            }
            
            return output;
        }
    }
}
/*
    CREATE TABLE Locatie (
    locatieId INT NOT NULL identity(1, 1),
    naam VARCHAR(255) NULL,
    PRIMARY KEY (locatieId));

    CREATE TABLE Boekenkast (
    boekenkastId INT NOT NULL identity(1, 1),
    plaats VARCHAR(255) NULL,
    locatieId INT NOT NULL,
    PRIMARY KEY (boekenkastId),
    INDEX locatie_idx (locatieId ASC),
    CONSTRAINT locatie_constraint
    FOREIGN KEY (locatieId)
    REFERENCES Locatie (locatieId)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

    CREATE TABLE Vak (
    vakId INT NOT NULL identity(1, 1),
    boekenkastId INT NOT NULL,
    PRIMARY KEY (vakId),
    INDEX kast_idx (boekenkastId ASC),
    CONSTRAINT kast_constraint
    FOREIGN KEY (boekenkastId)
    REFERENCES Boekenkast (boekenkastId)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

    CREATE TABLE Auteur (
    auteurId INT NOT NULL identity(1, 1),
    naam VARCHAR(255) NULL,
    leeftijd INT NULL,
    PRIMARY KEY (auteurId));

    CREATE TABLE Boek (
    boekId INT NOT NULL identity(1, 1),
    vakId INT NOT NULL,
    auteurId INT NOT NULL,
    titel VARCHAR(255) NOT NULL,
    genre VARCHAR(255) NOT NULL,
    PRIMARY KEY (boekId),
    INDEX vak_idx (vakId ASC),
    INDEX auteur_idx (auteurId ASC),
    CONSTRAINT vak_constraint
    FOREIGN KEY (vakId)
    REFERENCES Vak (vakId)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
    CONSTRAINT auteur_constraint
    FOREIGN KEY (auteurId)
    REFERENCES Auteur (auteurId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

 */
