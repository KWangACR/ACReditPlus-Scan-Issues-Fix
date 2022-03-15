using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ACReditPlus_Scan_Issues_Fix.Helpers
{
    public class DuplicateFacilityCheckManager
    {
        private DataSet GetFacilityListWithSameAddress(FacilityAddressVerificationParameter facilityAddressVerificationParameter)
        {
            DataSet dsOutput = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection($"{ACREDIT_LEGACY_DB_CONN_STRING} {ConstStrings.COLUMN_ENCRYPTION_SETTING}"))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand("SYS__Common__P__CHECK_FACILITY_DUPLICATE", conn))
					{
                        cmd.Parameters.Add("@STREET_ADDRESS1", SqlDbType.NVarChar, 255);
                        cmd.Parameters["@STREET_ADDRESS1"].Value = facilityAddressVerificationParameter.StreetAddress;

                        cmd.Parameters.Add("@ZIP_CODE", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@ZIP_CODE"].Value = facilityAddressVerificationParameter.ZipCode;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        
                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
                            da.Fill(dsOutput);
                        }
                    }
                    
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                HttpContextHelper.HttpContext.RiseError(ex);
            }
            return dsOutput;
        }
    }
}
