using System.Data;
using System.Data.SqlClient;
 namespace CURDOPERTION.Model;

public class DataAcessLayer
{
    public Responce GetAllDetails(SqlConnection connection)
    {
        Responce response = new Responce();
        SqlDataAdapter da = new SqlDataAdapter("select * from HOSPITAL", connection);
        DataTable dt = new DataTable();
        List<HOSPITAL> lstHospital = new List<HOSPITAL>();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HOSPITAL hOSPITAL = new HOSPITAL();
                hOSPITAL.Hospitalid = Convert.ToInt32(dt.Rows[i]["Hospitalid"]);
                hOSPITAL.Hospitalname = Convert.ToString(dt.Rows[i]["HospitalName"]);
                hOSPITAL.Hospitalph_no = Convert.ToInt32(dt.Rows[i]["Hospitalph_no"]);
                hOSPITAL.Hospitalcity = Convert.ToString(dt.Rows[i]["Hospitalcity"]);

                lstHospital.Add(hOSPITAL);


            }


        }
        if (lstHospital.Count > 0)
        {
            response.StatusCode = 200;
            response.StatusMessage = "Data  Found";
            response.HOSPITALList = lstHospital;
        }
        else
        {
            response.StatusCode = 100;
            response.StatusMessage = "Data Found";
            response.HOSPITALList = null;
        }


        return response;
    }


    public Responce GetAllDetailsByid(SqlConnection connection, int id)
    {
        Responce response = new Responce();
        SqlDataAdapter da = new SqlDataAdapter("select * from HOSPITAL where id= '" + id + "'", connection);
        DataTable dt = new DataTable();
        HOSPITAL hospital = new HOSPITAL();
        
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            
            
               
                hospital.Hospitalid = Convert.ToInt32(dt.Rows[0]["Hospitalid"]);
                hospital.Hospitalname = Convert.ToString(dt.Rows[1]["HospitalName"]);
                hospital.Hospitalph_no = Convert.ToInt32(dt.Rows[2]["Hospitalph_no"]);
                hospital.Hospitalcity = Convert.ToString(dt.Rows[3]["Hospitalcity"]);
            response.StatusCode = 200;
            response.StatusMessage = "Data Found";
            response.HOSPITAL= hospital;

            }
        else
        {
            response.StatusCode = 100;
            response.StatusMessage = "Data Not Found";
            response.HOSPITALList = null;

        }
        
        return response;
    }


    public Responce AddHOSPITAL(SqlConnection connection, HOSPITAL hospital)
    {
        Responce response = new Responce();
        SqlCommand cmd = new SqlCommand("insert into HOSPITAL(Hospitalid,HospitalName,Hospitalph_no,HospitalCity)" + "values('" + hospital.Hospitalid + "''" + hospital.Hospitalname + "'" + hospital.Hospitalph_no + "'" + hospital.Hospitalcity);
        connection.Open();
        int i=cmd.ExecuteNonQuery();
        connection.Close();

        if (i > 0)
        {
            response.StatusCode = 200;
            response.StatusMessage = "Patient Added";
            

        }
        else
        {
            response.StatusCode = 100;
            response.StatusMessage = "No Data is inserted";
            

        }

        return response;
    }

}