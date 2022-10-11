using Devs2Blu.ProjetosAula.SistemaCadastro.Models.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Forms.Data
{
    public class EnderecoRepository
    {
        public bool Save(Endereco endereco, MySqlConnection conn = null)
        {
            if (conn == null)
                conn = ConnectionMySQL.GetConnection();

            try
            {

                return (SaveEndereco(endereco, conn) > 0);

            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private Int32 SaveEndereco(Endereco endereco, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_ENDERECO, conn);
                cmd.Parameters.Add("@idPessoa", MySqlDbType.VarChar, 15).Value = endereco.Pessoa.Id;
                cmd.Parameters.Add("@cep", MySqlDbType.VarChar, 15).Value = endereco.CEP;
                cmd.Parameters.Add("@rua", MySqlDbType.VarChar, 45).Value = endereco.Rua;
                cmd.Parameters.Add("@numero", MySqlDbType.Int32).Value = endereco.Numero;
                cmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 45).Value = endereco.Bairro;

                cmd.ExecuteNonQuery();
                return (Int32)cmd.LastInsertedId;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        internal MySqlDataReader Getenderecos()
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_enderecoS, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool Delete(int id)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_ENDERECO, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #region SQLS
        private const String SQL_INSERT_ENDERECO = @"INSERT INTO endereco
(id_pessoa,
CEP,
rua,
numero,
bairro,
cidade,
uf)
VALUES
(@idPessoa,
@CEP,
@rua,
@numero,
@bairro,
'Blumenau',
'SC')";

        private const String SQL_SELECT_enderecoS = @"SELECT * from endereco";
        private const String SQL_DELETE_ENDERECO = @"DELETE from endereco WHERE id_pessoa = @id";
        #endregion

}
}
