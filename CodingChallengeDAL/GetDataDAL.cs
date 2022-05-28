using CodingChallengeEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodingChallengeDAL
{
    public class GetDataDAL : IGetDataDAL
    {

        private static SqlConnection sqlConnection;

        private void Connection()
        {
            sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=CodingChallenge6;Integrated Security=true");
        }

        public List<LeadEntity> GetLeadDAL()
        {
            DataTable dataTable = new DataTable();
            List<LeadEntity> leadEntities = new List<LeadEntity>();


            try
            {
                Connection();
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DisplayLead", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                leadEntities.Add(
                    new LeadEntity
                    {
                        LeadId = Convert.ToInt32(dataRow["LeadId"]),
                        LeadName = Convert.ToString(dataRow["LeadName"]),
                        TechnologyId = Convert.ToInt32(dataRow["TechnologyId"])

                    });
            }
            return leadEntities;

        }

        public List<CandidateEntity> GetCandidateByLead(int leadId)
        {

            List<CandidateEntity> candidateEntities = new List<CandidateEntity>();
            Connection();
            sqlConnection.Open();
            string query = "SELECT C.CandidateId , C.CandidateName " +
                "FROM Candidate C inner join Lead L on L.LeadId=C.LeadId and C.LeadId =" + leadId + ";";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                CandidateEntity candidate = new CandidateEntity();
                candidate.CandidateId = Convert.ToInt32(sqlDataReader[0]);
                candidate.CandidateName = sqlDataReader[1].ToString();

                candidateEntities.Add(candidate);

            }

            sqlConnection.Close();
            return candidateEntities;
        }

        public List<TechnologyEntity> GetTechnologyDAL()
        {
            DataTable dataTable = new DataTable();
            List<TechnologyEntity> technologyEntities = new List<TechnologyEntity>();


            try
            {
                Connection();
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DisplayTechnology", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                technologyEntities.Add(
                    new TechnologyEntity
                    {
                        TechonolgyId = Convert.ToInt32(dataRow["TechnologyId"]),
                        TechnologyName = Convert.ToString(dataRow["TechnologyName"])

                    });
            }
            return technologyEntities;

        }

        public int CountByTechnology(int technologyId)
        {
            Connection();
            sqlConnection.Open();
            string query = "SELECT COUNT(*) from Candidate where LeadId = (select LeadId from Lead L inner join Technology T on T.TechnologyId = L.TechnologyId and T.TechnologyId =" + technologyId + ");";
            

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Int32 count = (Int32)sqlCommand.ExecuteScalar();
            int row = sqlCommand.ExecuteNonQuery();

            return count;

        }

    }
}
