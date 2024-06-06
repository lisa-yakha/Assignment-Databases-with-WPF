using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace NeigbourhoodManagementAPI
{
    public class DataServices
    {
        public static string connstring = "Data Source=DESKTOP-CUM9PGM;Initial Catalog=NeigbourhoodManagementDatabase;Integrated Security=True;Persist Security Info=False;";
        //in the environment like - new SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));

        #region Insert/Update

        public async Task<bool> InsertComplaintAsync(Models.ComplaintForm complaint)
        {
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("INSERT_Complaint", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("NameOfAuthor", complaint.NameOfAuthor);
                cmd.Parameters.AddWithValue("BuildingNumberOfAuthor", complaint.BuildingNumberOfAuthor);
                cmd.Parameters.AddWithValue("ApartmentNumberOfAuthor", complaint.ApartmentNumberOfAuthor);
                cmd.Parameters.AddWithValue("Description", complaint.Description);
                cmd.Parameters.AddWithValue("BuildingNumberOfComplaint", complaint.BuildingNumberOfComplaint);
                cmd.Parameters.AddWithValue("ApartmentNumberOfComplaint", complaint.ApartmentNumberOfComplaint);
                cmd.Parameters.AddWithValue("ComplaintCategory", complaint.ComplaintCategory);
                cmd.Parameters.AddWithValue("ComplaintStatus", complaint.ComplaintStatus);

                int result = await cmd.ExecuteNonQueryAsync();
                await conn.CloseAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                await conn.CloseAsync();
                return false;
            }
        }

        public async Task<bool> UpdateStatusAsync(string id, int status)
        {
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("UPDATE_ComplaintStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("NewStatus", status);


                int result = await cmd.ExecuteNonQueryAsync();
                await conn.CloseAsync();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                await conn.CloseAsync();

                return false;
            }
        }


        #endregion

        #region Retrieve

        public async Task<List<Models.ComplaintForm>> RetrieveAllComplaints()
        {
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("RETRIEVE_AllComplaints", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rd = await cmd.ExecuteReaderAsync();

                if (!rd.HasRows)
                {
                    return null;
                }

                var templist = new List<Models.ComplaintForm>();
                while (await rd.ReadAsync())
                {
                    templist.Add(new Models.ComplaintForm()
                    {
                        Id = rd.GetValue(0).ToString(),
                        NameOfAuthor = rd.GetString(1),
                        BuildingNumberOfAuthor = rd.GetInt32(2),
                        ApartmentNumberOfAuthor = rd.GetInt32(3),
                        Description = rd.GetString(4),
                        BuildingNumberOfComplaint = rd.GetInt32(5),
                        ApartmentNumberOfComplaint = rd.GetInt32(6),
                        ComplaintCategory = (Models.ComplaintForm.Category)(int)rd.GetValue(7),
                        ComplaintStatus = (Models.ComplaintForm.Status)(int)rd.GetValue(8),
                        DateAdded = rd.GetDateTime(9)
                    });
                }
                await conn.CloseAsync();
                return templist;
            }
            catch (Exception e)
            {
                await conn.CloseAsync();
                return null;
            }
        }


        public async Task<List<Models.ComplaintForm>> RetrieveComplaintsByDateAsync(DateTime date)
        {
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("RETRIEVE_ComplaintsByDate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(parameterName: "@Keyword", date.Date);

                SqlDataReader rd = await cmd.ExecuteReaderAsync();
                var templist = new List<Models.ComplaintForm>();
                while (await rd.ReadAsync())
                {
                    templist.Add(new Models.ComplaintForm()
                    {
                        Id = rd.GetValue(0).ToString(),
                        NameOfAuthor = rd.GetString(1),
                        BuildingNumberOfAuthor = rd.GetInt32(2),
                        ApartmentNumberOfAuthor = rd.GetInt32(3),
                        Description = rd.GetString(4),
                        BuildingNumberOfComplaint = rd.GetInt32(5),
                        ApartmentNumberOfComplaint = rd.GetInt32(6),
                        ComplaintCategory = (Models.ComplaintForm.Category)(int)rd.GetValue(7),
                        ComplaintStatus = (Models.ComplaintForm.Status)(int)rd.GetValue(8),
                        DateAdded = rd.GetDateTime(9)
                    });
                }
                await conn.CloseAsync();
                return templist;

            }
            catch (Exception e)
            {
                await conn.CloseAsync();
                return null;
            }
        }

        public async Task<List<Models.ComplaintForm>> RetrieveComplaintsByNameAsync(string name)
        {
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("RETRIEVE_ComplaintsByNameOfAuthor", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);

                SqlDataReader rd = await cmd.ExecuteReaderAsync();
                var templist = new List<Models.ComplaintForm>();
                while (await rd.ReadAsync())
                {
                    templist.Add(new Models.ComplaintForm()
                    {
                        Id = rd.GetValue(0).ToString(),
                        NameOfAuthor = rd.GetString(1),
                        BuildingNumberOfAuthor = rd.GetInt32(2),
                        ApartmentNumberOfAuthor = rd.GetInt32(3),
                        Description = rd.GetString(4),
                        BuildingNumberOfComplaint = rd.GetInt32(5),
                        ApartmentNumberOfComplaint = rd.GetInt32(6),
                        ComplaintCategory = (Models.ComplaintForm.Category)(int)rd.GetValue(7),
                        ComplaintStatus = (Models.ComplaintForm.Status)(int)rd.GetValue(8),
                        DateAdded = rd.GetDateTime(9)
                    });
                }
                await conn.CloseAsync();
                return templist;

            }
            catch (Exception e)
            {
                await conn.CloseAsync();
                return null;
            }

        }
        #endregion
    }
}
