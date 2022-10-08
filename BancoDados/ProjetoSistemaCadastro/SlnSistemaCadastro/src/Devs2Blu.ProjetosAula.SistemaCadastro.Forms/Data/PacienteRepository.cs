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
    public class PacienteRepository
    {
        public Paciente Save(Paciente paciente)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {

                paciente.Pessoa.Id = SavePessoa(paciente, conn);

                return paciente;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private Int32 SavePessoa(Paciente paciente, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_PESSOA, conn);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = paciente.Pessoa.Nome;
                cmd.Parameters.Add("@cgccpf", MySqlDbType.VarChar, 25).Value = paciente.Pessoa.CGCCPF;
                cmd.Parameters.Add("@tipopessoa", MySqlDbType.Enum).Value = paciente.Pessoa.TipoPessoa;

                cmd.ExecuteNonQuery();
                return (Int32)cmd.LastInsertedId;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        internal MySqlDataReader GetPessoas()
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_PESSOAS, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #region SQLS
        private const String SQL_INSERT_PESSOA = @"INSERT INTO pessoa
(nome,
cgccpf,
tipopessoa,
flstatus)
VALUES
(@nome,
@cgccpf,
@tipopessoa,
'A')";
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
@cidade,
@uf)";
        private const String SQL_INSERT_PACIENTE = @"INSERT INTO paciente
(id_pessoa,
id_convenio,
numero_prontuario,
paciente_risco,
flstatus,
flobito)
VALUES
(@id_pessoa,
@id_convenio,
@numero_prontuario,
@paciente_risco,
'A',
0)";
        private const String SQL_SELECT_PESSOAS = @"SELECT id, nome, cgccpf, flstatus from pessoa";
        #endregion
    }
}
