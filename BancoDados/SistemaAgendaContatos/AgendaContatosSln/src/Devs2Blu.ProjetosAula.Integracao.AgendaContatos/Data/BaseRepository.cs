using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data
{
    public class BaseRepository
    {
        public string Table { get; set; }

        public BaseRepository(string table)
        {
            Table = table;
        }
        #region Executes

        public MySqlDataReader Get(string sqlGet)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlGet, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public int Insert(string columns, string values)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                string sqlInsert = SQL_INSERT.Replace("@TABLE", Table)
                                             .Replace("@COLUMNS",columns)
                                             .Replace("@VALUES", values);
                MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();

                return (int)cmd.LastInsertedId;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public MySqlDataReader GetAll()
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_ALL.Replace("@TABLE", Table), conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool DeleteById(int id)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_BY_ID.Replace("@TABLE", Table), conn);
                cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        #endregion


        #region SQLs
        private const string SQL_SELECT_ALL = @"SELECT * FROM @TABLE";
        private const string SQL_DELETE_BY_ID = @"DELETE FROM @TABLE WHERE id = @ID";
        private const string SQL_INSERT = @"INSERT INTO @TABLE (@COLUMNS) VALUES (@VALUES)";
        #endregion

    }
}
