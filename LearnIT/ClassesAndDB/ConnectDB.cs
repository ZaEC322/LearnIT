using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace LearnIT.ClassesAndDB
{
    class ConnectDB
    {
        SqlConnection Connection
        {
            get
            {
                if (con == null)
                {
                    con = new SqlConnection(strConnection);
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return con;
            }
        }

        static SqlConnection con;

        public string strConnection = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;

        #region Инициализация листов
        /// <summary>
        /// Заполнение листа ответов
        /// </summary>
        /// <param name="list_Choices">лист который заполняем</param>
        /// <param name="_qID">id вопроса для процедуры</param>
        /// <returns></returns>
        public bool Init_ListChoices(List<Choice> list_Choices, SqlInt32 _qID)
        {
            SqlCommand cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Procedure1]";

            // параметр для id вопроса
            SqlParameter IDParam = new SqlParameter
            {
                ParameterName = "@Q_ID",
                Value = _qID
            };
            cmd.Parameters.Add(IDParam);

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SqlInt32 ID = (reader.GetInt32(0));
                        SqlInt32 Q_ID = (reader.GetInt32(1));
                        SqlString Choice_Text = (reader.GetString(2));
                        SqlBoolean is_Correct = (reader.GetBoolean(3));

                        list_Choices.Add(new Choice(ID, Q_ID, Choice_Text, is_Correct));  //додаємо в колекцію  
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Дані в таблиці Choices відсутні.\n", "DBQnA.mdf",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Помилка читання даних з бази даних.\n" + exc.ToString(), "DBQnA.mdf",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Connection.Close();
            }

        }
        /// <summary>
        /// Заполнение списка вопросов
        /// </summary>
        /// <param name="list_Questions">лист который заполняем</param>
        /// <returns></returns>
        public  bool Init_ListQuestions(List<Question> list_Questions)
        {
            SqlCommand cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Procedure2]";
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SqlInt32 ID = (reader.GetInt32(0));
                        SqlString Text = (reader.GetString(1));

                        list_Questions.Add(new Question(ID, Text));  //додаємо в колекцію  
                    }
                }
                else
                {
                    MessageBox.Show("Дані в таблиці Questions відсутні.\n", "DBQnA.mdf",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Помилка читання даних з бази даних.\n" + exc.ToString(), "DBQnA.mdf",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion

    }
}
