using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Xml;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Reflection;
using System.Drawing;
using BMS.Model;
using BMS.Exceptions;
using BMS.Utils;
using BMS.Facade;
using BMS.Business;

using System.Data.OleDb;
using System.Net.Mail;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace BMS
{
    public class TextUtils
    {
        #region Variables
        static private SqlConnection mySqlConnection;

        #region FORMAT
        public const string CurrencyFormat = "###,###,###.00";
        public const string CurrencyFormatVND = "###,###,###,###";
        public const string FomatShortDate = "dd/MM/yyyy";
        public const string FormatLongDate = "dd/MM/yyyy HH:mm";
        #endregion

        #region MESSAGE
        public static string Caption = "[TÂN PHÁT] - Thông báo";    
        #endregion

        #region DATETIME
        public static DateTime MIN_DATE = new DateTime(1950, 1, 1);
        #endregion

        private static string[] Number_Patterns = new string[] { "{0:#,##0}", "{0:#,##0.0}", "{0:#,##0.00}", "{0:#,##0}.000", "{0:#,##0.0000}",
            "{0:#,##0.00000;#,##0.00000; }" };

        private static string[] Currency_Patterns = new string[] { "{0:$#,##0;($#,##0); }", "{0:$#,##0.0;($#,##0.0); }", "{0:$#,##0.00;($#,##0.00); }",
            "{0:$#,##0.000;($#,##0.000); }", "{0:$#,##0.0000;($#,##0.0000); }", "{0:$#,##0.00000;($#,##0.00000); }" };

        #endregion Variables

        #region Contructors
        public TextUtils()
        {
        }
        #endregion Contructors

        #region Methods

        #region Chuyển kiểu, ép kiểu
        /// <summary>
        /// Chuyển giá trị sang kiểu integer
        /// </summary>
        /// <param name="x">giá trị cần chuyển</param>
        /// <returns></returns>
        public static int ToInt(object x)
        {
            try
            {
                return Convert.ToInt32(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Chuyển giá trị sang kiểu long
        /// </summary>
        /// <param name="x">giá trị cần chuyển</param>
        /// <returns></returns>
        public static Int64 ToInt64(object x)
        {
            try
            {
                return Convert.ToInt64(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Chuyển giá trị sang kiểu decimal
        /// </summary>
        /// <param name="x">giá trị cần chuyển</param>
        /// <returns></returns>
        public static Decimal ToDecimal(object x)
        {
            try
            {
                return Convert.ToDecimal(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Chuyển giá trị sang kiểu double
        /// </summary>
        /// <param name="x">giá trị cần chuyển</param>
        /// <returns></returns>
        public static Double ToDouble(object x)
        {
            try
            {
                return Convert.ToDouble(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Chuyển giá trị sang kiểu bool
        /// </summary>
        /// <param name="x">giá trị cần chuyển</param>
        /// <returns></returns>
        public static bool ToBoolean(object x)
        {
            try
            {
                return Convert.ToBoolean(x);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Chuyển giá trị chuỗi sang kiểu datetime
        /// </summary>
        /// <param name="date">chuỗi cần chuyển</param>
        /// <returns></returns>
        public static DateTime ToDate(string date)
        {
            try
            {
                try
                {
                    return DateTime.Parse(date, new CultureInfo("en-US", true));
                }
                catch
                {
                    return DateTime.Parse(date, new CultureInfo("fr-FR", true));
                }
            }
            catch
            {
                return TextUtils.MIN_DATE;
            }
        }

        /// <summary>
        /// Chuyển giá trị datetime sang kiểu chuỗi ngày tháng định dạng Việt Nam
        /// </summary>
        /// <param name="date">Ngày cần chuyển</param>
        /// <returns></returns>
        public static string DateToStringVN(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Chuyển dạng số thành dạng %
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string FormatPercentNumber(Decimal x)
        {
            return String.Format("{0:#0.00}%", x);
        }

        #endregion Các hàm chuyển kiểu
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Lấy dữ liệu từ cơ sở dữ liệu
        /// <summary>
        /// Hàm kết nối với CSDL SqlServer
        /// </summary>
        /// <returns>Trả về giá trị dạng bool</returns>
        static private bool connect()
        {
            string str = DBUtils.GetDBConnectionString();
            try
            {
                mySqlConnection = new SqlConnection(str);
                mySqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Hàm đóng kết nối với CSDL SqlServer
        /// </summary>
        /// <returns></returns>
        static private bool disconnect()
        {
            try
            {
                mySqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy giá trị trả về của procedure với dạng bảng
        /// </summary>
        /// <param name="procedureName">Tên procedure</param>
        /// <param name="mySqlParameter">parametter</param>
        /// <param name="nameSetToTable">Tên bảng trả về</param>
        /// <returns></returns>
        static public DataTable GetTable(string procedureName, SqlParameter mySqlParameter, string nameSetToTable)
        {
            DataTable table = new DataTable();
            try
            {
                if (connect())
                {
                    SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                    DataSet myDataSet = new DataSet();
                    if (mySqlParameter != null)
                        mySqlCommand.Parameters.Add(mySqlParameter);
                    //mySqlCommand.ExecuteNonQuery();
                    mySqlDataAdapter.Fill(myDataSet, nameSetToTable);
                    table = myDataSet.Tables[nameSetToTable];
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                disconnect();
            }
            return table;
        }

        /// <summary>
        /// Lấy giá trị trả về của procedure với dạng bảng
        /// </summary>
        /// <param name="procedureName">tên procedure</param>
        /// <param name="nameSetToTable">Tên bảng trả về</param>
        /// <param name="mySqlParameter">danh sách parameter</param>
        /// <returns></returns>
        static public DataTable GetTable(string procedureName, string nameSetToTable, params SqlParameter[] mySqlParameter)
        {
            DataTable table = new DataTable();
            try
            {
                if (connect())
                {
                    SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                    DataSet myDataSet = new DataSet();
                    for (int i = 0; i < mySqlParameter.Length; i++)
                        mySqlCommand.Parameters.Add(mySqlParameter[i]);
                    //mySqlCommand.ExecuteNonQuery();
                    mySqlDataAdapter.Fill(myDataSet, nameSetToTable);
                    table = myDataSet.Tables[nameSetToTable];
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                disconnect();
            }
            return table;
        }

        /// <summary>
        /// Lấy giá trị trả về của 1 command với dạng bảng
        /// </summary>
        /// <param name="strComm">Chuỗi command</param>
        /// <returns></returns>
        static public DataTable Select(string strComm)
        {
            SqlConnection cnn = new SqlConnection(DBUtils.GetDBConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cnn.Open();
                cmd = new SqlCommand("spSearchAllForTrans", cnn);
                cmd.CommandTimeout = 6000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sqlCommand", strComm));
                //cmd.ExecuteNonQuery();

                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (SqlException se)
            {
                return null ;
                //throw new Exception("Sellect error :" + se.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// Lấy dữ liệu của 1 bảng trong sql
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="exp">Điều kiện</param>
        /// <returns>Trả về một Datatable</returns>
        public static DataTable Select(string tableName, Expression exp)
        {
            return TextUtils.Select(DBUtils.SQLSelect(tableName, exp));
        }

        /// <summary>
        /// Thực thi một câu lệnh Command
        /// </summary>
        /// <param name="strSQL">Chuỗi command</param>
        public static void ExcuteSQL(string strSQL)
        {
            SqlConnection cn = new SqlConnection(DBUtils.GetDBConnectionString());
            SqlCommand cmd = new SqlCommand(strSQL, cn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cn.Open();
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void ExcuteProcedure(string storeProcedureName, string[] paramName, object[] paramValue)
        {
            SqlConnection cn = new SqlConnection(DBUtils.GetDBConnectionString());
            try
            {
                cn = new SqlConnection(DBUtils.GetDBConnectionString());
                SqlCommand cmd = new SqlCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter sqlParam;
                cn.Open();
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        cmd.Parameters.Add(sqlParam);
                    }
                }
                cmd.ExecuteNonQuery();                
            }
            catch (Exception)
            {

            }
            finally
            {
                cn.Close();
            }

        }

        /// <summary>
        /// Thực thi một câu lệnh update
        /// </summary>
        /// <param name="command">Chuỗi câu lệnh update</param>
        /// <returns></returns>
        public static Boolean UpdateByCommand(string command)
        {
            SqlConnection cnn = new SqlConnection(DBUtils.GetDBConnectionString());
            Boolean update = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd = new SqlCommand("spSearchAllForTrans", cnn);
                cmd.CommandTimeout = 6000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sqlCommand", command));
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (SqlException se)
            {
                throw new Exception("UPDATE_ERROR :" + se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return update;
        }

        /// <summary>
        /// Kiểm tra khi đăng nhập
        /// </summary>
        /// <param name="U">Tên đăng nhập</param>
        /// <param name="P">Password đăng nhập</param>
        /// <param name="mU">đối tượng Người sử dụng</param>
        /// <returns></returns>
        static public bool Log(string U, string P, ref UsersModel mU)
        {
            try
            {
                Expression exp = new Expression("LoginName", U, "=");
                exp = exp.And(new Expression("PassWordHash", MD5.EncryptPassword(P), "="));
                //exp = exp.And(new Expression("PassWordHash", MD5.EncodeChecksum(P), "="));
                ArrayList arrU = UsersBO.Instance.FindByExpression(exp);
                if ((arrU != null) && (arrU.Count > 0))
                {
                    mU = (UsersModel)arrU[0];

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }

        public static bool HasPermission(string permissionCode, int userID)
        {
            try
            {
                DataTable dt = TextUtils.Select("select * from vCheckPermission where Code ='" + permissionCode + "' and UserID=" + userID);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion Các hàm lấy dữ liệu từ cơ sở dữ liệu
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Xử lý Chuỗi

        /// <summary>
        /// Viết hoa chữ cái đầu của một chuỗi
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUpperFC(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }

        /// <summary>
        /// Thao
        /// Đổi từ số sang chữ tiếng việt
        /// </summary>
        /// <param name="Num">Giá trị số cần chuyển</param>
        /// <returns></returns>
        public static string NumericToString(decimal Num)
        {
            string[] Dvi = { "", "ngàn", "triệu", "tỷ", "ngàn" };
            string Result = "";
            long IntNum = (long)Num;
            for (int i = 0; i < 5; i++)
            {
                long Doc = (long)IntNum % 1000;
                if (Doc > 0) Result = NumericToString(Doc, IntNum < 1000) + " " + Dvi[i] + "" + Result;
                IntNum = (long)IntNum / 1000;
            }
            Result += " đồng" + ((((long)Num) % 1000 == 0) ? " chẵn" : "");
            if (Result.ToString().Trim().Substring(0, 1) == "m" && Result.ToString().Trim().Substring(3, 1) == "i")
                Result = "Mười " + Result.Remove(0, 5);
            return Result.Length == 4 ? "..." : Result;
        }

        /// <summary>
        /// Đổi từ số sang chữ Tiếng Anh
        /// </summary>
        /// <param name="number">Giá trị số cần chuyển</param>
        /// <returns></returns>
        public static string NumberToWordsENG(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWordsENG(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWordsENG(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWordsENG(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWordsENG(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        /// <summary>
        /// Thao
        /// Dùng để đổi dấu phân biệt hàng nghìn, hàng đơn vị trong các câu lệnh UPDATE
        /// </summary>
        /// <param name="strNumber">Giá trị số cần chuyển theo dạng chuỗi</param>
        /// <returns></returns>
        public static string DoiDau(string strNumber)
        {
            int length = 0; int pos = 0; string st = ""; string DoiDau1 = "";
            st = strNumber;
            pos = st.IndexOf(".", 0);
            while (pos > 0)
            {
                st = st.Substring(0, pos) + st.Remove(0, pos);
                pos = st.IndexOf(".", 0);
            }
            length = st.Length;
            pos = st.IndexOf(",", 0);
            if (pos > 0)
                DoiDau1 = st.Substring(0, pos) + "." + st.Remove(0, pos + 1);
            else
                DoiDau1 = st;

            return DoiDau1;
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Xử lý thời gian

        /// <summary>
        /// Lay ve ngay thang cua he thong.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSystemDate()
        {
            try
            {
                return Convert.ToDateTime(TextUtils.GetTable("spGetDateSystem", null, "Table").Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lấy giá trị chênh lệch giữa 2 mốc thời gian
        /// </summary>
        /// <param name="Interval">dạng giá trị cần lấy h: Số giờ, day: số ngày, month: số tháng, year: số năm</param>
        /// <param name="Date1">Ngày bắt đầu</param>
        /// <param name="Date2">Ngày kết thúc</param>
        /// <returns></returns>
        public static int DateDiff(string Interval, DateTime Date1, DateTime Date2)
        {
            int intDateDiff = 0;
            TimeSpan time = Date1 - Date2;
            int timeHours = Math.Abs(time.Hours);
            int timeDays = Math.Abs(time.Days);

            switch (Interval.ToLower())
            {
                case "h": // hours
                    intDateDiff = timeHours;
                    break;
                case "d": // days
                    time = Date1.Date - Date2.Date;
                    intDateDiff = Math.Abs(time.Days);
                    //intDateDiff = timeDays;
                    break;
                case "w": // weeks
                    intDateDiff = timeDays / 7;
                    break;
                case "bw": // bi-weekly
                    intDateDiff = (timeDays / 7) / 2;
                    break;
                case "m": // monthly
                    timeDays = timeDays - ((timeDays / 365) * 5);
                    intDateDiff = timeDays / 30;
                    break;
                case "bm": // bi-monthly
                    timeDays = timeDays - ((timeDays / 365) * 5);
                    intDateDiff = (timeDays / 30) / 2;
                    break;
                case "q": // quarterly
                    timeDays = timeDays - ((timeDays / 365) * 5);
                    intDateDiff = (timeDays / 90);
                    break;
                case "y": // yearly
                    intDateDiff = (timeDays / 365);
                    break;
            }

            return intDateDiff;
        }

        /// <summary>
        /// Thao
        /// Lấy số tuần của 1 năm
        /// </summary>
        /// <param name="Year">Năm cần lấy</param>
        /// <returns></returns>
        public static List<string> LoadAllWeekOfYear(int Year)
        {
            List<DateTime[]> weeks = new List<DateTime[]>();
            List<string> str = new List<string>();

            DateTime beginDate = new DateTime(Year, 01, 01);
            DateTime endDate = new DateTime(Year, 12, 31);

            DateTime monday = DateTime.Today;
            DateTime satday = DateTime.Today;

            while (beginDate < endDate)
            {
                beginDate = beginDate.AddDays(1);

                if (beginDate.DayOfWeek == DayOfWeek.Monday)
                {
                    monday = beginDate;
                }
                else if (beginDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    satday = beginDate;
                }
                else if (beginDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weeks.Add(new DateTime[] { monday, satday });
                }
            }
            int count = 0;
            for (int x = 1; x < weeks.Count; x++)
            {
                if (x == 1)
                {
                    int startDay = weeks[x][0].Date.Day;
                    if (startDay >= 4)
                    {
                        str.Add("Tuần 1: " + "02/01/" + Year + " - 0" + (startDay - 2) + "/01/" + Year);
                        count = 1;
                    }
                }

                str.Add("Tuần " + (x + count) + ": " + (weeks[x][0]).ToString("dd/MM/yyyy") + " - " + (weeks[x][1]).ToString("dd/MM/yyyy"));

                if (x == weeks.Count - 1)
                {
                    int endDay = weeks[x][1].Date.Day;
                    if (endDay <= 29)
                    {
                        str.Add("Tuần " + (weeks.Count + count) + ": " + (endDay + 2) + "/01/" + Year + " - 31/01/" + Year);
                    }
                }
            }
            return str;
        }

        #endregion Cac ham xu li thoi gian
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        
        #region Xứ lý với File, Folder

        /// <summary>
        /// Lưu trũ một file dựa trên giao diện lưu trữ của window
        /// </summary>
        /// <param name="title"></param>
        /// <param name="filter">Kiểu file (.doc,xls,...)</param>
        /// <param name="FileName">Tên file</param>
        /// <returns></returns>
        public static string ShowSaveFileDialog(string title, string filter, string FileName)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = title;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.FileName = FileName;//name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        /// <summary>
        /// Mở một file
        /// </summary>
        /// <param name="fileName">đường dẫn file</param>
        public static void OpenFile(string fileName)
        {
            if (MessageBox.Show("Do you want to open file?", Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show("File not found.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem đường dẫn có phải là 1 file không
        /// </summary>
        /// <param name="filePath">Đường dẫn</param>
        /// <returns></returns>
        public static bool IsFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }           
            else
            {
                return false;
            }            
        }

        /// <summary>
        /// Kiểm tra xem đường dẫn có phải là 1 thư mục không
        /// </summary>
        /// <param name="filePath">Đường dẫn</param>
        /// <returns></returns>
        public static bool IsFolder(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Copy file nhưng không ghi đề file trùng tên mà tạo ra một phiên bản mới. VD: a(1).txt
        /// </summary>
        /// <param name="sourceFile">Đường dẫn file nguồn</param>
        /// <param name="fileName">Tên file</param>
        /// <param name="destinationPath">Thư mục chứa file</param>
        /// <returns></returns>
        public static bool FileCopyWithoutOverwriting(string sourceFile, string fileName, string destinationPath)
        {
            // if destinationPath doesn't add with a slash, add one
            if ((destinationPath.EndsWith("\\") || destinationPath.EndsWith("/")) == false)
                destinationPath += "\\";

            try
            {
                // if file already exists in destination
                if (File.Exists(destinationPath + fileName))
                {
                    // counter
                    int count = 1;

                    // extract extension
                    FileInfo info = new FileInfo(sourceFile);
                    string ext = info.Extension;
                    string prefix;

                    // if it has an extension, append it to a .
                    if (ext.Length > 0)
                    {
                        // get filename without extension
                        prefix = fileName.Substring(0, fileName.Length - ext.Length);
                        //ext = "." + ext;
                    }
                    else
                        prefix = fileName;

                    // while not found an valid destination file name, increase counter
                    while (File.Exists(destinationPath + fileName))
                    {
                        fileName = prefix + "(" + count.ToString() + ")" + ext;
                        count++;
                    }
                    // copy file
                    File.Copy(sourceFile, destinationPath + fileName);
                }
                else
                {
                    File.Copy(sourceFile, destinationPath + fileName);
                }
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        /// <summary>
        /// Lấy đường dẫn thư mục trên Server
        /// </summary>
        /// <param name="pathServerNotDrive"></param>
        /// <returns></returns>
        public static string GetPathServer()
        {
            string pathServer = "";
            try
            {
                ConfigSystemModel model = (ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "UpdatePath")[0];
                pathServer = @"" + model.KeyValue;
            }
            catch 
            {
                
            }
            
            return pathServer;
        }

        /// <summary>
        /// CreateFolder(Server.MapPath("Album/Folder1″)); sẽ tạo thư mục Folder1 trong thư mục Album của webroot
        /// </summary>
        /// <param name="strPath">Đường dẫn</param>
        public static void CreateFolder(string strPath)
        {

            try
            {

                if (Directory.Exists(strPath) == false)
                {

                    Directory.CreateDirectory(strPath);

                }

            }

            catch { }

        }
        /// <summary>
        /// RenameFolder(Server.MapPath("Album/Folder1″), Server.MapPath("Album/Folder2″)); 
        /// Sẻ đổi tên thư mục có tên Folder1 thành Folder2 trong thư mục Album của webroot
        /// </summary>
        /// <param name="strOldFolderName"></param>
        /// <param name="strNewFolderName"></param>
        public static void RenameFolder(string strOldFolderName, string strNewFolderName)
        {

            try
            {

                Directory.Move(strOldFolderName, strNewFolderName);

            }
            catch { }

        }
        /// <summary>
        /// Hàm xóa hết các thư mục và file bên trong một thư mục: 
        /// </summary>
        /// <param name="directoryInfo"></param>
        public static void EmptyFolder(DirectoryInfo directoryInfo)
        {

            try
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
                {
                    //EmptyFolder(subfolder);
                    subfolder.Delete(true);
                }
            }
            catch { }

        }
        /// <summary>
        /// Hàm Copy thư mục này đến thư mục khác
        /// </summary>
        /// <param name="ThuMucNguon"></param>
        /// <param name="ThucMucDich"></param>
        public static void CopyDirectory(DirectoryInfo ThuMucNguon, DirectoryInfo ThucMucDich)
        {

            try
            {

                if (!ThucMucDich.Exists)
                {

                    ThucMucDich.Create();

                }

                FileInfo[] files = ThuMucNguon.GetFiles(); foreach (FileInfo file in files)
                {

                    if ((File.Exists(System.IO.Path.Combine(ThucMucDich.FullName, file.Name))) == false)
                    {

                        file.CopyTo(Path.Combine(ThucMucDich.FullName, file.Name));

                    }

                }

                //Xử lý thư mục con
                DirectoryInfo[] dirs = ThuMucNguon.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {

                    string ThucMucDichDir = Path.Combine(ThucMucDich.FullName, dir.Name); CopyDirectory(dir, new DirectoryInfo(ThucMucDichDir));

                }

            }

            catch { }

        }
        /// <summary>
        /// Hàm này sẽ xóa thư mục mục và nội dung bên trong của thư mục được chọn
        /// </summary>
        /// <param name="strFolderName"></param>
        public static void DeleteFolder(string strFolderName)
        {

            DirectoryInfo ThuMucNguonDir = new DirectoryInfo(strFolderName);

            if (Directory.Exists(strFolderName))
            {

                try
                {

                    //EmptyFolder(ThuMucNguonDir);
                    EmptyFolder(ThuMucNguonDir);
                    Directory.Delete(strFolderName);

                }

                catch { }

            }

        }

        public static void RenameFile(string filePath, string newName)
        {
            (new Microsoft.VisualBasic.Devices.ServerComputer()).FileSystem.RenameFile(filePath, newName);
        }

        public static void DeleteFile(string filePath)
        {
            (new Microsoft.VisualBasic.Devices.ServerComputer()).FileSystem.DeleteFile(filePath, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
        }
            
        #endregion Xứ lý với File
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Cac ham xu li khac

        /// <summary>
        /// Lấy giá trị trong bảng ConfigSystem
        /// </summary>
        /// <param name="keyName">trường đại diện của giá trị</param>
        /// <returns></returns>
        public static string[] GetConfigSystem(string keyName)
        {
            ConfigSystemModel config = new ConfigSystemModel();
            ArrayList arr = ConfigSystemBO.Instance.FindByAttribute("KeyName", keyName);
            if (arr.Count == 0)
            {
                throw new Exception(String.Format("[{0}] does not exist in [ConfigSystem].", keyName));
            }
            else
                config = (ConfigSystemModel)arr[0];

            List<string> vals = new List<string>();
            PropertyInfo[] props = config.GetType().GetProperties();
            foreach (PropertyInfo p in props)
                if (p.Name.StartsWith("KeyValue"))
                    vals.Add(p.GetValue(config, null).ToString());

            return vals.ToArray();
        }

        /// <summary>
        /// Khởi tạo thông số để kết nối với đầu đọc thẻ
        /// </summary>
        /// <param name="com">Đối tượng xử lý các sự kiện liên quan đến cổng COM</param>
        /// <param name="displayWindow">Control dùng để hiển thị dữ liệu đọc vào từ đầu đọc</param>
        public static void InitializeCardReader(ref CommunicationManager com, Control displayWindow)
        {
            com = new CommunicationManager();
            com.BaudRate = "9600";
            com.DataBits = "8";
            com.Parity = "None";
            com.StopBits = "1";
            com.DisplayWindow = displayWindow;
            com.CurrentTransmissionType = CommunicationManager.TransmissionType.Text;
            try
            {
                string[] settings = File.ReadAllLines("settings.ini");
                for (int i = 0; i < settings.Length; i++)
                {
                    if (settings[i].StartsWith("COMPort"))
                        com.PortName = settings[i].Split('=')[1].Trim().ToUpper();
                }
            }
            catch
            {
                com.PortName = "COM7";
                MessageBox.Show("Cổng COM của đầu đọc thẻ chưa được thiết lập!\nCổng mặc định (COM7) sẽ được sử dụng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Hàm trả địa chỉ IP hoặc tên máy hiện tại
        /// </summary>
        /// <param name="IP"></param>
        /// <returns>IP=true: Trả lại địa chỉ IP. IP=false: Trả lại tên máy</returns>
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }       

        /// <summary>
        /// Kiểm tra một chuối có phải là định dạng của email không
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            bool State = true;
            if (!Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                State = false;
            }

            return State;
        }

        private static string NumberToString(long Num)
        {
            string[] Number = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            return Number[Num];
        }

        public static string NumberToStringH(long Num)
        {
            string[] Number = { "không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            return Number[Num];
        }

        /// <summary>
        /// Chuyển kiểu số sang kiểu chữ tiếna việt
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="Dau"></param>
        /// <returns></returns>
        private static string NumericToString(long Num, bool Dau)
        {
            long Tram = (long)Num / 100;
            long Chuc = (long)(Num % 100) / 10;
            long Dvi = Num % 10;

            string Doc = (((Tram == 0) && (Dau)) ? "" : (" " + NumberToString(Tram) + " trăm")) + ((Chuc == 0) ? (((Tram == 0) && Dau) ? "" : ((Dvi == 0) ? "" : " lẻ")) : ((Chuc == 1) ? " mười" : (" " + NumberToString(Chuc) + " mươi"))) + (((Dvi == 5) && (Chuc > 0)) ? " năm" : ((Dvi == 0) ? "" : " " + NumberToString(Dvi)));
            return Doc;
        }

        /// <summary>
        /// Định dạng số dưới dạng tiền Việt Nam
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatVND(decimal amount)
        {
            if (amount == 0) { return "0"; }
            else
            {
                return amount.ToString(TextUtils.CurrencyFormatVND);
            }
        }

        /// <summary>
        /// Hiển thị Thông báo lỗi
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string content)
        {
            MessageBox.Show(content, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string content, Exception ex)
        {
            MessageBox.Show(content + Environment.NewLine + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ReleaseComObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
        }

        public static void EndProcess(string processName)
        {
            Process[] ps = Process.GetProcesses().Where(o => o.ProcessName.Contains(processName)).ToArray();
            foreach (Process p in ps)
            {
                p.Kill();
            }
        }
        #endregion

        #region LinQ
        public static DataTable GetDistinctDatatable(DataTable dt, string column)
        {
           DataTable dt1 = dt.AsEnumerable()
                            .GroupBy(r => r.Field<string>(column))
                            .Select(g => g.First())
                            .Distinct()
                            .CopyToDataTable();
           return dt1;
        }
        #endregion LinQ
        #endregion Methods
    }
}